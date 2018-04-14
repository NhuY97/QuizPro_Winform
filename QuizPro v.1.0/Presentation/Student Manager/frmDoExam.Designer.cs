namespace QuizPro_v._1._0.View.Student_Manager
{
    partial class frmDoExam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.rOptionD = new System.Windows.Forms.RadioButton();
            this.rOptionC = new System.Windows.Forms.RadioButton();
            this.rOptionB = new System.Windows.Forms.RadioButton();
            this.rOptionA = new System.Windows.Forms.RadioButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.lbQuesName = new System.Windows.Forms.Label();
            this.pnlNumQues = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTimeRemaining = new System.Windows.Forms.Label();
            this.pnlExamInfo = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.PictureBox();
            this.lbExamName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.pnlSide.SuspendLayout();
            this.pnlExamInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.rOptionD);
            this.pnlContent.Controls.Add(this.rOptionC);
            this.pnlContent.Controls.Add(this.rOptionB);
            this.pnlContent.Controls.Add(this.rOptionA);
            this.pnlContent.Controls.Add(this.radioGroup1);
            this.pnlContent.Controls.Add(this.lbQuesName);
            this.pnlContent.Location = new System.Drawing.Point(188, 1);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(561, 437);
            this.pnlContent.TabIndex = 0;
            // 
            // rOptionD
            // 
            this.rOptionD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rOptionD.AutoSize = true;
            this.rOptionD.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rOptionD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rOptionD.ForeColor = System.Drawing.Color.Black;
            this.rOptionD.Location = new System.Drawing.Point(282, 347);
            this.rOptionD.Name = "rOptionD";
            this.rOptionD.Size = new System.Drawing.Size(41, 22);
            this.rOptionD.TabIndex = 5;
            this.rOptionD.TabStop = true;
            this.rOptionD.Text = " D";
            this.rOptionD.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rOptionD.UseVisualStyleBackColor = true;
            this.rOptionD.Visible = false;
            this.rOptionD.CheckedChanged += new System.EventHandler(this.rOption_CheckedChanged);
            // 
            // rOptionC
            // 
            this.rOptionC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rOptionC.AutoSize = true;
            this.rOptionC.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rOptionC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rOptionC.ForeColor = System.Drawing.Color.Black;
            this.rOptionC.Location = new System.Drawing.Point(10, 347);
            this.rOptionC.Name = "rOptionC";
            this.rOptionC.Size = new System.Drawing.Size(41, 22);
            this.rOptionC.TabIndex = 4;
            this.rOptionC.TabStop = true;
            this.rOptionC.Text = " C";
            this.rOptionC.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rOptionC.UseVisualStyleBackColor = true;
            this.rOptionC.Visible = false;
            this.rOptionC.CheckedChanged += new System.EventHandler(this.rOption_CheckedChanged);
            // 
            // rOptionB
            // 
            this.rOptionB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rOptionB.AutoSize = true;
            this.rOptionB.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rOptionB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rOptionB.ForeColor = System.Drawing.Color.Black;
            this.rOptionB.Location = new System.Drawing.Point(282, 261);
            this.rOptionB.Name = "rOptionB";
            this.rOptionB.Size = new System.Drawing.Size(40, 22);
            this.rOptionB.TabIndex = 3;
            this.rOptionB.TabStop = true;
            this.rOptionB.Text = " B";
            this.rOptionB.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rOptionB.UseVisualStyleBackColor = true;
            this.rOptionB.Visible = false;
            this.rOptionB.CheckedChanged += new System.EventHandler(this.rOption_CheckedChanged);
            // 
            // rOptionA
            // 
            this.rOptionA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rOptionA.AutoSize = true;
            this.rOptionA.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rOptionA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rOptionA.ForeColor = System.Drawing.Color.Black;
            this.rOptionA.Location = new System.Drawing.Point(9, 261);
            this.rOptionA.Name = "rOptionA";
            this.rOptionA.Size = new System.Drawing.Size(35, 22);
            this.rOptionA.TabIndex = 2;
            this.rOptionA.TabStop = true;
            this.rOptionA.Text = "A";
            this.rOptionA.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rOptionA.UseVisualStyleBackColor = true;
            this.rOptionA.Visible = false;
            this.rOptionA.CheckedChanged += new System.EventHandler(this.rOption_CheckedChanged);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroup1.Location = new System.Drawing.Point(4, 259);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.radioGroup1.Size = new System.Drawing.Size(553, 177);
            this.radioGroup1.TabIndex = 1;
            // 
            // lbQuesName
            // 
            this.lbQuesName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbQuesName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuesName.ForeColor = System.Drawing.Color.Blue;
            this.lbQuesName.Location = new System.Drawing.Point(6, 8);
            this.lbQuesName.Name = "lbQuesName";
            this.lbQuesName.Size = new System.Drawing.Size(551, 248);
            this.lbQuesName.TabIndex = 0;
            this.lbQuesName.Text = "Tại sao anh Ý lại đẹp trai đến như vại?";
            // 
            // pnlNumQues
            // 
            this.pnlNumQues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNumQues.BackColor = System.Drawing.Color.White;
            this.pnlNumQues.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNumQues.Location = new System.Drawing.Point(188, 434);
            this.pnlNumQues.Name = "pnlNumQues";
            this.pnlNumQues.Size = new System.Drawing.Size(561, 104);
            this.pnlNumQues.TabIndex = 0;
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.White;
            this.pnlSide.Controls.Add(this.btnBack);
            this.pnlSide.Controls.Add(this.label1);
            this.pnlSide.Controls.Add(this.lbTimeRemaining);
            this.pnlSide.Location = new System.Drawing.Point(0, 1);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(188, 367);
            this.pnlSide.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnBack.Appearance.Options.UseForeColor = true;
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(71, 36);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Thoát";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Fuchsia;
            this.label1.Location = new System.Drawing.Point(0, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Good Luck!";
            // 
            // lbTimeRemaining
            // 
            this.lbTimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeRemaining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbTimeRemaining.Location = new System.Drawing.Point(-38, 54);
            this.lbTimeRemaining.Name = "lbTimeRemaining";
            this.lbTimeRemaining.Size = new System.Drawing.Size(268, 73);
            this.lbTimeRemaining.TabIndex = 0;
            this.lbTimeRemaining.Text = "hết giờ!";
            this.lbTimeRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlExamInfo
            // 
            this.pnlExamInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlExamInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlExamInfo.Controls.Add(this.btnSubmit);
            this.pnlExamInfo.Controls.Add(this.lbExamName);
            this.pnlExamInfo.Location = new System.Drawing.Point(0, 368);
            this.pnlExamInfo.Name = "pnlExamInfo";
            this.pnlExamInfo.Size = new System.Drawing.Size(190, 170);
            this.pnlExamInfo.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnSubmit.Image = global::QuizPro_v._1._0.Properties.Resources.ic_end_test;
            this.btnSubmit.Location = new System.Drawing.Point(30, 76);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(113, 58);
            this.btnSubmit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.TabStop = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbExamName
            // 
            this.lbExamName.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExamName.ForeColor = System.Drawing.Color.Red;
            this.lbExamName.Location = new System.Drawing.Point(2, 3);
            this.lbExamName.Name = "lbExamName";
            this.lbExamName.Size = new System.Drawing.Size(177, 73);
            this.lbExamName.TabIndex = 0;
            this.lbExamName.Text = "Kỳ thi Vật Lý Đại Cương 1";
            this.lbExamName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmDoExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(750, 540);
            this.Controls.Add(this.pnlExamInfo);
            this.Controls.Add(this.pnlSide);
            this.Controls.Add(this.pnlNumQues);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoExam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuizPro - Do Exam";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDoExam_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.pnlSide.ResumeLayout(false);
            this.pnlSide.PerformLayout();
            this.pnlExamInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.FlowLayoutPanel pnlNumQues;
        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTimeRemaining;
        private System.Windows.Forms.Panel pnlExamInfo;
        private System.Windows.Forms.Label lbExamName;
        private System.Windows.Forms.PictureBox btnSubmit;
        private System.Windows.Forms.RadioButton rOptionD;
        private System.Windows.Forms.RadioButton rOptionC;
        private System.Windows.Forms.RadioButton rOptionB;
        private System.Windows.Forms.RadioButton rOptionA;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.Label lbQuesName;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private System.Windows.Forms.Timer timer1;
    }
}