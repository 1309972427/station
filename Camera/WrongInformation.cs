using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camera
{
    public partial class WrongInformation : Form
    {

        string buttonText;
        public WrongInformation(string buttonText)
        {
            InitializeComponent();
            this.buttonText = buttonText;
        }

        private void WrongInformation_Load(object sender, EventArgs e)
        {
            if (buttonText == "限位故障")
            {
                label1.Text = "上限位故障";
                label2.Text = "下限位故障";
                label3.Text = "";
            }
            else if (buttonText == "运行故障")
            {
                label1.Text = "地震传感器信号故障";
                label2.Text = "轿顶检修开关损坏";
                label3.Text = "限速器开关卡阻或损坏";
                label4.Text = "接线错误";
            }
            else if (buttonText == "梯门故障")
            {
                label1.Text = "门锁故障";
                label2.Text = "门机问题无TSO信号";
                label3.Text = "门锁回路短接";
                label4.Text = "光幕损坏";
            }
            else if (buttonText == "非正常停梯")
            {
                label1.Text = "门锁触点虚接";
                label2.Text = "门簧片变形或深度有误";
                label3.Text = "接线错误";
            }
            else if (buttonText == "停梯检修")
            {
                label1.Text = "显示IF";
                label2.Text = "显示JU";
            }
            else if (buttonText == "错层故障")
            {
                label1.Text = "LK感应器损坏";
                label2.Text = "随行电缆损坏";
                label3.Text = "线路松动";
                label4.Text = "主板LK端口干扰损坏";
            }
            else if (buttonText == "电梯死机")
            {
                label1.Text = "CPU主板死机";
                label2.Text = "机房紧急电动转换开关接触不良";
                label3.Text = "轿顶检修开关接触不良";
                label4.Text = "MF3 X40检修端口干扰或损坏";
            }
            else if (buttonText == "通讯故障")
            {
                label1.Text = "线路总线端口故障";
                label2.Text = "CAN通讯干扰";
                label3.Text = "MF3接线错误";
                label4.Text = "网络故障";
            }
        }
    }
}
