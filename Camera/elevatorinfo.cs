
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using testBroadCast;
using System.Drawing;
using QRCoder;
namespace Camera
{
    public partial class elevatorinfo : UserControl
    {

        private string elevatorNum;
        private string position;
        public string MMC_ip;
        public string id;
        int userid, chanid, delayMinute;
        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        Button[] btevaerrs;
        Random ra = new Random();
        string ip, port, username = null, password;
        public static Form parentForm;

        private TcpConnection s206eleInfoConn = null;
        private System.Timers.Timer pollElevatorInfoTimer = new System.Timers.Timer();

        public elevatorinfo(string id, string ip, string port, string username, string password)
        {
            InitializeComponent();
            Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.id = id; this.ip = ip; this.port = port; this.username = username; this.password = password;
        }




        public async void ListenElevatorStatus(string serverIp, int serverPort)
        {
            try
            {
                MMC_ip = serverIp;
                this.s206eleInfoConn = new TcpConnection(serverIp, serverPort);
                this.s206eleInfoConn.OnPacketReceived += new DataHandler(OnElevatorReplied);
                await this.s206eleInfoConn.Open();

                this.pollElevatorInfoTimer.Interval = 1000;
                this.pollElevatorInfoTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnPollEleInfoTimer);
                this.pollElevatorInfoTimer.Start();
            }
            catch
            {
            }
        }

        private async void OnPollEleInfoTimer(object sender, System.Timers.ElapsedEventArgs arg)
        {
            try
            {
                await s206eleInfoConn.SendData(new byte[] { 1, 3, 0, 0, 0, 0xc }, 6);
            }
            catch
            {
            }
        }

        private void OnElevatorReplied(byte[] data)
        {
            // For Debug
            //data = fakeData;

            if (data[0] == 1 &&
                data[1] == 3 &&
                data[2] == 24 &&
                data.Length == 27)
            {
                
                //梯门故障
                //else if (data[3] == 0x2D)
                //{
                //    SetButtonText(btevanormal,"警铃");
                //}
                string state = "";
                int floor = data[4] - 0x30;
                int direc = data[26];
                //梯门故障
                Boolean isDoorWrong = data[3] == 0x4A && data[24] == 0x02;
                //卡门（梯门故障）  --错层(电梯开关门会触发）
                Boolean cuoCeng = data[24] == 1 && data[26] == 1;
                //开关门故障
         //     Boolean isOpenCloseDoorWrong = data[3] == 0x49 && data[4] == 0x46 && data[28] == 0x02;
                Boolean isRunningException = data[6] == 1 && data[12] == 1;
                //底坑故障（上限位，下限位） 
                Boolean isPitWrong = data[3] == 0x4A && data[4] == 0x55 && data[6] == 1 && data[12] == 1;

                //安全窗断开
        //        Boolean isSafewindowsWrong = data[3] == 0x49 && data[4] == 0x46 && data[10] == 0x01 && data[28] == 0x01;
                //急停（运行故障）    --
                Boolean quickStop = data[3] == 0x00 && data[4] == 0x00;
                //
                DoorWarning(isDoorWrong);
      //          RunWrong(cuoCeng);
                RunWrong(isRunningException);
                NormalStoppage(isDoorWrong);
                dkWrong(isPitWrong);
                //门锁断开
            //    Boolean isDoorBreak = data[3] == 0x4A && data[4] == 0x55 && data[24] == 0x02 && data[28] == 0x01;
                if (isDoorWrong || cuoCeng || isRunningException || isPitWrong || quickStop)
                {
                    realview.WrongNum++;
                }

            //    NormalStoppage(!isDoorWrong && !isRunningException && !isPitWrong && data[12] == 1);

                if (data[3] == 0x49 && data[4] == 0x46&&data[10]==0x01)
                {
                    state = "停梯检修";
                }

                //                    NormalStoppage(data[6] != 1&&data[10]!= 1&&data[12] == 1);


                //                    if (data[6] == 1)
                //                    {
                //                    if (data[12] == 1)
                //                        //state = "电梯运行不正常";
                //                        RunWrong();

                //                    }   
                //                    else if (data[10] == 1)
                //                    {
                //                        state = "停梯检修";
                //                    }
                //                   else if (data[3] == 0x4A && data[4] == 0x55 && data[6] == 1 && data[12] == 1)
                //                {
                //                    //底坑故障
                //                    dkWrong();
                //                }
                //                else if (data[12] == 1)
                //                {
                //                    //state = "电梯一般故障";

                //                    NormalStoppage();
                //                }

                if (floor > 0 && data[3] == 0)
                {
                    SetLabelText(labelPosition, floor + "楼");
                    SetLabelDirection(labelDirection, direc);
                    reset();
                }
                if (state == "停梯检修")
                {
                    SetButtonText(btevanormal, state);
                    realview.RepairNum++;
                }
            }
        }

