using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Camera
{
    public partial class RecordForm : Form
    {
        private List<RecordJson> recordJsonList;
        private static int i = 0;
    //    
    //    List<Data> dataList=new List<Data>();
     

        public RecordForm(string id,string num)
        {
            InitializeComponent();
            deviceId.Text = id;
            devicename.Text = "无机房电梯" + num;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;

            string key = "jsyljsyl";
            string name = "STDZ";
            string password = "JSYLST12" + DateTime.Now.ToString("yyyyMMddHHmm");
            string encodePassword = DES.Encode(password, key);

            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string pastTime = DateTime.Now.AddMonths(-3).ToString("yyyyMMddHHmmss");

            string strToSign = JsonConvert.SerializeObject(new
            {
                deviceid = deviceId.Text,
                datestart = pastTime,
                dateend = nowTime
            });
            string sign = DES.Encode(strToSign, key);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.senergychina.com.cn:16880/njnsbznh/api/device/record?name=" + name + "&password=" + encodePassword + "&sign=" + sign);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = reader.ReadToEnd();

            reader.Close();
            myResponseStream.Close();

            JObject jsonObj = JObject.Parse(retString);
            string data = (string)jsonObj["data"];
            string decodeStr = DES.Decode(data, key);



            if (decodeStr == "{\"empty\":true}")
            {
                button1.Visible = false;
                button2.Visible = false;
            }



            recordJsonList = JsonConvert.DeserializeObject<List<RecordJson>>(decodeStr);

            DataShow();






        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (recordJsonList.Count != 0)
            {
                if (--i < 0)
                {
                    i = 0;
                }


                DataShow();


            }
        }
          

        private void DataShow()
        {

            try
            {
                
                deviceId.Text = recordJsonList[i].deviceId.ToString();
                devicename.Text = recordJsonList[i].devicename.ToString();
                callTime.Text = recordJsonList[i].callTime.ToString();
                happenTime.Text = recordJsonList[i].happenTime.ToString();
                eventTime.Text = recordJsonList[i].eventTime.ToString();
                taskTime.Text = recordJsonList[i].taskTime.ToString();
                code.Text = recordJsonList[i].code.ToString();
                message.Text = recordJsonList[i].message.ToString();
                problem.Text = recordJsonList[i].problem.ToString();
                caller.Text = recordJsonList[i].caller.ToString();
                dealcontent.Text = recordJsonList[i].dealcontent.ToString();
                callertype.Text = recordJsonList[i].callertype.ToString();
                enginnername.Text = recordJsonList[i].enginnername.ToString();
            }
            catch {
                MessageBox.Show("未获取到设备履历");
            }
           
            //deviceId.Text = data.deviceId;
            //devicename.Text = data.devicename;
            //callTime.Text = data.callTime;
            //happenTime.Text = data.happenTime;
            //eventTime.Text = data.eventTime;
            //taskTime.Text = data.taskTime;
            //code.Text = data.code;
            //message.Text = data.message;
            //problem.Text = data.problem;
            //caller.Text = data.caller;
            //dealcontent.Text = data.dealcontent;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (++i < recordJsonList.Count)
            {

  //              DataShow();
            }

        }
    }
}
