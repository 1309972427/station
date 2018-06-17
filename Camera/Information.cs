using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Camera
{
    public partial class Information : Form
    {
        
        public Information(string id,string ip,string position,string num)
        {
            InitializeComponent();
            this.id.Text = id;
            this.ip.Text = ip;
            this.sywz.Text = position;
            this.sbmc.Text = "无机房电梯" + num;
        }

        private void information_Load(object sender, EventArgs e)
        {
            string key = "jsyljsyl";
            string name = "STDZ";
            string password = "JSYLST12" + DateTime.Now.ToString("yyyyMMddHHmm");
            string encodePassword = DES.Encode(password, key);
            string sign = DES.Encode(id.Text, key);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.senergychina.com.cn:16880/njnsbznh/api/device?name=" + name + "&password=" + encodePassword + "&sign=" + sign);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json;charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            JObject jsonObj = JObject.Parse(retString);
            string data = (string)jsonObj["data"];
            string decodeStr = DES.Decode(data, key);

            try
            {
                InformationJson information = JsonConvert.DeserializeObject<InformationJson>(decodeStr);
                sbmc.Text = information.sbmc ?? String.Empty;
                sywz.Text = information.sywz.ToString();
                cjz.Text = information.cjz.ToString();
                devtype.Text = information.devtype.ToString();
                //devno.Text = information.devno.ToString();
                yysl.Text = information.yysl.ToString();
                fwfs.Text = information.fwfs.ToString();
                syrq.Text = information.syrq.ToString();
                //fzr.Text = information.fzr.ToString();
                sybz.Text = information.sybz.ToString();
                cjzid.Text = information.cjzid.ToString();
                ip.Text = information.ip.ToString();
                memo.Text = information.memo.ToString();
                //inserttime.Text = information.inserttime.ToString();
                state.Text = information.state.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("未获取到设备信息");
            }


            //JObject jsonObj = JObject.Parse(retString);
            //sbmc.Text = (string)jsonObj["data"]["sbmc"];
            //sywz.Text = (string)jsonObj["data"]["sywz"];
            //cjz.Text = (string)jsonObj["data"]["cjz"];
            //devtype.Text = (string)jsonObj["data"]["devtype"];
            //devno.Text = (string)jsonObj["data"]["devno"];
            //yysl.Text = (string)jsonObj["data"]["yysl"];
            //fwfs.Text = (string)jsonObj["data"]["fwfs"];
            //syrq.Text = (string)jsonObj["data"]["syrq"];
            //fzr.Text = (string)jsonObj["data"]["fzr"];
            //sybz.Text = (string)jsonObj["data"]["sybz"];
            //cjzid.Text = (string)jsonObj["data"]["cjzid"];
            //ip.Text = (string)jsonObj["data"]["ip"];
            //memo.Text = (string)jsonObj["data"]["memo"];
            //inserttime.Text = (string)jsonObj["data"]["inserttime"];
            //state.Text = (string)jsonObj["data"]["state"];

        }
    }
}
