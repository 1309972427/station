using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            System.Drawing.Rectangle rect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            int h = rect.Height;
            int w = rect.Width;
            panel5.Width = w;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void label6_Click(object sender, EventArgs e)
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

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            Control btnClicked = sender as Label;
            btnClicked.BackColor = Color.White;
            btnClicked.ForeColor = Color.Black;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            Control btnClicked = sender as Label;
            btnClicked.BackColor = Color.Transparent;
            btnClicked.ForeColor = Color.White;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
