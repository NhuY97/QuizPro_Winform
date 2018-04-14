namespace QuizPro_v._1._0.Presentation.Teacher_Manager
{
    partial class frmImportQues
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
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.dgvQuestion = new System.Windows.Forms.DataGridView();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuid = new DevExpress.XtraEditors.SimpleButton();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.cbTypeQues = new System.Windows.Forms.ComboBox();
            this.lbFileName = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Appearance.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Appearance.Options.UseForeColor = true;
            this.btnImport.Location = new System.Drawing.Point(12, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(148, 35);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Chọn File";
            this.btnImport.ToolTip = "Chọn file từ PC";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgvQuestion
            // 
            this.dgvQuestion.AllowUserToAddRows = false;
            this.dgvQuestion.AllowUserToDeleteRows = false;
            this.dgvQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuestion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuestion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvQuestion.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestion.Location = new System.Drawing.Point(12, 72);
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.ReadOnly = true;
            this.dgvQuestion.Size = new System.Drawing.Size(654, 311);
            this.dgvQuestion.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Appearance.Options.UseForeColor = true;
            this.btnOK.Location = new System.Drawing.Point(509, 489);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(126, 33);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Hoàn tất";
            this.btnOK.ToolTip = "Hoàn tất";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnGuid
            // 
            this.btnGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuid.Appearance.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuid.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnGuid.Appearance.Options.UseFont = true;
            this.btnGuid.Appearance.Options.UseForeColor = true;
            this.btnGuid.Location = new System.Drawing.Point(34, 489);
            this.btnGuid.Name = "btnGuid";
            this.btnGuid.Size = new System.Drawing.Size(126, 33);
            this.btnGuid.TabIndex = 5;
            this.btnGuid.Text = "Hướng dẫn";
            this.btnGuid.ToolTip = "Hướng dẫn import";
            this.btnGuid.Click += new System.EventHandler(this.btnGuid_Click);
            // 
            // cbSubject
            // 
            this.cbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(472, 12);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(194, 21);
            this.cbSubject.TabIndex = 8;
            this.cbSubject.SelectedIndexChanged += new System.EventHandler(this.cbSubject_SelectedIndexChanged);
            // 
            // cbTypeQues
            // 
            this.cbTypeQues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeQues.FormattingEnabled = true;
            this.cbTypeQues.Location = new System.Drawing.Point(472, 39);
            this.cbTypeQues.Name = "cbTypeQues";
            this.cbTypeQues.Size = new System.Drawing.Size(194, 21);
            this.cbTypeQues.TabIndex = 9;
            // 
            // lbFileName
            // 
            this.lbFileName.Appearance.ForeColor = System.Drawing.Color.Fuchsia;
            this.lbFileName.Appearance.Options.UseForeColor = true;
            this.lbFileName.Location = new System.Drawing.Point(45, 53);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(41, 13);
            this.lbFileName.TabIndex = 10;
            this.lbFileName.Text = "File Path";
            this.lbFileName.ToolTip = "File Path";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(383, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Chọn môn học";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(383, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Chọn nội dung";
            // 
            // frmImportQues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 534);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFileName);
            this.Controls.Add(this.cbTypeQues);
            this.Controls.Add(this.cbSubject);
            this.Controls.Add(this.btnGuid);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvQuestion);
            this.Controls.Add(this.btnImport);
            this.ForeColor = System.Drawing.Color.Blue;
            this.Name = "frmImportQues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImportQues";
            this.Load += new System.EventHandler(this.frmImportQues_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnImport;
        private System.Windows.Forms.DataGridView dgvQuestion;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnGuid;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.ComboBox cbTypeQues;
        private DevExpress.XtraEditors.LabelControl lbFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}