        private void DoorWarning(Boolean set)
        {
            Action setter = () =>
              {
                  if (set)
                  {
                      btevaerr9.BackColor = Color.Red;
                      button4.BackColor = Color.Red;
                      pictureBox_Click(null, null);
                      QTtool.playWavAudio(Properties.Resources.ALARM3);
                  }
                  else
                  {
                      btevaerr9.BackColor = System.Drawing.SystemColors.ControlLight;
                      button4.BackColor = System.Drawing.SystemColors.ControlLight;

                  }
              };

            if (btevaerr9.BackColor == Color.Red && !set ||
                btevaerr9.BackColor != Color.Red && set)
            {
                if (btevaerr9.InvokeRequired)
                {
                    btevaerr9.Invoke(setter);
                }
                else
                {
                    setter();
                }
            }
        }

        private void dkWrong(Boolean set)
        {
            Action setter = () =>
              {
                  if (set)
                  {
                      if (button5.BackColor != Color.Red)
                      {
                          button5.BackColor = Color.Red;
                          pictureBox_Click(null, null);
                          QTtool.playWavAudio(Properties.Resources.ALARM3);
                      }
                  }
                  else
                  {
                      button5.BackColor = System.Drawing.SystemColors.ControlLight;
                  }

              };
            if (button5.BackColor == Color.Red && !set ||
                button5.BackColor != Color.Red && set)
            {
                if (button5.InvokeRequired)
                {
                    button5.Invoke(setter);
                }
                else
                {
                    setter();
                }
            }
        }

        private void RunWrong(Boolean set)
        {
            Action setter = () =>
            {
                if (set)
                {

                    button3.BackColor = Color.Red;
                    
                    pictureBox_Click(null, null);
                    QTtool.playWavAudio(Properties.Resources.ALARM3);
                }
                else
                {
                    button3.BackColor = System.Drawing.SystemColors.ControlLight;
                }

            };
            if (button3.BackColor == Color.Red && !set ||
                button3.BackColor != Color.Red && set)
            {
                if (button3.InvokeRequired)
                {
                    button3.Invoke(setter);
                }
                else
                {
                    setter();
                }
            }
        }

        private void NormalStoppage(Boolean set)
        {
            Action setter = () =>
            {
                if (set)
                {
                    button4.BackColor = Color.Red;
                    pictureBox_Click(null, null);
                    QTtool.playWavAudio(Properties.Resources.ALARM3);
                }
                else
                {
                    button4.BackColor = System.Drawing.SystemColors.ControlLight;
                }
            };
            if (button4.BackColor == Color.Red && !set ||
                button4.BackColor != Color.Red && set)
            {
                if (button4.InvokeRequired)
                {
                    button4.Invoke(setter);
                }
                else
                {
                    setter();
                }
            }
        }

        private void reset()
        {
            Action setter = () =>
            {
                btevanormal.Text = "正常运行";
                btevanormal.BackColor = Color.Green;
                btevaerr9.BackColor = System.Drawing.SystemColors.ControlLight;
                button3.BackColor = System.Drawing.SystemColors.ControlLight;
                button4.BackColor = System.Drawing.SystemColors.ControlLight;
                button5.BackColor = System.Drawing.SystemColors.ControlLight;
            };

            if (btevanormal.InvokeRequired)
            {
                btevanormal.Invoke(setter);
            }
            else
            {
                setter();
            }
        }

        private void SetLabelText(Label label, string text)
        {
            Action setter = () =>
                {

                    label.Text = text;

                };

            if (label.InvokeRequired)
            {
                label.Invoke(setter);
            }
            else
            {
                setter();
            }
        }

        private void SetLabelDirection(Label label, int direction)
        {
            Action changer = () =>
            {
                if (direction == 1 || direction == 2)
                {
                    label.Text = direction == 1 ? "↑" : "↓";
                    label.Visible = true;
                }
                else
                {
                    label.Visible = false;
                }
            };

            if (label.InvokeRequired)
            {
                label.Invoke(changer);
            }
            else
            {
                changer();
            }
        }

