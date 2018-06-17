using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using testBroadCast;
using System.Collections.Concurrent;

namespace Camera
{

    public partial class realview : Form
    {
        private string audioEventStr;
        private ConcurrentQueue<string> audioMsg = new ConcurrentQueue<string>();
        public realview()
        {
            InitializeComponent();
            if (!CHCNetSDK.NET_DVR_Init()) { Console.WriteLine("NET_DVR_Init error!"); return; }

        }

        private void realview_Load(object sender, EventArgs e)
        {

          
            elevatorinfo.parentForm = this;


            /*-python-*生成
             print('elevatorinfo einfo;')
ss='''
            einfo = new elevatorinfo("192.168.1.%d", "8000", "admin", "NB950110");
            einfo.bindTalkOfIP("192.168.1.%d");
            einfo.setInfo("S%d", "%d号","A%d-%d候车-站台", "蒂森", "垂直电梯");
            tableLayoutPanel1.Controls.Add(einfo);

'''
j=53
s=204
a=2
broadnum=3
for i in range(3,16):
print(ss%(i,j,s,broadnum,a,a+1))
j+=1
s+=2
a+=2
broadnum+=1
             */


            elevatorinfo einfo;


            //einfo=tableLayoutPanel1.Controls[0] as elevatorinfo;

            //einfo = new elevatorinfo("SHJHXNJNVERVEL336", "192.168.5.7", "8000", "admin", "admin123456");
            //einfo.bindTalkOfIP("192.168.5.9");
            //einfo.setInfo("S206", "4号", "A4-5候车-站台", "蒂森", "垂直电梯");
            ////     einfo.ListenElevatorStatus("172.50.0.16", 26);
            //tableLayoutPanel1.Controls.Add(einfo);
            ////ok


            //Byte[][] fakeData = {
            //                        new Byte[] { 0x01, 0x03, 0x18, 0x4A, 0x55, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00 },
            //                     new Byte[] { 0x01, 0x03, 0x18, 0x4A, 0x55, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            //                     new Byte[] { 0x01, 0x03, 0x18, 0x4A, 0x55, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }
            //                    };
            
            einfo = new elevatorinfo("SHJHXNJNVERVEL336", "172.20.4.7", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.7");
            einfo.setInfo("S206", "7号", "A4-5候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.7", 26);

            // For Debug
            //einfo.SetData(fakeData[0]);

            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL335", "172.20.4.8", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.8");
            einfo.setInfo("S205", "8号", "B4-5出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.8", 26);

            // For Debug
            //einfo.SetData(fakeData[1]);

            tableLayoutPanel1.Controls.Add(einfo);
            //ok

            einfo = new elevatorinfo("SHJHXNJNVERVEL338", "172.20.4.9", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.9");
            einfo.setInfo("S208", "9号", "A6-7候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.9", 26);

            // For Debug
            //einfo.SetData(fakeData[2]);

            tableLayoutPanel1.Controls.Add(einfo);
            //ok

            einfo = new elevatorinfo("SHJHXNJNVERVEL337", "172.20.4.10", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.10");
            einfo.setInfo("S207", "10号", "B6-7出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.10", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL340", "172.20.4.11", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.11");
            einfo.setInfo("S210", "11号", "A8-9候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.11", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL339", "172.20.4.12", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.12");
            einfo.setInfo("S209", "12号", "B8-9出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.12", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL342", "172.20.4.13", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.13");
            einfo.setInfo("S212", "13号", "A10-11候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.13", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            ////goto EndOfFn;



            einfo = new elevatorinfo("SHJHXNJNVERVEL341", "172.20.4.14", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.14");
            einfo.setInfo("S211", "14号", "B10-11出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.14", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok   面板ip没有


            einfo = new elevatorinfo("SHJHXNJNVERVEL344", "172.20.4.15", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.15");
            einfo.setInfo("S214", "15号", "A12-13候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.15", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL343", "172.20.4.16", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.16");
            einfo.setInfo("S213", "16号", "B12-13出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.16", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //OK


            einfo = new elevatorinfo("SHJHXNJNVERVEL346", "172.20.4.17", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.17");
            einfo.setInfo("S216", "17号", "A14-15候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.17", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //OK

            einfo = new elevatorinfo("SHJHXNJNVERVEL345", "172.20.4.18", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.18");
            einfo.setInfo("S215", "18号", "B14-15出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.18", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //OK


            einfo = new elevatorinfo("SHJHXNJNVERVEL348", "172.20.4.19", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.19");
            einfo.setInfo("S218", "19号", "A16-17候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.19", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //OK

            einfo = new elevatorinfo("SHJHXNJNVERVEL347", "172.20.4.20", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.20");
            einfo.setInfo("S217", "20号", "B16-17出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.20", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //OK


            einfo = new elevatorinfo("SHJHXNJNVERVEL350", "172.20.4.21", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.21");
            einfo.setInfo("S220", "21号", "A18-19候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.21", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //OK

            einfo = new elevatorinfo("SHJHXNJNVERVEL349", "172.20.4.22", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.22");
            einfo.setInfo("S219", "22号", "B18-19出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.22", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok

            einfo = new elevatorinfo("SHJHXNJNVERVEL352", "172.20.4.23", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.23");
            einfo.setInfo("S222", "23号", "A20-21候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.23", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok

            einfo = new elevatorinfo("SHJHXNJNVERVEL351", "172.20.4.24", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.24");
            einfo.setInfo("S221", "24号", "B20-21出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.24", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL354", "172.20.4.25", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.25");
            einfo.setInfo("S224", "25号", "A22-23候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.25", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL353", "172.20.4.26", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.26");
            einfo.setInfo("S223", "26号", "B22-23出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.26", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL356", "172.20.4.27", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.27");
            einfo.setInfo("S226", "27号", "A24-25候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.27", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL355", "172.20.4.28", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.28");
            einfo.setInfo("S225", "28号", "B24-25出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.28", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL358", "172.20.4.29", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.29");
            einfo.setInfo("S228", "29号", "A26-27候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.29", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok  面板ip没有


            einfo = new elevatorinfo("SHJHXNJNVERVEL357", "172.20.4.30", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.30");
            einfo.setInfo("S227", "30号", "B26-27出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.30", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL360", "172.20.4.31", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.31");
            einfo.setInfo("S230", "31号", "A28", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.31", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL359", "172.20.4.32", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.32");
            einfo.setInfo("S229", "32号", "B28", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.32", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL332", "172.20.4.3", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.3");
            einfo.setInfo("S202", "3号", "A1站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.3", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok



            einfo = new elevatorinfo("SHJHXNJNVERVEL331", "172.20.4.4", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.4");
            einfo.setInfo("S201", "4号", "B1站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.4", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL327", "172.20.4.33", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.33");
            einfo.setInfo("S102", "33号", "北广场西", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.33", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok



            einfo = new elevatorinfo("SHJHXNJNVERVEL326", "172.20.4.34", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.34");
            einfo.setInfo("S101", "34号", "北广场东", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.34", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok



            einfo = new elevatorinfo("SHJHXNJNVERVEL330", "172.20.4.36", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.36");
            einfo.setInfo("S105", "36号", "西北角货梯", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.36", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL328", "172.20.4.37", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.37");
            einfo.setInfo("S103", "37号", "东北角货梯", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.37", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok




            einfo = new elevatorinfo("SHJHXNJNVERVEL361", "172.20.4.35", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.35");
            einfo.setInfo("S301", "35号", "南广场西", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.35", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok



            einfo = new elevatorinfo("SHJHXNJNVERVEL334", "172.20.4.5", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.5");
            einfo.setInfo("S204", "5号", "A2-3候车-站台", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.5", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok


            einfo = new elevatorinfo("SHJHXNJNVERVEL333", "172.20.4.6", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.6");
            einfo.setInfo("S203", "6号", "B2-3出站口", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.6", 26);
            tableLayoutPanel1.Controls.Add(einfo);
            //ok





            einfo = new elevatorinfo("SHJHXNJNVERVEL329", "172.20.4.38", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.38");
            einfo.setInfo("S104", "38号", "VIP", "蒂森", "垂直电梯");
            einfo.ListenElevatorStatus("172.20.6.38", 26);
            tableLayoutPanel1.Controls.Add(einfo);


            einfo = new elevatorinfo("SHJHXNJNELEELL421", "172.20.4.51", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.51");
            einfo.setInfo("F314", "51号", "12-13站台西上", "蒂森", "扶梯");
            //   einfo.ListenElevatorStatus("172.20.6.38", 26);
            einfo.setType();
            tableLayoutPanel1.Controls.Add(einfo);


            einfo = new elevatorinfo("SHJHXNJNELEELL419", "172.20.4.52", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.52");
            einfo.setInfo("F312", "52号", "10-11站台西上", "蒂森", "扶梯");
            //   einfo.ListenElevatorStatus("172.20.6.38", 26);
            einfo.setType();

            tableLayoutPanel1.Controls.Add(einfo);

            einfo = new elevatorinfo("SHJHXNJNELEELL417", "172.20.4.53", "8000", "admin", "NB950110");

            einfo.bindTalkOfIP("172.20.5.53");
            einfo.setInfo("F310", "53号", "8-9站台西上", "蒂森", "扶梯");
            //   einfo.ListenElevatorStatus("172.20.6.38", 26);
            einfo.setType();

            tableLayoutPanel1.Controls.Add(einfo);

            EndOfFn:

            //初始化控件风格
            foreach (RowStyle rs in tableLayoutPanel1.RowStyles)
            {
                rs.SizeType = SizeType.Absolute;

                rs.Height = tableLayoutPanel1.Height / 2;

            }


        }
        static int lefttime = 0;
        static List<BroadCallInfo> calls=new List<BroadCallInfo>();
        private int executedCounts=0;
        public  int onTAudioCastEvent(int eventMsg, string parstr)
        {
            lock (realview.calls)
            {

                List<BroadCallInfo> calls = QTtool.GetCallBroadIP(parstr);
                foreach (BroadCallInfo mycall in calls)
                {
                    // if (!mycall.ip.Contains("1.90"))
                    realview.calls.Add(mycall);
                }
                Debug.WriteLine(DateTime.Now.ToLocalTime().ToString() + ":" + parstr);
                string[] ls = parstr.Split();
                lefttime = 1;


            }

            //      audioMsg.Enqueue(parstr);
            Debug.WriteLine(DateTime.Now.ToLocalTime().ToString() + ":" + parstr);
            executedCounts++;
            return 1;
        }

      
       
        
            public void login(string ip = "172.20.5.200", int port = 8902)
        {
           
            int result = 0;
            result = audio.audio_OpenAudioCast(ip, port);
            if (result < 1) { MessageBox.Show("登录失败=" + result); Close(); return; }
            audio.audio_CheckPWD("admin", "");

            result = audio.audio_SetEventFunc(0xff, onTAudioCastEvent);
            if (result < 1)
            {
                MessageBox.Show("登录失败=" + result);
                Close(); return;
            }
            Show();

        }

        private void broadtimer_Tick(object sender, EventArgs e)
        {

            if (lefttime > 0)
            {
                lock (realview.calls)
                {
                    lefttime = 0;
                    foreach (BroadCallInfo mycall in realview.calls)
                    {

                        elevatorinfo.OnBroadCallListener(mycall);
                    }

                    realview.calls.Clear();
                }
            }
            //if (!audioMsg.IsEmpty)
            //{
            //    audioMsg.TryDequeue(out audioEventStr);
            //    List<BroadCallInfo> calls = QTtool.GetCallBroadIP(audioEventStr);
            //    foreach(BroadCallInfo mycall in calls)
            //    {
            //        elevatorinfo.OnBroadCallListener(mycall);
            //    }
            //}
        }



        protected override void OnFormClosed(FormClosedEventArgs e)
        {

            base.OnFormClosed(e);
            Dispose();
            CHCNetSDK.NET_DVR_Cleanup();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            elevatorinfo el = elevatorinfo.num[bt.Text] as elevatorinfo;
            if(el!=null)
            el.pictureBox_Click(null,null);
        }

        public static int WrongNum = 0;
        public static int RepairNum = 0;
    }

}
