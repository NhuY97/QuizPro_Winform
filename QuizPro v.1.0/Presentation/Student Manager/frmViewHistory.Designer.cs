namespace QuizPro_v._1._0.View.Student_Manager
{
    partial class frmViewHistory
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
            this.btn_Back = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Examname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeComplete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbMaHS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMarkAVG = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.Transparent;
            this.btn_Back.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources.ic_back_form;
            this.btn_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Back.Location = new System.Drawing.Point(2, 3);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(55, 32);
            this.btn_Back.TabIndex = 23;
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Examname,
            this.SubName,
            this.DateStart,
            this.Mark,
            this.TimeComplete});
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(714, 529);
            this.dataGridView1.TabIndex = 24;
            // 
            // Examname
            // 
            this.Examname.DataPropertyName = "ExName";
            this.Examname.HeaderText = "Kỳ thi";
            this.Examname.Name = "Examname";
            this.Examname.ReadOnly = true;
            // 
            // SubName
            // 
            this.SubName.DataPropertyName = "SubName";
            this.SubName.HeaderText = "Môn học";
            this.SubName.Name = "SubName";
            this.SubName.ReadOnly = true;
            // 
            // DateStart
            // 
            this.DateStart.DataPropertyName = "DateTest";
            this.DateStart.HeaderText = "Ngày thi";
            this.DateStart.Name = "DateStart";
            this.DateStart.ReadOnly = true;
            // 
            // Mark
            // 
            this.Mark.DataPropertyName = "Mark";
            this.Mark.HeaderText = "Điểm";
            this.Mark.Name = "Mark";
            this.Mark.ReadOnly = true;
            // 
            // TimeComplete
            // 
            this.TimeComplete.DataPropertyName = "TimeComplete";
            this.TimeComplete.HeaderText = "Thời gian làm bài";
            this.TimeComplete.Name = "TimeComplete";
            this.TimeComplete.ReadOnly = true;
            // 
            // lbMaHS
            // 
            this.lbMaHS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMaHS.AutoSize = true;
            this.lbMaHS.BackColor = System.Drawing.Color.Transparent;
            this.lbMaHS.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaHS.ForeColor = System.Drawing.Color.Blue;
            this.lbMaHS.Location = new System.Drawing.Point(488, 49);
            this.lbMaHS.Name = "lbMaHS";
            this.lbMaHS.Size = new System.Drawing.Size(58, 20);
            this.lbMaHS.TabIndex = 26;
            this.lbMaHS.Text = "Mã HS ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Fuchsia;
            this.label1.Location = new System.Drawing.Point(175, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 29);
            this.label1.TabIndex = 25;
            this.label1.Text = "DANH SÁCH MÔN THI [2017-2018]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(58, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Điểm tích lũy: ";
            // 
            // lbMarkAVG
            // 
            this.lbMarkAVG.AutoSize = true;
            this.lbMarkAVG.BackColor = System.Drawing.Color.Transparent;
            this.lbMarkAVG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMarkAVG.ForeColor = System.Drawing.Color.Red;
            this.lbMarkAVG.Location = new System.Drawing.Point(176, 49);
            this.lbMarkAVG.Name = "lbMarkAVG";
            this.lbMarkAVG.Size = new System.Drawing.Size(0, 20);
            this.lbMarkAVG.TabIndex = 28;
            // 
            // frmViewHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources.background_with_wavy_lines1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(738, 613);
            this.Controls.Add(this.lbMarkAVG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbMaHS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Back);
            this.Name = "frmViewHistory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewHistory_FormClosing);
            this.Load += new System.EventHandler(this.frmViewHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbMaHS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Examname;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mark;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeComplete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMarkAVG;
    }
}