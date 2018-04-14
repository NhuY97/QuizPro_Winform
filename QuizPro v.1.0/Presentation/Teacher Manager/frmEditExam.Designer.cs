namespace QuizPro_v._1._0.Presentation.Teacher_Manager
{
    partial class frmEditExam
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
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtExName = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.cbTimeTest = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(369, 274);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 28);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "Hoàn tất";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtExName
            // 
            this.txtExName.Location = new System.Drawing.Point(172, 81);
            this.txtExName.Margin = new System.Windows.Forms.Padding(4);
            this.txtExName.Name = "txtExName";
            this.txtExName.Size = new System.Drawing.Size(309, 22);
            this.txtExName.TabIndex = 17;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(99, 18);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(329, 31);
            this.lbTitle.TabIndex = 16;
            this.lbTitle.Text = "Exam Info";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(46, 218);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ngày bắt đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(46, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Thời gian thi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(46, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tên kỳ thi";
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateStart.Location = new System.Drawing.Point(172, 212);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Size = new System.Drawing.Size(200, 22);
            this.dtpDateStart.TabIndex = 21;
            // 
            // cbTimeTest
            // 
            this.cbTimeTest.FormattingEnabled = true;
            this.cbTimeTest.Items.AddRange(new object[] {
            "15",
            "30",
            "45",
            "60",
            "90",
            "120"});
            this.cbTimeTest.Location = new System.Drawing.Point(172, 146);
            this.cbTimeTest.Name = "cbTimeTest";
            this.cbTimeTest.Size = new System.Drawing.Size(73, 24);
            this.cbTimeTest.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Magenta;
            this.label4.Location = new System.Drawing.Point(262, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "phút";
            // 
            // lbError
            // 
            this.lbError.BackColor = System.Drawing.Color.Transparent;
            this.lbError.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(21, 243);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(341, 63);
            this.lbError.TabIndex = 24;
            // 
            // frmEditExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources.background_with_wavy_lines1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(529, 315);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbTimeTest);
            this.Controls.Add(this.dtpDateStart);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtExName);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEditExam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Exam";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.TextBox txtExName;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.ComboBox cbTimeTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbError;
    }
}