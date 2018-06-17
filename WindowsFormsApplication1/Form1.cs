using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
using Camera;
using System.Data.OleDb;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private Control btnActivated = null;
        //private Control ifame = null;
        //右侧panel由上自下顺序
        //23 4 51 18 52


        private void AutoSizeColumn(DataGridView dgViewFiles)
        {
            int width = 0;
            //使列自使用宽度
            //对于DataGridView的每一个列都调整
            for (int i = 0; i < dgViewFiles.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dgViewFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += dgViewFiles.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > dgViewFiles.Size.Width)
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            dgViewFiles.Columns[1].Frozen = true;
        }

        string[] ids = new string[] { "SHJHXNJNVERVEL336", "SHJHXNJNVERVEL335", "SHJHXNJNVERVEL338", "SHJHXNJNVERVEL337", "SHJHXNJNVERVEL340", "SHJHXNJNVERVEL339", "SHJHXNJNVERVEL342",
 //           ,"SHJHXNJNVERVEL341","SHJHXNJNVERVEL344","SHJHXNJNVERVEL343",
 //"SHJHXNJNVERVEL346",
 //"SHJHXNJNVERVEL345",
 //"SHJHXNJNVERVEL348",
 //"SHJHXNJNVERVEL347",
 //"SHJHXNJNVERVEL350",
 //"SHJHXNJNVERVEL349",
 //"SHJHXNJNVERVEL352",
 //"SHJHXNJNVERVEL351",
 //"SHJHXNJNVERVEL354",
 //"SHJHXNJNVERVEL353",
 //"SHJHXNJNVERVEL356",
 //"SHJHXNJNVERVEL355",
 //"SHJHXNJNVERVEL358",
 //"SHJHXNJNVERVEL357",
 //"SHJHXNJNVERVEL360",
 //"SHJHXNJNVERVEL359",
 //"SHJHXNJNVERVEL332",
 //"SHJHXNJNVERVEL331",
 //"SHJHXNJNVERVEL327",
 //"SHJHXNJNVERVEL326",
 //"SHJHXNJNVERVEL330",
 //"SHJHXNJNVERVEL328",
 //"SHJHXNJNVERVEL361",
 //"SHJHXNJNVERVEL334",
 //"SHJHXNJNVERVEL333",
 "SHJHXNJNVERVEL329"};

        public Form1()
        {
            InitializeComponent();
            DataTable dt = getData().Tables[0];
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView4.DataSource = bs;


            DataTable dt2 = new DataTable();
            DataColumn dc1 = new DataColumn("设备id");
            DataColumn dc2 = new DataColumn("设备名称");
            DataColumn dc3 = new DataColumn("报修时间");
            DataColumn dc4 = new DataColumn("故障发生时间");
            DataColumn dc5 = new DataColumn("故障处理时间");
            DataColumn dc6 = new DataColumn("故障修复时间");
            DataColumn dc7 = new DataColumn("状态码");
            DataColumn dc8 = new DataColumn("故障处理进度");
            DataColumn dc9 = new DataColumn("故障描述");
            DataColumn dc10 = new DataColumn("故障呼叫人");
            DataColumn dc11 = new DataColumn("故障处理内容");

            dt2.Columns.Add(dc1);
            dt2.Columns.Add(dc2);
            dt2.Columns.Add(dc3);
            dt2.Columns.Add(dc4);
            dt2.Columns.Add(dc5);
            dt2.Columns.Add(dc6);
            dt2.Columns.Add(dc7);
            dt2.Columns.Add(dc8);
            dt2.Columns.Add(dc9);
            dt2.Columns.Add(dc10);
            dt2.Columns.Add(dc11);

            



            for (int i = 0, l = ids.Length; i < l; i++)
            {
                string res_one = retJson(ids[i]);

                JArray ja = (JArray)JsonConvert.DeserializeObject(res_one);

                foreach (var m in ja)
                {
                    DataRow dr = dt2.NewRow();
                    dr["设备id"] = m["deviceid"];
                    dr["设备名称"] = m["devicename"];
                    dr["报修时间"] = m["calltime"];
                    dr["故障发生时间"] = m["eventtime"];
                    dr["故障处理时间"] = m["happentime"];
                    dr["故障修复时间"] = m["tasktime"];
                    dr["状态码"] = m["code"];
                    dr["故障处理进度"] = m["message"];
                    dr["故障描述"] = m["problem"];
                    dr["故障呼叫人"] = m["caller"];
                    dr["故障处理内容"] = m["dealcontent"];
                    dt2.Rows.Add(dr);
                }
            }
            dataGridView2.DataSource = dt2;


            pictureBox16.Visible = false;


            //List<RecordJson> recordJsonList;
            //recordJsonList = new List<RecordJson>();
            //JsonSerializer serializer = new JsonSerializer();
            //StringReader sr = new StringReader(res_one);
            //recordJsonList = serializer.Deserialize(new JsonTextReader(sr), typeof(RecordJson)) as List<RecordJson>;



            //string sConnection = "Data Source=.;Initial Catalog=Demo;Integrated Security=True";
            //using (SqlConnection sqlConn = new SqlConnection(sConnection))
            //{
            //DataSet dsUsers = new DataSet();

            //string sCmdText = " select * from Demo1 ";
            //using (SqlDataAdapter sda = new SqlDataAdapter(sCmdText, sqlConn))
            //{
            //    sda.Fill(dsUsers, "info");
            //}

            //sCmdText = " select * from Demo2 ";
            //using (SqlDataAdapter sda = new SqlDataAdapter(sCmdText, sqlConn))
            //{
            //    sda.Fill(dsUsers, "info2");
            //}
            //sCmdText = " select * from Demo3 ";
            //using (SqlDataAdapter sda = new SqlDataAdapter(sCmdText, sqlConn))
            //{
            //    sda.Fill(dsUsers, "info3");
            //}
            //sCmdText = " select * from Demo4 ";
            //using (SqlDataAdapter sda = new SqlDataAdapter(sCmdText, sqlConn))
            //{
            //    sda.Fill(dsUsers, "info4");
            //}



            //dataGridView2.DataSource = dsUsers;
            //dataGridView2.DataMember = "info";

            //dataGridView3.DataSource = dsUsers;
            //dataGridView3.DataMember = "info2";







            Series series4 = chart4.Series[0];
            // 画样条曲线（Spline）
            series4.ChartType = SeriesChartType.Pie;
            //int b = dsUsers.Tables["info4"].Rows.Count;
            //int[] values4 = new int[b];
            //string[] values40 = new string[b];
            //b = 0; 
            //foreach (DataRow row in dsUsers.Tables["info4"].Rows)
            //{
            //    values4[b] = Convert.ToInt32(row["gailv"]);
            //    values40[b] = Convert.ToString(row["guzhang"]);
            //    b++;
            //}





            // 在chart中显示数据
            //int x4 = 0;
            //foreach (float v in values4)
            //{
            //    series4.LegendText = "#VALX";
            //    series4.Points.AddXY(values40[x4], v);
            //    x4++;
            //}
            //series4.Label = "#PERCENT{P}";
            ////chartpie.Series["Series1"].Label = "#PERCENT{P}";
            //series4.LabelForeColor = System.Drawing.Color.AliceBlue;
            //// 设置显示范围
            //ChartArea chartArea4 = chart4.ChartAreas[0];
            //chartArea4.AxisX.Minimum = 0;
            //chartArea4.AxisX.Maximum = 10;
            //chartArea4.AxisY.Minimum = 0d;
            //chartArea4.AxisY.Maximum = 100d;














            //int i = dsUsers.Tables["info3"].Rows.Count;
            //int[] values5 = new int[i];
            //i = 0;
            //foreach (DataRow row in dsUsers.Tables["info3"].Rows)
            //{
            //        values5[i] = Convert.ToInt32(row["moonint"]);
            //        i++;          
            //}
            //Series series5 = chart5.Series[0];
            //// 画样条曲线（Spline）
            //series5.ChartType = SeriesChartType.Line;
            //// 线宽2个像素
            //series5.BorderWidth = 1;
            //// 线的颜色：红色
            //series5.Color = System.Drawing.Color.Blue;
            //// 图示上的文字
            //series5.LegendText = "各月份故障率分析";
            //// 在chart中显示数据
            //int x5 = 1;
            //foreach (int v in values5)
            //{
            //    series5.Points.AddXY(x5, v);
            //    x5++;
            //}
            //series5.Label = "#VALY";
            //// 设置显示范围
            //ChartArea chartArea5 = chart5.ChartAreas[0];
            //chartArea5.AxisX.Minimum = 1;
            //chartArea5.AxisX.Maximum = 12;
            //chartArea5.AxisY.Minimum = 0d;
            //chartArea5.AxisY.Maximum = 100d;




            //}
            //dataGridView2.Columns[0].Width = 180;
            //dataGridView2.Columns[1].Width = 180;
            //dataGridView2.Columns[2].Width = 180;
            //dataGridView2.Columns[3].Width = 180;
            //dataGridView2.Columns[4].Width = 180;
            //dataGridView2.Columns[5].Width = 180;

            //dataGridView3.Columns[0].Width = 180;
            //dataGridView3.Columns[1].Width = 180;
            //dataGridView3.Columns[2].Width = 180;
            //dataGridView3.Columns[3].Width = 180;
            //dataGridView3.Columns[4].Width = 180;
            //dataGridView3.Columns[5].Width = 180;


            //Series series4 = chart4.Series[0];
            //// 画样条曲线（Spline）
            //series4.ChartType = SeriesChartType.Pie;
            //// 线宽2个像素
            //series4.BorderWidth = 2;
            //// 线的颜色：红色
            //series4.Color = System.Drawing.Color.Red;
            //// 图示上的文字
            ////series4.LegendText = "121";
            ////chart4.Series[0].XValueMember = "121";
            //float[] values14 = { 95, 30, 20, 23, 60, 87, 42, 77, 92, 51, 29 };
            ////series4.LegendText = "222";


            //// 准备数据 
            //float[] values4 = { 95, 30, 20, 23, 60, 87, 42, 77, 92, 51, 29 };

            //// 在chart中显示数据
            //int x4 = 0;
            //foreach (float v in values4)
            //{
            //    series4.Points.AddXY(x3, v);
            //    x4++;
            //}

            //// 设置显示范围
            //ChartArea chartArea4 = chart4.ChartAreas[0];
            //chartArea4.AxisX.Minimum = 0;
            //chartArea4.AxisX.Maximum = 10;
            //chartArea4.AxisY.Minimum = 0d;
            //chartArea4.AxisY.Maximum = 100d;





        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Load elevator status page
            elevatorInfoBrowser.DocumentText = Properties.Resources.status.Replace("_ECHARTS_JS_PLACEHOLDER_", Properties.Resources.echarts_min);


            LoadElevatorStatusWeb();

            // TODO:  这行代码将数据加载到表“demoDataSet1.Demo1”中。您可以根据需要移动或删除它。
            //this.demo1TableAdapter1.Fill(this.demoDataSet1.Demo1);
            //// TODO:  这行代码将数据加载到表“demoDataSet.Demo1”中。您可以根据需要移动或删除它。
            //this.demo1TableAdapter.Fill(this.demoDataSet.Demo1);  
            //    dataGridView1.Rows[0].Cells[4].Style.BackColor = Color.Blue;
            //    dataGridView1.Rows[0].Cells[4].ReadOnly = true;

            //// TODO:  这行代码将数据加载到表“jHQzxSystemDBDataSet1.Goods”中。您可以根据需要移动或删除它。
            //this.goodsTableAdapter.Fill(this.jHQzxSystemDBDataSet1.Goods);
            //// TODO:  这行代码将数据加载到表“jHQzxSystemDBDataSet1.Goods”中。您可以根据需要移动或删除它。
            //this.goodsTableAdapter.Fill(this.jHQzxSystemDBDataSet1.Goods);
            //// TODO:  这行代码将数据加载到表“jHQzxSystemDBDataSet.SystemRoleRight”中。您可以根据需要移动或删除它。
            //this.systemRoleRightTableAdapter.Fill(this.jHQzxSystemDBDataSet.SystemRoleRight);
            //// TODO:  这行代码将数据加载到表“jHQzxSystemDBDataSet.Goods”中。您可以根据需要移动或删除它。
            //this.goodsTableAdapter.Fill(this.jHQzxSystemDBDataSet.Goods);
            //// TODO:  这行代码将数据加载到表“jHQzxSystemDBDataSet.Customer”中。您可以根据需要移动或删除它。
            //this.customerTableAdapter.Fill(this.jHQzxSystemDBDataSet.Customer);
            //// TODO:  这行代码将数据加载到表“jHQzxSystemDBDataSet.View_Notice”中。您可以根据需要移动或删除它。
            //this.view_NoticeTableAdapter.Fill(this.jHQzxSystemDBDataSet.View_Notice);

            //asc.controllInitializeSize(this);
            //// TODO:  这行代码将数据加载到表“jHQzxSystemDBDataSet.SystemRole”中。您可以根据需要移动或删除它。
            //this.systemRoleTableAdapter.Fill(this.jHQzxSystemDBDataSet.SystemRole);


            //// TODO:  这行代码将数据加载到表“jHQzxSystemDBDataSet.View_SystemUser”中。您可以根据需要移动或删除它。
            //this.view_SystemUserTableAdapter.Fill(this.jHQzxSystemDBDataSet.View_SystemUser);
            //// TODO:  这行代码将数据加载到表“jHQzxSystemDBDataSet.Notice”中。您可以根据需要移动或删除它。
            //this.noticeTableAdapter.Fill(this.jHQzxSystemDBDataSet.Notice);
            //// TODO:  这行代码将数据加载到表“jHQzxSystemDBDataSet.SystemUser”中。您可以根据需要移动或删除它。
            //this.systemUserTableAdapter.Fill(this.jHQzxSystemDBDataSet.SystemUser);
            //ifame = panel23;
            btnActivated = panel8;

            //dataGridView1.ShowCellErrors = true;
            //dataGridView1[3, 3].ErrorText = "错误信息";

            this.WindowState = FormWindowState.Maximized;
            System.Drawing.Rectangle rect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            int h = rect.Height;
            int w = rect.Width;
            panel3.Height = h;
            //panel4.Width = w;
            //panel4.Height = h;
            panel5.Width = w;
            panel6.Width = w;
            panel7.Width = w - 163;
            panel51.Width = w - 163;
            panel51.Height = h;
            panel60.Width = w - 163;
            tableLayoutPanel15.Width = w;
            //dataGridView2.Width = w-100;
            dataGridView2.Height = h;
            dataGridView3.Height = h;
            tableLayoutPanel25.Width = w - 163;
            tableLayoutPanel32.Width = w - 163;
            dataGridView1.Width = w;
            //int w12 = tableLayoutPanel4.Parent.Width;
            //tableLayoutPanel4.Width =(int)Math.Floor(w12 * 0.7);


            //LoadElevatorItemsInfo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button9_MouseHover(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel5.ClientRectangle,
            Color.White, 0, ButtonBorderStyle.Solid, //左边
            Color.White, 0, ButtonBorderStyle.Solid, //上边
            Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
            Color.FromArgb(86, 109, 156), 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel6.ClientRectangle,
            Color.White, 0, ButtonBorderStyle.Solid, //左边
            Color.White, 0, ButtonBorderStyle.Solid, //上边
            Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
            Color.FromArgb(115, 134, 173), 1, ButtonBorderStyle.Solid);//底边
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        //private void pictureBox12_MouseEnter(object sender, EventArgs e)
        //{
        //    pictureBox12.BackColor = Color.FromArgb(49, 78, 126);
        //    label18.BackColor = Color.FromArgb(49, 78, 126);
        //    //label18.ForeColor = Color.Black;
        //}

        private void label18_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Click(object sender, EventArgs e)
        {

        }

        private void panel8_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            if (panel8.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel8.BackColor = Color.FromArgb(86, 109, 156);
            }

        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            if (panel8.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel8.BackColor = Color.FromArgb(56, 83, 138);
            }
        }

        private void panel11_MouseEnter(object sender, EventArgs e)
        {
            if (panel11.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel11.BackColor = Color.FromArgb(86, 109, 156);
            }

        }

        private void panel11_MouseLeave(object sender, EventArgs e)
        {
            if (panel11.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel11.BackColor = Color.FromArgb(56, 83, 138);
            }
        }

        private void panel13_MouseEnter(object sender, EventArgs e)
        {
            if (panel13.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel13.BackColor = Color.FromArgb(86, 109, 156);
            }
        }

        private void panel13_MouseLeave(object sender, EventArgs e)
        {
            if (panel13.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel13.BackColor = Color.FromArgb(56, 83, 138);
            }

        }

        //private void panel15_MouseEnter(object sender, EventArgs e)
        //{
        //    if (panel15.BackColor == Color.FromArgb(19, 35, 61))
        //    {

        //    }
        //    else
        //    {
        //        panel15.BackColor = Color.FromArgb(86, 109, 156);
        //    }
        //}

        //private void panel15_MouseLeave(object sender, EventArgs e)
        //{
        //    if (panel15.BackColor == Color.FromArgb(19, 35, 61))
        //    {

        //    }
        //    else
        //    {
        //        panel15.BackColor = Color.FromArgb(56, 83, 138);
        //    }
        //}

        private void panel17_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel6.ClientRectangle,
           Color.White, 0, ButtonBorderStyle.Solid, //左边
           Color.White, 0, ButtonBorderStyle.Solid, //上边
           Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
           Color.DimGray, 1, ButtonBorderStyle.Solid);//底边
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel28_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel28.ClientRectangle,
            Color.White, 0, ButtonBorderStyle.Solid, //左边
            Color.White, 0, ButtonBorderStyle.Solid, //上边
            Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
            Color.FromArgb(86, 109, 156), 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel29.ClientRectangle,
            Color.White, 0, ButtonBorderStyle.Solid, //左边
            Color.FromArgb(115, 134, 173), 1, ButtonBorderStyle.Solid, //上边
            Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
            Color.FromArgb(115, 134, 173), 1, ButtonBorderStyle.Solid);//底边
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel36_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel36_MouseEnter(object sender, EventArgs e)
        {
            //if (panel36.BackColor == Color.FromArgb(19, 35, 61))
            //{

            //}
            //else
            //{
            //    panel36.BackColor = Color.FromArgb(86, 109, 156);
            //}
        }
        //panel点击控制颜色
        private void panel36_Click(object sender, EventArgs e)
        {

            Control btnClicked = sender as Panel;
            if (btnClicked.BackColor == Color.FromArgb(86, 109, 156))
            {
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked.Controls[0].Visible = true;
                btnClicked.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked;


            }
            else
            {

            }


        }

        private void panel34_Click(object sender, EventArgs e)
        {

        }

        private void panel36_MouseLeave(object sender, EventArgs e)
        {
            //if (panel36.BackColor == Color.FromArgb(19, 35, 61))
            //{

            //}
            //else
            //{
            //    panel36.BackColor = Color.FromArgb(56, 83, 138);
            //}
        }

        private void panel34_MouseEnter(object sender, EventArgs e)
        {
            if (panel34.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel34.BackColor = Color.FromArgb(86, 109, 156);
            }
        }

        private void panel34_MouseLeave(object sender, EventArgs e)
        {
            if (panel34.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel34.BackColor = Color.FromArgb(56, 83, 138);
            }
        }

        //private void panel32_MouseEnter(object sender, EventArgs e)
        //{
        //    if (panel32.BackColor == Color.FromArgb(19, 35, 61))
        //    {

        //    }
        //    else
        //    {
        //        panel32.BackColor = Color.FromArgb(86, 109, 156);
        //    }
        //}

        //private void panel32_MouseLeave(object sender, EventArgs e)
        //{
        //    if (panel32.BackColor == Color.FromArgb(19, 35, 61))
        //    {

        //    }
        //    else
        //    {
        //        panel32.BackColor = Color.FromArgb(56, 83, 138);
        //    }
        //}

        private void panel30_MouseEnter(object sender, EventArgs e)
        {
            if (panel30.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel30.BackColor = Color.FromArgb(86, 109, 156);
            }
        }

        private void panel30_MouseLeave(object sender, EventArgs e)
        {
            if (panel30.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel30.BackColor = Color.FromArgb(56, 83, 138);
            }
        }

        private void panel46_MouseEnter(object sender, EventArgs e)
        {
            if (panel46.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel46.BackColor = Color.FromArgb(86, 109, 156);
            }
        }

        private void panel46_MouseLeave(object sender, EventArgs e)
        {
            if (panel46.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel46.BackColor = Color.FromArgb(56, 83, 138);
            }
        }

        private void panel44_MouseEnter(object sender, EventArgs e)
        {
            if (panel44.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel44.BackColor = Color.FromArgb(86, 109, 156);
            }
        }

        private void panel44_MouseLeave(object sender, EventArgs e)
        {
            if (panel44.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel44.BackColor = Color.FromArgb(56, 83, 138);
            }
        }

        private void panel42_MouseEnter(object sender, EventArgs e)
        {
            if (panel42.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel42.BackColor = Color.FromArgb(86, 109, 156);
            }
        }

        private void panel42_MouseLeave(object sender, EventArgs e)
        {
            if (panel42.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel42.BackColor = Color.FromArgb(56, 83, 138);
            }
        }

        private void panel40_MouseEnter(object sender, EventArgs e)
        {
            if (panel40.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel40.BackColor = Color.FromArgb(86, 109, 156);
            }
        }

        private void panel40_MouseLeave(object sender, EventArgs e)
        {
            if (panel40.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel40.BackColor = Color.FromArgb(56, 83, 138);
            }
        }

        private void panel32_Click(object sender, EventArgs e)
        {

        }

        private void panel48_MouseEnter(object sender, EventArgs e)
        {
            if (panel48.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel48.BackColor = Color.FromArgb(86, 109, 156);
            }

        }

        private void panel48_MouseLeave(object sender, EventArgs e)
        {
            if (panel48.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel48.BackColor = Color.FromArgb(56, 83, 138);
            }

        }
        //label点击控制颜色
        private void label24_Click(object sender, EventArgs e)
        {
            Control btnClicked3 = sender as Label;
            //if (btnClicked3.Parent.BackColor == Color.FromArgb(19, 35, 61))
            //{

            //}
            //else
            //{
            //    btnActivated.BackColor = Color.FromArgb(56, 83, 138);
            //    btnClicked3.Parent.BackColor = Color.FromArgb(19, 35, 61); ;
            //    btnClicked3.Parent.Controls[0].Visible = true;
            //    btnClicked3.Parent.Controls[1].ForeColor = Color.White;
            //    btnActivated.Controls[0].Visible = false;
            //    btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
            //    btnActivated = btnClicked3.Parent;
            //}

            if (btnClicked3.Parent.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel27.Visible = false;


                panel51.Visible = false;
                panel4.Visible = true;
                panel18.Visible = false;
                panel52.Visible = false;
                panel23.Visible = false;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked3.Parent.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked3.Parent.Controls[0].Visible = true;
                btnClicked3.Parent.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked3.Parent;
            }
        }

        private void label24_Click_1(object sender, EventArgs e)
        {
            Control btnClicked3 = sender as Label;
            if (btnClicked3.Parent.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {

                panel27.Visible = false;



                panel51.Visible = true;
                panel52.Visible = false;
                panel18.Visible = false;
                panel23.Visible = false;
                panel4.Visible = false;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked3.Parent.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked3.Parent.Controls[0].Visible = true;
                btnClicked3.Parent.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked3.Parent;
            }
        }

        private void label24_MouseEnter_1(object sender, EventArgs e)
        {

        }
        //label移入控制颜色
        private void label24_MouseEnter(object sender, EventArgs e)
        {
            Control btnClicked2 = sender as Label;
            if (btnClicked2.Parent.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                btnClicked2.Parent.BackColor = Color.FromArgb(86, 109, 156);
            }
        }

        private void panel29_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel29.ClientRectangle,
           Color.White, 0, ButtonBorderStyle.Solid, //左边
           Color.FromArgb(86, 109, 156), 1, ButtonBorderStyle.Solid, //上边
           Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
           Color.FromArgb(86, 109, 156), 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel39_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel39.ClientRectangle,
           Color.White, 0, ButtonBorderStyle.Solid, //左边
           Color.FromArgb(86, 109, 156), 1, ButtonBorderStyle.Solid, //上边
           Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
           Color.FromArgb(86, 109, 156), 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel8_Click_1(object sender, EventArgs e)
        {

            Control btnClicked = sender as Panel;
            if (btnClicked.BackColor == Color.FromArgb(86, 109, 156))
            {
                panel27.Visible = false;


                panel51.Visible = false;
                panel52.Visible = false;
                panel18.Visible = false;
                panel23.Visible = true;
                panel4.Visible = false;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked.Controls[0].Visible = true;
                btnClicked.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked;
            }
            else
            {

            }
        }

        private void panel11_Click_1(object sender, EventArgs e)
        {
            label1.Text = "当前位置：电梯运行管理 >> 电梯故障管理";
            label1.Visible = true;
            panel7.Visible = true;
            elevatorInfoBrowser.Visible = false;
            Control btnClicked = sender as Panel;
            if (btnClicked.BackColor == Color.FromArgb(86, 109, 156))
            {
                panel27.Visible = false;


                panel51.Visible = false;
                panel52.Visible = false;
                panel18.Visible = false;
                panel23.Visible = false;
                panel4.Visible = true;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked.Controls[0].Visible = true;
                btnClicked.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked;

                dataGridView2.Visible = true;
            }
            else
            {

            }
        }

        private void label24_Click_2(object sender, EventArgs e)
        {
            Control btnClicked3 = sender as Label;
            if (btnClicked3.Parent.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {

                panel27.Visible = false;

                panel51.Visible = false;
                panel23.Visible = true;
                panel18.Visible = false;
                panel4.Visible = false;
                panel52.Visible = false;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked3.Parent.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked3.Parent.Controls[0].Visible = true;
                btnClicked3.Parent.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked3.Parent;
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Click_1(object sender, EventArgs e)
        {

            Control btnClicked = sender as Panel;
            if (btnClicked.BackColor == Color.FromArgb(86, 109, 156))
            {
                panel27.Visible = false;


                panel51.Visible = true;
                panel52.Visible = false;
                panel18.Visible = false;
                panel23.Visible = false;
                panel4.Visible = false;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked.Controls[0].Visible = true;
                btnClicked.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked;
            }
            else
            {

            }
        }

        private void label26_Click(object sender, EventArgs e)
        {
            Control btnClicked3 = sender as Label;
            if (btnClicked3.Parent.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel27.Visible = false;


                panel51.Visible = true;
                panel52.Visible = false;
                panel18.Visible = false;
                panel23.Visible = false;
                panel4.Visible = false;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked3.Parent.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked3.Parent.Controls[0].Visible = true;
                btnClicked3.Parent.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked3.Parent;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, panel3.ClientRectangle,
            Color.White, 0, ButtonBorderStyle.Solid, //左边
            Color.FromArgb(115, 134, 173), 0, ButtonBorderStyle.Solid, //上边
            Color.FromArgb(61, 77, 104), 1, ButtonBorderStyle.Solid, //右边
            Color.FromArgb(115, 134, 173), 0, ButtonBorderStyle.Solid);//底边
        }

        private void label26_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Label;
            if (btnClicked5.Parent.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                btnClicked5.Parent.BackColor = Color.FromArgb(56, 83, 138);
            }
        }

        private void panel50_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            dataGridView1.RowHeadersWidth = 60;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int j = i + 1;
                dataGridView1.Rows[i].HeaderCell.Value = j.ToString();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            System.Drawing.Rectangle rect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            int h = rect.Height;
            int w = rect.Width;
            int ww = this.Width;
            int hh = this.Height;
            asc.controllInitializeSize(this);

        }

        private void panel51_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.goodsTableAdapter.FillBy(this.jHQzxSystemDBDataSet.Goods);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void panel50_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel36_Click_1(object sender, EventArgs e)
        {
            Control btnClicked = sender as Panel;
            if (btnClicked.BackColor == Color.FromArgb(86, 109, 156))
            {
                panel51.Visible = false;
                panel52.Visible = true;
                panel18.Visible = false;
                panel23.Visible = false;
                panel4.Visible = false;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked.Controls[0].Visible = true;
                btnClicked.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked;
                //panel52.Parent.Visible = true;
            }
            else
            {

            }
        }

        private void panel53_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel53.ClientRectangle,
            Color.White, 0, ButtonBorderStyle.Solid, //左边
            Color.FromArgb(115, 134, 173), 0, ButtonBorderStyle.Solid, //上边
            Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
            Color.FromArgb(64, 82, 122), 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel54_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel54.ClientRectangle,
            Color.White, 0, ButtonBorderStyle.Solid, //左边
            Color.FromArgb(115, 134, 173), 0, ButtonBorderStyle.Solid, //上边
            Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
            Color.FromArgb(64, 82, 122), 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel55_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel55.ClientRectangle,
            Color.White, 0, ButtonBorderStyle.Solid, //左边
            Color.FromArgb(115, 134, 173), 0, ButtonBorderStyle.Solid, //上边
            Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
            Color.FromArgb(64, 82, 122), 1, ButtonBorderStyle.Solid);//底边
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex >= 0)//要进行重绘的单元格
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 255, 255);
                e.CellStyle.ForeColor = Color.FromArgb(19, 35, 61);
                e.CellStyle.SelectionBackColor = Color.FromArgb(135, 172, 246);
            }
            if (e.ColumnIndex > -2 && e.ColumnIndex < 0 && e.RowIndex >= -1)//要进行重绘的单元格
            {
                e.CellStyle.BackColor = Color.FromArgb(227, 230, 236);
                e.CellStyle.ForeColor = Color.FromArgb(19, 35, 61);
                e.CellStyle.SelectionBackColor = Color.FromArgb(135, 172, 246);
            }
            if (e.ColumnIndex > -2 && e.RowIndex < 0 && e.RowIndex >= -1)//要进行重绘的单元格
            {
                e.CellStyle.BackColor = Color.FromArgb(227, 230, 236);
                e.CellStyle.ForeColor = Color.FromArgb(19, 35, 61);
                e.CellStyle.SelectionBackColor = Color.FromArgb(135, 172, 246);
            }
        }

        private void label64_Click(object sender, EventArgs e)
        {
            Control btnClicked3 = sender as Label;
            if (btnClicked3.Parent.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel51.Visible = false;
                panel52.Visible = true;
                panel18.Visible = false;
                panel23.Visible = false;
                panel4.Visible = false;
                //panel52.Parent.Visible = true;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked3.Parent.BackColor = Color.FromArgb(19, 35, 61);
                btnClicked3.Parent.Controls[0].Visible = true;
                btnClicked3.Parent.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked3.Parent;
            }
        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void panel57_MouseEnter(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Panel;
            btnClicked5.BackColor = Color.FromArgb(255, 212, 77);
        }

        private void panel57_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Panel;
            btnClicked5.BackColor = Color.FromArgb(80, 148, 221);
        }

        //private void panel58_MouseEnter(object sender, EventArgs e)
        //{
        //    panel58.BackColor = Color.FromArgb(97,255,96);
        //}

        private void panel58_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Panel;
            btnClicked5.BackColor = Color.FromArgb(2, 248, 0);

        }

        //private void panel25_MouseEnter(object sender, EventArgs e)
        //{
        //    panel25.BackColor = Color.FromArgb(255,60,60);
        //}

        private void panel25_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Panel;
            btnClicked5.BackColor = Color.FromArgb(255, 34, 34);
        }

        //private void panel61_MouseEnter(object sender, EventArgs e)
        //{
        //    panel61.BackColor = Color.FromArgb(205, 205, 205);
        //}

        private void panel61_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Panel;
            btnClicked5.BackColor = Color.FromArgb(192, 192, 192);
        }

        private void label52_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Label;
            if (btnClicked5.Parent.BackColor == Color.FromArgb(101, 161, 225))
            {

            }
            else
            {
                btnClicked5.Parent.BackColor = Color.FromArgb(80, 148, 221);
            }
        }

        private void tableLayoutPanel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel6.ClientRectangle,
            Color.White, 0, ButtonBorderStyle.Solid, //左边
            Color.White, 0, ButtonBorderStyle.Solid, //上边
            Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
            Color.FromArgb(64, 82, 122), 1, ButtonBorderStyle.Solid);//底边
        }

        private void label57_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panel74_Paint(object sender, PaintEventArgs e)
        {
            //    ControlPaint.DrawBorder(e.Graphics, panel74.ClientRectangle,
            //Color.FromArgb(128, 255, 255), 0, ButtonBorderStyle.Solid, //左边
            //Color.FromArgb(128, 255, 255), 0, ButtonBorderStyle.Solid, //上边
            //Color.FromArgb(128, 255, 255), 0, ButtonBorderStyle.Solid, //右边
            //Color.FromArgb(42, 160, 205), 2, ButtonBorderStyle.Solid);//底边
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel4.ClientRectangle,
            Color.White, 0, ButtonBorderStyle.Solid, //左边
            Color.White, 0, ButtonBorderStyle.Solid, //上边
            Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
            Color.FromArgb(128, 255, 255), 2, ButtonBorderStyle.Solid);//底边
        }

        private void label8_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label8.ClientRectangle,
            Color.White, 0, ButtonBorderStyle.Solid, //左边
            Color.White, 0, ButtonBorderStyle.Solid, //上边
            Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
            Color.FromArgb(0, 230, 217), 2, ButtonBorderStyle.Solid);//底边
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            Control btnClicked = sender as Label;
            btnClicked.Parent.BackColor = Color.FromArgb(0, 230, 217);
            btnClicked.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked = sender as Label;
            btnClicked.Parent.BackColor = Color.FromArgb(25, 46, 80);
            btnClicked.ForeColor = Color.FromArgb(215, 228, 242);
        }

        private void label6_MouseEnter_1(object sender, EventArgs e)
        {
            Control btnClicked = sender as Label;
            btnClicked.BackColor = Color.White;
            btnClicked.ForeColor = Color.Black;
        }

        private void label17_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label17_MouseEnter(object sender, EventArgs e)
        {
            Control btnClicked = sender as Label;
            btnClicked.BackColor = Color.Red;
        }

        private void label17_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked = sender as Label;
            btnClicked.BackColor = Color.Transparent;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked = sender as Label;
            btnClicked.BackColor = Color.Transparent;
            btnClicked.ForeColor = Color.White;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex >= 0)//要进行重绘的单元格
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 255, 255);
                e.CellStyle.ForeColor = Color.FromArgb(19, 35, 61);
                e.CellStyle.SelectionBackColor = Color.FromArgb(135, 172, 246);
            }
            if (e.ColumnIndex > -2 && e.ColumnIndex < 0 && e.RowIndex >= -1)//要进行重绘的单元格
            {
                e.CellStyle.BackColor = Color.FromArgb(227, 230, 236);
                e.CellStyle.ForeColor = Color.FromArgb(19, 35, 61);
                e.CellStyle.SelectionBackColor = Color.FromArgb(135, 172, 246);
            }
            if (e.ColumnIndex > -2 && e.RowIndex < 0 && e.RowIndex >= -1)//要进行重绘的单元格
            {
                e.CellStyle.BackColor = Color.FromArgb(227, 230, 236);
                e.CellStyle.ForeColor = Color.FromArgb(19, 35, 61);
                e.CellStyle.SelectionBackColor = Color.FromArgb(135, 172, 246);
            }
        }

        private void panel48_Click(object sender, EventArgs e)
        {
            Control btnClicked = sender as Panel;
            if (btnClicked.BackColor == Color.FromArgb(86, 109, 156))
            {
                panel51.Visible = false;
                panel52.Visible = false;
                panel18.Visible = true;
                panel23.Visible = false;
                panel4.Visible = false;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked.Controls[0].Visible = true;
                btnClicked.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked;


            }
            else
            {

            }
        }

        private void label70_Click(object sender, EventArgs e)
        {
            Control btnClicked3 = sender as Label;
            if (btnClicked3.Parent.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel51.Visible = false;
                panel4.Visible = false;
                panel18.Visible = true;
                panel52.Visible = false;
                panel23.Visible = false;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked3.Parent.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked3.Parent.Controls[0].Visible = true;
                btnClicked3.Parent.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked3.Parent;
            }
        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }

        private void label52_MouseEnter(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Label;
            btnClicked5.Parent.BackColor = Color.FromArgb(255, 212, 77);
        }

        private void panel57_Click(object sender, EventArgs e)
        {
            //realview form2 = new realview();
            //form2.ShowDialog();

            new realview().login();

        }

        private void panel57_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel79_Paint(object sender, PaintEventArgs e)
        {
            Control yihao = sender as Label;

        }

        private void panel58_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label59_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label59.ClientRectangle,
           Color.White, 0, ButtonBorderStyle.Solid, //左边
           Color.White, 0, ButtonBorderStyle.Solid, //上边
           Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
           Color.FromArgb(0, 230, 217), 2, ButtonBorderStyle.Solid);//底边
        }

        private void tableLayoutPanel15_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, tableLayoutPanel15.ClientRectangle,
       Color.Gray, 0, ButtonBorderStyle.Solid, //左边
       Color.Gray, 0, ButtonBorderStyle.Solid, //上边
       Color.Gray, 0, ButtonBorderStyle.Solid, //右边
       Color.FromArgb(64, 82, 122), 1, ButtonBorderStyle.Solid);//底边
        }

        private void label21_Paint(object sender, PaintEventArgs e)
        {
            //  ControlPaint.DrawBorder(e.Graphics, label21.ClientRectangle,
            //Color.White, 0, ButtonBorderStyle.Solid, //左边
            //Color.White, 0, ButtonBorderStyle.Solid, //上边
            //Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
            //Color.FromArgb(0, 230, 217),0, ButtonBorderStyle.Solid);//底边
            ControlPaint.DrawBorder(e.Graphics, label21.ClientRectangle,
         Color.Gray, 1, ButtonBorderStyle.Solid, //左边
         Color.Gray, 1, ButtonBorderStyle.Solid, //上边
         Color.Gray, 1, ButtonBorderStyle.Solid, //右边
         Color.Gray, 1, ButtonBorderStyle.Solid);//底边
        }

        private void label21_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panel63_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void label46_MouseEnter(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Label;
            btnClicked5.Parent.BackColor = Color.FromArgb(255, 212, 77);
        }

        private void label46_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Label;
            btnClicked5.Parent.BackColor = Color.FromArgb(80, 148, 221);

        }

        private void label50_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Label;
            btnClicked5.Parent.BackColor = Color.FromArgb(2, 248, 0);
        }

        private void label48_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Label;
            btnClicked5.Parent.BackColor = Color.FromArgb(255, 34, 34);
        }

        private void label78_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked5 = sender as Label;
            btnClicked5.Parent.BackColor = Color.Silver;
        }

        private DataSet getData()
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=dianti.xlsx;" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            string sql_select = "SELECT * FROM [Sheet1$]";
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                using (OleDbDataAdapter cmd = new OleDbDataAdapter(sql_select, conn))
                {
                    cmd.Fill(ds);

                }
            }

            return ds;

        }

        private void label60_Click(object sender, EventArgs e)
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=shexiangtou.xlsx;" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            string sql_select = "SELECT * FROM [Sheet1$]";
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                using (OleDbDataAdapter cmd = new OleDbDataAdapter(sql_select, conn))
                {
                    cmd.Fill(ds);

                }
            }
            dataGridView4.DataSource = ds.Tables[0];
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void label59_Click(object sender, EventArgs e)
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=dianti.xlsx;" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            string sql_select = "SELECT * FROM [Sheet1$]";
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                using (OleDbDataAdapter cmd = new OleDbDataAdapter(sql_select, conn))
                {
                    cmd.Fill(ds);

                }
            }
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView4.DataSource = ds.Tables[0];

        }

        private void label74_Click(object sender, EventArgs e)
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=duijiang.xlsx;" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            string sql_select = "SELECT * FROM [Sheet1$]";
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                using (OleDbDataAdapter cmd = new OleDbDataAdapter(sql_select, conn))
                {
                    cmd.Fill(ds);

                }
            }
            dataGridView4.DataSource = ds.Tables[0];
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click_2(object sender, EventArgs e)
        {
            panel16_Click(panel16, null);
        }

        private void menu_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel.BackColor = Color.FromArgb(86, 109, 156);
            }
        }

        private void menu_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                panel.BackColor = Color.FromArgb(56, 83, 138);
            }
        }

        private void menuLabel_MouseEnter(object sender, EventArgs e)
        {
            Control menuLabel = sender as Label;
            if (menuLabel.Parent.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                menuLabel.Parent.BackColor = Color.FromArgb(86, 109, 156);
            }
        }

        private void menuLabel_MouseLeave(object sender, EventArgs e)
        {
            Control menuLabel = sender as Label;
            if (menuLabel.Parent.BackColor == Color.FromArgb(19, 35, 61))
            {

            }
            else
            {
                menuLabel.Parent.BackColor = Color.FromArgb(56, 83, 138);
            }
        }

        private void panel34_Click_1(object sender, EventArgs e)
        {
            label1.Text = "当前位置：电梯信息管理 >> 电梯维保管理";
            label1.Visible = true;
            panel7.Visible = true;
            elevatorInfoBrowser.Visible = false;
            Control btnClicked = sender as Panel;
            if (btnClicked.BackColor == Color.FromArgb(86, 109, 156))
            {
                panel27.Visible = false;


                panel51.Visible = false;
                panel52.Visible = false;
                panel18.Visible = false;
                panel23.Visible = false;
                panel4.Visible = true;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked.Controls[0].Visible = true;
                btnClicked.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked;

                dataGridView2.Visible = true;
            }
            else
            {

            }
        }

        private void panel16_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel7.Visible = false;
            label1.Text = "当前位置：电梯信息管理 >> 运行统计分析";
            label1.Visible = true;
            elevatorInfoBrowser.Visible = true;
            Control btnClicked = sender as Panel;
            if (btnClicked.BackColor == Color.FromArgb(86, 109, 156))
            {
                panel27.Visible = false;


                panel51.Visible = false;
                panel52.Visible = false;
                panel18.Visible = false;
                panel23.Visible = false;
                panel4.Visible = true;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked.Controls[0].Visible = true;
                btnClicked.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked;

                dataGridView2.Visible = false;
            }
            else
            {

            }
        }

        private void panel30_Click(object sender, EventArgs e)
        {
            label1.Text = "当前位置：电梯信息管理 >> 基本信息管理";
            label1.Visible = true;
            Control btnClicked = sender as Panel;
            if (btnClicked.BackColor == Color.FromArgb(86, 109, 156))
            {
                panel27.Visible = false;


                panel51.Visible = true;
                panel52.Visible = false;
                panel18.Visible = false;
                panel23.Visible = false;
                panel4.Visible = false;
                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked.BackColor = Color.FromArgb(19, 35, 61); ;
                btnClicked.Controls[0].Visible = true;
                btnClicked.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);
                btnActivated = btnClicked;
            }
            else
            {

            }
        }

        private string retJson(string deviceId)
        {
            string key = "jsyljsyl";
            string name = "STDZ";
            string password = "JSYLST12" + DateTime.Now.ToString("yyyyMMddHHmm");
            string encodePassword = DES.Encode(password, key);

            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string pastTime = DateTime.Now.AddMonths(-3).ToString("yyyyMMddHHmmss");

            string strToSign = JsonConvert.SerializeObject(new
            {
                deviceid = deviceId,
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


            return decodeStr;
        }


        private string retJson(string deviceId, string timeStart, string timeEnd)
        {
            string key = "jsyljsyl";
            string name = "STDZ";
            string password = "JSYLST12" + DateTime.Now.ToString("yyyyMMddHHmm");
            string encodePassword = DES.Encode(password, key);

            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string pastTime = DateTime.Now.AddMonths(-3).ToString("yyyyMMddHHmmss");

            string strToSign = JsonConvert.SerializeObject(new
            {
                deviceid = deviceId,
                datestart = DateTime.Parse(timeStart).ToString("yyyyMMddHHmmss"),
                dateend = DateTime.Parse(timeEnd).ToString("yyyyMMddHHmmss"),
            });
            string sign = DES.Encode(strToSign, key);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.senergychina.com.cn:16880/njnsbznh/api/device/record?name=" + name + "&password=" + encodePassword + "&sign=" + sign);
            request.Method = "GET";

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();

            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }
            Stream myResponseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = reader.ReadToEnd();

            reader.Close();
            myResponseStream.Close();
            try
            {
                JObject jsonObj = JObject.Parse(retString);
                string data = (string)jsonObj["data"];
                string decodeStr = DES.Decode(data, key);


                return decodeStr;

            }
            catch
            {
                return null;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new RecordForm("SHJHXNJNVERVEL331", "ddd").Show();
        }



        private void button12_Click_1(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            DataColumn dc1 = new DataColumn("设备id");
            DataColumn dc2 = new DataColumn("设备名称");
            DataColumn dc3 = new DataColumn("报修时间");
            DataColumn dc4 = new DataColumn("故障发生时间");
            DataColumn dc5 = new DataColumn("故障处理时间");
            DataColumn dc6 = new DataColumn("故障修复时间");
            DataColumn dc7 = new DataColumn("状态码");
            DataColumn dc8 = new DataColumn("故障处理进度");
            DataColumn dc9 = new DataColumn("故障描述");
            DataColumn dc10 = new DataColumn("故障呼叫人");
            DataColumn dc11 = new DataColumn("故障处理内容");

            dt2.Columns.Add(dc1);
            dt2.Columns.Add(dc2);
            dt2.Columns.Add(dc3);
            dt2.Columns.Add(dc4);
            dt2.Columns.Add(dc5);
            dt2.Columns.Add(dc6);
            dt2.Columns.Add(dc7);
            dt2.Columns.Add(dc8);
            dt2.Columns.Add(dc9);
            dt2.Columns.Add(dc10);
            dt2.Columns.Add(dc11);

            try
            {
                for (int i = 0, l = ids.Length; i < l; i++)
                {
                    string res_one = retJson(ids[i], dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());

                    JArray ja = (JArray)JsonConvert.DeserializeObject(res_one);

                    foreach (var m in ja)
                    {
                        DataRow dr = dt2.NewRow();
                        dr["设备id"] = m["deviceid"];
                        dr["设备名称"] = m["devicename"];
                        dr["报修时间"] = m["calltime"];
                        dr["故障发生时间"] = m["eventtime"];
                        dr["故障处理时间"] = m["happentime"];
                        dr["故障修复时间"] = m["tasktime"];
                        dr["状态码"] = m["code"];
                        dr["故障处理进度"] = m["message"];
                        dr["故障描述"] = m["problem"];
                        dr["故障呼叫人"] = m["caller"];
                        dr["故障处理内容"] = m["dealcontent"];
                        dt2.Rows.Add(dr);
                    }
                }
                dataGridView2.DataSource = dt2;

            }
            catch
            {
                dataGridView2.DataSource = null;
            }


        }

        private void label10_Click(object sender, EventArgs e)
        {
            panel25_Click(panel25, null);
        }

        private void panel25_Click(object sender, EventArgs e)
        {
            Control btnClicked = sender as Panel;

            if (btnClicked.BackColor == Color.FromArgb(86, 109, 156))
            {
                btnElevator_Clicked(button29, null);
                label1.Text = "当前位置：电梯信息管理 >> 故障概率分析";

                panel27.Visible = true;

                btnActivated.BackColor = Color.FromArgb(56, 83, 138);
                btnClicked.BackColor = Color.FromArgb(19, 35, 61);
                btnClicked.Controls[0].Visible = true;
                btnClicked.Controls[1].ForeColor = Color.White;
                btnActivated.Controls[0].Visible = false;
                btnActivated.Controls[1].ForeColor = Color.FromArgb(131, 170, 213);

                btnActivated = btnClicked;
            }
        }

        private void LoadElevatorStatusWeb()
        {
            String injectedScript = "var data = " + JsonConvert.SerializeObject(new ElevatorBreakdown() { BreakdownList = new List<BreakdownInfo>() }) + ";";
            String html = Properties.Resources.item
                .Replace("_ECHARTS_JS_PLACEHOLDER_", Properties.Resources.echarts_min)
                .Replace("_INJECTED_SCRIPT_", injectedScript);

            webBrowser1.DocumentText = html;
        }

        private void LoadElevatorItemInfo(ElevatorBreakdown breakdownInfo)
        {
            webBrowser1.Document.InvokeScript("updateChart", new Object[] { JsonConvert.SerializeObject(breakdownInfo) });

            //Int32 width = flowLayoutPanel1.Width / 2 - 15;

            //WebBrowser webBrowser = new WebBrowser();
            //webBrowser.DocumentText = html;
            //webBrowser.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            //webBrowser.Size = new System.Drawing.Size(width, width);
            //webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
            //    | System.Windows.Forms.AnchorStyles.Left)
            //    | System.Windows.Forms.AnchorStyles.Right)));

            //webBrowser.AllowNavigation = false;
            //webBrowser.AllowWebBrowserDrop = false;
            //webBrowser.IsWebBrowserContextMenuEnabled = false;
            //webBrowser.ScriptErrorsSuppressed = true;
            //webBrowser.ScrollBarsEnabled = false;
            //webBrowser.WebBrowserShortcutsEnabled = false;

            //flowLayoutPanel1.Controls.Add(webBrowser);
        }

        private void btnElevator_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Button btn = sender as Button;

            ElevatorBreakdown breakdownInfo = new ElevatorBreakdown()
            {
                BreakdownList = new List<BreakdownInfo>()
                    {
                        new BreakdownInfo()
                        {
                            door = rnd.Next(2),
                            pit = rnd.Next(2),
                            general = rnd.Next(2),
                            exception = rnd.Next(2)
                        },
                        new BreakdownInfo()
                        {
                            door = rnd.Next(2),
                            pit = rnd.Next(2),
                            general = rnd.Next(2),
                            exception = rnd.Next(2)
                        },
                        new BreakdownInfo()
                        {
                            door = rnd.Next(2),
                            pit = rnd.Next(2),
                            general = rnd.Next(2),
                            exception = rnd.Next(2)
                        },
                        new BreakdownInfo()
                        {
                            door = rnd.Next(2),
                            pit = rnd.Next(2),
                            general = rnd.Next(2),
                            exception = rnd.Next(2)
                        },
                        new BreakdownInfo()
                        {
                            door = rnd.Next(2),
                            pit = rnd.Next(2),
                            general = rnd.Next(2),
                            exception = rnd.Next(2)
                        },
                        new BreakdownInfo()
                        {
                            door = rnd.Next(2),
                            pit = rnd.Next(2),
                            general = rnd.Next(2),
                            exception = rnd.Next(2)
                        },
                        new BreakdownInfo()
                        {
                            door = rnd.Next(2),
                            pit = rnd.Next(2),
                            general = rnd.Next(2),
                            exception = rnd.Next(2)
                        }
                    },
                Year = 2018,
                Month = 10,
                Title = btn.Text + " 电梯故障统计"
            };
            LoadElevatorItemInfo(breakdownInfo);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //正常运行
            label50.Text = (36 - realview.WrongNum - realview.RepairNum).ToString();
            //故障
            label48.Text = realview.WrongNum.ToString();

            label78.Text = realview.RepairNum.ToString();

        }
    }

    class BreakdownInfo
    {
        public Int32 door;
        public Int32 general;
        public Int32 pit;
        public Int32 exception;
    }

    class ElevatorBreakdown
    {
        public String Title;
        public Int32 Year;
        public Int32 Month;
        public List<BreakdownInfo> BreakdownList;
    }



}
