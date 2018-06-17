namespace Camera
{
    partial class elevatorinfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        public void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbtype = new System.Windows.Forms.Label();
            this.lboem = new System.Windows.Forms.Label();
            this.lbpostion = new System.Windows.Forms.Label();
            this.lbnum = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelDirection = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.lbbroadnum = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btevaerr9 = new System.Windows.Forms.Button();
            this.btevanormal = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(197, -2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(357, 433);
            this.pictureBox.TabIndex = 29;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "基本信息:";
            // 
            // lbtype
            // 
            this.lbtype.AutoSize = true;
            this.lbtype.Location = new System.Drawing.Point(3, 93);
            this.lbtype.Name = "lbtype";
            this.lbtype.Size = new System.Drawing.Size(107, 12);
            this.lbtype.TabIndex = 20;
            this.lbtype.Text = "电梯类型:垂直电梯";
            // 
            // lboem
            // 
            this.lboem.AutoSize = true;
            this.lboem.Location = new System.Drawing.Point(3, 71);
            this.lboem.Name = "lboem";
            this.lboem.Size = new System.Drawing.Size(83, 12);
            this.lboem.TabIndex = 17;
            this.lboem.Text = "电梯品牌:蒂森";
            // 
            // lbpostion
            // 
            this.lbpostion.AutoSize = true;
            this.lbpostion.Location = new System.Drawing.Point(3, 27);
            this.lbpostion.Name = "lbpostion";
            this.lbpostion.Size = new System.Drawing.Size(137, 12);
            this.lbpostion.TabIndex = 16;
            this.lbpostion.Text = "电梯位置:A2-3候车-站台";
            // 
            // lbnum
            // 
            this.lbnum.AutoSize = true;
            this.lbnum.Location = new System.Drawing.Point(3, 5);
            this.lbnum.Name = "lbnum";
            this.lbnum.Size = new System.Drawing.Size(83, 12);
            this.lbnum.TabIndex = 15;
            this.lbnum.Text = "电梯编号:S204";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.labelDirection);
            this.panel1.Controls.Add(this.labelPosition);
            this.panel1.Controls.Add(this.lbbroadnum);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btevaerr9);
            this.panel1.Controls.Add(this.btevanormal);
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Controls.Add(this.lboem);
            this.panel1.Controls.Add(this.lbnum);
            this.panel1.Controls.Add(this.lbpostion);
            this.panel1.Controls.Add(this.lbtype);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 431);
            this.panel1.TabIndex = 30;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(102, 207);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 23);
            this.button5.TabIndex = 51;
            this.button5.Text = "限位故障";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(5, 207);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 50;
            this.button4.Text = "非正常停梯";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(102, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 23);
            this.button3.TabIndex = 49;
            this.button3.Text = "错层故障";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 48;
            this.button2.Text = "设备履历";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelDirection
            // 
            this.labelDirection.AutoSize = true;
            this.labelDirection.Location = new System.Drawing.Point(164, 93);
            this.labelDirection.Name = "labelDirection";
            this.labelDirection.Size = new System.Drawing.Size(29, 12);
            this.labelDirection.TabIndex = 47;
            this.labelDirection.Text = "↑↓";
            this.labelDirection.Visible = false;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(116, 93);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(77, 12);
            this.labelPosition.TabIndex = 46;
            this.labelPosition.Text = "未读取到楼层";
            // 
            // lbbroadnum
            // 
            this.lbbroadnum.AutoSize = true;
            this.lbbroadnum.Location = new System.Drawing.Point(2, 49);
            this.lbbroadnum.Name = "lbbroadnum";
            this.lbbroadnum.Size = new System.Drawing.Size(83, 12);
            this.lbbroadnum.TabIndex = 44;
            this.lbbroadnum.Text = "面板编号：3号";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Camera.Properties.Resources._1484659821;
            this.pictureBox1.Location = new System.Drawing.Point(53, 333);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "查看";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btevaerr9
            // 
            this.btevaerr9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btevaerr9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btevaerr9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btevaerr9.Location = new System.Drawing.Point(5, 178);
            this.btevaerr9.Name = "btevaerr9";
            this.btevaerr9.Size = new System.Drawing.Size(91, 23);
            this.btevaerr9.TabIndex = 41;
            this.btevaerr9.Text = "梯门故障";
            this.btevaerr9.UseVisualStyleBackColor = false;
            this.btevaerr9.Click += new System.EventHandler(this.button5_Click);
            // 
            // btevanormal
            // 
            this.btevanormal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btevanormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btevanormal.Location = new System.Drawing.Point(5, 149);
            this.btevanormal.Name = "btevanormal";
            this.btevanormal.Size = new System.Drawing.Size(188, 23);
            this.btevanormal.TabIndex = 34;
            this.btevanormal.Text = "正常运行";
            this.btevanormal.UseVisualStyleBackColor = false;
            this.btevanormal.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(5, 264);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(91, 23);
            this.button7.TabIndex = 54;
            this.button7.Text = "通讯故障";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button5_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(102, 235);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(91, 23);
            this.button8.TabIndex = 53;
            this.button8.Text = "电梯死机";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button5_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button9.Location = new System.Drawing.Point(5, 235);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(91, 23);
            this.button9.TabIndex = 52;
            this.button9.Text = "运行故障";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button5_Click);
            // 
            // elevatorinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel1);
            this.Name = "elevatorinfo";
            this.Size = new System.Drawing.Size(554, 431);
            this.Load += new System.EventHandler(this.elevatorinfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lbtype;
        public System.Windows.Forms.Label lboem;
        public System.Windows.Forms.Label lbpostion;
        public System.Windows.Forms.Label lbnum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btevaerr9;
        private System.Windows.Forms.Button btevanormal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btevl0;
        private System.Windows.Forms.Button btevl1;
        private System.Windows.Forms.Button btevl2;
        private System.Windows.Forms.Button btevl3;
        private System.Windows.Forms.Button btevl4;
        private System.Windows.Forms.Button btevl5;
        private System.Windows.Forms.Button btevl6;
        private System.Windows.Forms.Button btevl7;
        private System.Windows.Forms.Button btevl8;
        private System.Windows.Forms.Button btevl9;
        private System.Windows.Forms.Button btevl10;
        private System.Windows.Forms.Button btevl11;
        private System.Windows.Forms.Button btevl12;
        private System.Windows.Forms.Button btevl13;
        private System.Windows.Forms.Button btevl14;
        private System.Windows.Forms.Button btevl15;
        private System.Windows.Forms.Button btevl16;
        private System.Windows.Forms.Button btevl17;
        private System.Windows.Forms.Button btevl18;
        private System.Windows.Forms.Button btevl19;
        private System.Windows.Forms.Button btevl20;
        private System.Windows.Forms.Button btevl21;
        private System.Windows.Forms.Button btevl22;
        private System.Windows.Forms.Button btevl23;
        private System.Windows.Forms.Button btevl24;
        private System.Windows.Forms.Button btevl25;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbbroadnum;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelDirection;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}