        private void SetButtonText(Button button, string text)
        {
            Action setter = () =>
            {
                if (text != "")
                {
                    button.Text = text;
                    button.BackColor = Color.Red;
                    //SetLabelText(labelPosition, "检修中");
                    SetLabelDirection(labelDirection, 0);
                    Log.log(text);
                    Log.log(text + "        " + "电梯位置" + lbbroadnum.Text + "        " + "电梯IP:  " + MMC_ip);


                }
            };
            if (button.InvokeRequired)
            {
                button.Invoke(setter);
            }
            else
            {
                setter();
            }
        }



        public elevatorinfo(int userid, int chanid, int delayMinute = 0, int value = 0)
        {
            this.chanid = chanid;
            this.userid = userid;
            this.delayMinute = delayMinute;


        }

        public elevatorinfo(int value)
        {

            btevaerrs = new Button[] { btevanormal, btevaerr9, button3, button4, button5 };
            if (value == 0)
                btevaerrs[value].BackColor = Color.Green;
            else btevaerrs[value].BackColor = Color.Red;
            //Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            //| AnchorStyles.Left)
            //| AnchorStyles.Right)));

        }
        private void elevatorinfo_Load(object sender, System.EventArgs e)
        {
            

            MaximumSize = new System.Drawing.Size(Parent.Width / 2, Parent.Height / 2);
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            if (delayMinute <= 2)
            {
                m_realDataCallback = null;

                if (username == null)
                {
                    //通道取画面

                    lpPreviewInfo.hPlayWnd = pictureBox.Handle;//预览窗口
                    lpPreviewInfo.lChannel = chanid;//预te览的设备通道
                    lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                    lpPreviewInfo.bBlocked = false; //0- 非阻塞取流，1- 阻塞取流
                    lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数
                }
                else
                {
                    //ip取画面
                    userid = CHCNetSDK.NET_DVR_Login_V30(ip, Int32.Parse(port), username, password, ref DeviceInfo);

                    lpPreviewInfo.hPlayWnd = pictureBox.Handle;
                    //lpPreviewInfo.hPlayWnd = IntPtr.Zero;
                    //m_ptrRealHandle = pictureBox.Handle;
                    //m_realDataCallback = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);
                    
                    lpPreviewInfo.lChannel = 1;//预览的设备通道 the device channel number
                    lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

                }
                if ((CHCNetSDK.NET_DVR_RealPlay_V40(userid, ref lpPreviewInfo, m_realDataCallback/*RealData*/, IntPtr.Zero)) < 0)
                {

                    //取消未连接弹框
                    //  MessageBox.Show("userid=" + userid);
                    //   MessageBox.Show("登录失败,NET_DVR_Login_V30 failed, error code=" + CHCNetSDK.NET_DVR_GetLastError()); //登录失败，输出错误号 Failed to login and output the error code
                }
            }
            else
            {
                delayPlay(delayMinute);
            }
        }

        void delayPlay(int delayMinute)
        {
            CHCNetSDK.NET_DVR_VOD_PARA struVodPara = new CHCNetSDK.NET_DVR_VOD_PARA();
            struVodPara.dwSize = (uint)Marshal.SizeOf(struVodPara);
            struVodPara.struIDInfo.dwChannel = (uint)chanid; //通道号 Channel number  
            struVodPara.hWnd = pictureBox.Handle;//回放窗口句柄

            DateTime dt = DateTime.Now;
            DateTime dt10 = dt.AddMinutes(-delayMinute);

            //设置回放的开始时间 Set the starting time to search video files
            struVodPara.struBeginTime.dwYear = (uint)dt10.Year;
            struVodPara.struBeginTime.dwMonth = (uint)dt10.Month;
            struVodPara.struBeginTime.dwDay = (uint)dt10.Day;
            struVodPara.struBeginTime.dwHour = (uint)dt10.Hour;
            struVodPara.struBeginTime.dwMinute = (uint)dt10.Minute;
            struVodPara.struBeginTime.dwSecond = (uint)dt10.Second;

            //设置回放的结束时间 Set the stopping time to search video files
            dt10 = dt.AddYears(1000);
            struVodPara.struEndTime.dwYear = (uint)dt10.Year;
            struVodPara.struEndTime.dwMonth = (uint)dt10.Month;
            struVodPara.struEndTime.dwDay = (uint)dt10.Day;
            struVodPara.struEndTime.dwHour = (uint)dt10.Hour;
            struVodPara.struEndTime.dwMinute = (uint)dt10.Minute;
            struVodPara.struEndTime.dwSecond = (uint)dt10.Second;


            int m_lPlayHandle = CHCNetSDK.NET_DVR_PlayBackByTime_V40(userid, ref struVodPara);
            uint iLastErr;
            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lPlayHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //回放控制失败，输出错误号
                MessageBox.Show(str);
                pictureBox.Dispose();
                return;
            }



        }


        public static Hashtable num = new Hashtable();

        int broadId;
        public void setInfo(string snum, string sbroadnum, string spostion, string soem, string stype)
        {
            if (!num.ContainsKey(snum))
                num.Add(snum, this);
            broadId = Int32.Parse(sbroadnum.Split(new char[] { '号' })[0]);
            position = spostion;
            elevatorNum = snum;

            lbnum.Text = "电梯编号:" + snum;
            lbbroadnum.Text = "面板编号:" + sbroadnum;
            lbpostion.Text = "电梯位置:" + spostion;
            lboem.Text = "电梯品牌:" + soem;
            lbtype.Text = "电梯类型:" + stype;


            Bitmap image = getQRCode(snum);
            pictureBox1.Image = Image.FromHbitmap(image.GetHbitmap());

        }

        public TestForm maxForm;
        public void pictureBox_Click(object sender, EventArgs e)
        {
            if (!TestForm.isInstantsShow)
            {
                PictureBox pic = pictureBox;
                maxForm = new TestForm(pic.Parent, pic);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Information form = new Information(id, MMC_ip, position, elevatorNum);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            TestForm.instantsClose();
        }


        static Hashtable ht = new Hashtable();
        public void bindTalkOfIP(string ip)
        {
            if (ht.ContainsKey(ip))
                ht[ip] = this;
            else
                ht.Add(ip, this);
        }

        private static string boardIP;
        public static void OnBroadCallListener(BroadCallInfo mycall)
        {
            elevatorinfo el = ht[mycall.ip] as elevatorinfo;

            if (el == null) return;
            if (mycall.e_num == 3)
            {
                boardIP = mycall.ip;
                el.pictureBox_Click(null, null);
                //el.playAlerm();
                QTtool.playWavAudio(Properties.Resources.ALARM3);
                Log.log(el.lbpostion.Text + "呼叫" + "        " + "   " + el.lbnum.Text + "        " + "电梯IP  " + el.MMC_ip);

            }
            else if (mycall.ip == boardIP && mycall.e_num == 1)
            {
                TestForm.instantsClose();

            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecordForm form = new RecordForm(id, elevatorNum);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void btevanormal_Click(object sender, EventArgs e)
        {

        }



        private Int32 m_lPort = -1;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            WrongInformation wi = new WrongInformation(button.Text);
            wi.StartPosition = FormStartPosition.CenterScreen;
            wi.Show();

           
            
        }

        private IntPtr m_ptrRealHandle = IntPtr.Zero;
        private CHCNetSDK.REALDATACALLBACK m_realDataCallback = null;
        
        /// <summary>
        /// 数据处理委托
        /// </summary>
        private delegate void DealVideoDelegate(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser);
        /// <summary>
        /// 码流获取后触发回调函数
        /// </summary>
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            //视频数据使用委托方式处理，否则会出现内存回收异常
            DealVideoDelegate videoDlegate = new DealVideoDelegate(dealVideo);
            videoDlegate(lRealHandle, dwDataType, pBuffer, dwBufSize, pUser);
        }

        private void dealVideo(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            Int32 iLastErr;
            String str;

            switch (dwDataType)
            {
                case CHCNetSDK.NET_DVR_SYSHEAD:     // sys head
                    if (dwBufSize > 0)
                    {
                        if (m_lPort >= 0)
                        {
                            return; //同一路码流不需要多次调用开流接口
                        }

                        //获取播放句柄 Get the port to play
                        if (!PlayCtrl.PlayM4_GetPort(ref m_lPort))
                        {
                            iLastErr = PlayCtrl.PlayM4_GetLastError(m_lPort);
                            str = "PlayM4_GetPort failed, error code= " + iLastErr;
                            Console.WriteLine(str);
                            break;
                        }

                        //设置流播放模式 Set the stream mode: real-time stream mode
                        if (!PlayCtrl.PlayM4_SetStreamOpenMode(m_lPort, PlayCtrl.STREAME_REALTIME))
                        {
                            iLastErr = PlayCtrl.PlayM4_GetLastError(m_lPort);
                            str = "Set STREAME_REALTIME mode failed, error code= " + iLastErr;
                            Console.WriteLine(str);
                        }

                        //打开码流，送入头数据 Open stream
                        if (!PlayCtrl.PlayM4_OpenStream(m_lPort, pBuffer, dwBufSize, 10 * 1024 * 1024))
                        {
                            iLastErr = PlayCtrl.PlayM4_GetLastError(m_lPort);
                            str = "PlayM4_OpenStream failed, error code= " + iLastErr;
                            Console.WriteLine(str);
                            break;
                        }
                        //设置显示缓冲区个数 Set the display buffer number
                        //if (!PlayCtrl.PlayM4_SetDisplayBuf(m_lPort, 15))
                        //{
                        //    iLastErr = PlayCtrl.PlayM4_GetLastError(m_lPort);
                        //    str = "PlayM4_SetDisplayBuf failed, error code= " + iLastErr;
                        //}
                        //设置显示模式 Set the display mode
                        //if (!PlayCtrl.PlayM4_SetOverlayMode(m_lPort, 1, 0/* COLORREF(0)*/)) //play off screen 
                        //{
                        //    iLastErr = PlayCtrl.PlayM4_GetLastError(m_lPort);
                        //    str = "PlayM4_SetOverlayMode failed, error code= " + iLastErr;
                        //    Console.WriteLine(str);
                        //}

                        //设置硬解码
                        if (!PlayCtrl.PlayM4_SetDecodeEngineEx(m_lPort, 1))
                        {
                            iLastErr = PlayCtrl.PlayM4_GetLastError(m_lPort);
                            str = "PlayM4_SetDecodeEngineEx failed, error code= " + iLastErr;
                            Console.WriteLine(str);
                            break;
                        }

                        ////设置硬解码
                        //if (!PlayCtrl.PlayM4_SetDecodeEngineEx(m_lPort, 1))
                        //{
                        //    iLastErr = PlayCtrl.PlayM4_GetLastError(m_lPort);
                        //    str = "PlayM4_SetDecodeEngineEx failed, error code= " + iLastErr;
                        //    Console.WriteLine(str);
                        //    break;
                        //}

                        //开始解码 Start to play                       
                        if (!PlayCtrl.PlayM4_Play(m_lPort, m_ptrRealHandle))
                        {
                            iLastErr = PlayCtrl.PlayM4_GetLastError(m_lPort);
                            str = "PlayM4_Play failed, error code= " + iLastErr;
                            Console.WriteLine(str);
                            break;
                        }
                    }
                    break;
                case CHCNetSDK.NET_DVR_STREAMDATA:     // video stream data
                    if (dwBufSize > 0 && m_lPort != -1)
                    {
                        for (int i = 0; i < 999; i++)
                        {
                            if (!PlayCtrl.PlayM4_InputData(m_lPort, pBuffer, dwBufSize))
                            {
                                iLastErr = PlayCtrl.PlayM4_GetLastError(m_lPort);
                                str = "PlayM4_InputData failed, error code= " + iLastErr;
                                Console.WriteLine(str);
                                System.Threading.Thread.Sleep(2);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    break;
                default:
                    if (dwBufSize > 0 && m_lPort != -1)
                    {
                        //送入其他数据 Input the other data
                        for (int i = 0; i < 999; i++)
                        {
                            if (!PlayCtrl.PlayM4_InputData(m_lPort, pBuffer, dwBufSize))
                            {
                                iLastErr = PlayCtrl.PlayM4_GetLastError(m_lPort);
                                str = "PlayM4_InputData failed, error code= " + iLastErr;
                                Console.WriteLine(str);
                                //Thread.Sleep(2);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    break;
            }
        }

        private Bitmap getQRCode(string str)
        {
            string url = "https://www.gl-xin.cn/elevator/info/"+str+".html";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(5, Color.Black, Color.White, null, 15, 6, false);
            return qrCodeImage;
        }


        public  void setType()
        {
            button4.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;

            button3.Text = "急停";
            btevaerr9.Text = "逆行";
        }
    }

   

    public class TestForm : Form
    {
        Control contarget;
        Control parent;
        PictureBox pic;
        public static TestForm instants = null;
        public static void instantsClose()
        {
            if (instants != null)
            {
                instants.Close();
                instants.Dispose();
                GC.Collect();
            }
        }

        public static bool isInstantsShow = false;
        public TestForm(Control contarget, PictureBox pic)
        {

            instantsClose();
            isInstantsShow = true;
            instants = this;
            this.pic = pic;
            parent = contarget.Parent;
            Size = new Size(500, 500);
            this.Controls.Add(contarget);
            this.contarget = contarget;

            WindowState = System.Windows.Forms.FormWindowState.Maximized;

            Show();

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            contarget.Parent = parent;
            isInstantsShow = false;
            base.OnFormClosed(e);
            Dispose();
        }
    }
}
