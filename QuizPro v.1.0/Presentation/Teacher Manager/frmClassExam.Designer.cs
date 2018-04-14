namespace QuizPro_v._1._0.Presentation.Teacher_Manager
{
    partial class frmClassExam
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
            this.dgvListClass = new System.Windows.Forms.DataGridView();
            this.ClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnAddClass = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.dgvClassNotExistInEX = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountMembet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteClass = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassNotExistInEX)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListClass
            // 
            this.dgvListClass.AllowUserToAddRows = false;
            this.dgvListClass.AllowUserToDeleteRows = false;
            this.dgvListClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListClass.BackgroundColor = System.Drawing.Color.White;
            this.dgvListClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListClass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClassID,
            this.ClassName,
            this.TotalMember});
            this.dgvListClass.Location = new System.Drawing.Point(12, 56);
            this.dgvListClass.Name = "dgvListClass";
            this.dgvListClass.ReadOnly = true;
            this.dgvListClass.Size = new System.Drawing.Size(571, 370);
            this.dgvListClass.TabIndex = 0;
            // 
            // ClassID
            // 
            this.ClassID.DataPropertyName = "ClassID";
            this.ClassID.HeaderText = "Mã lớp";
            this.ClassID.Name = "ClassID";
            this.ClassID.ReadOnly = true;
            // 
            // ClassName
            // 
            this.ClassName.DataPropertyName = "Classname";
            this.ClassName.HeaderText = "Tên Lớp";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            // 
            // TotalMember
            // 
            this.TotalMember.DataPropertyName = "TotalStudent";
            this.TotalMember.HeaderText = "Sĩ số";
            this.TotalMember.Name = "TotalMember";
            this.TotalMember.ReadOnly = true;
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitle.AutoEllipsis = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(12, 23);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(571, 23);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Danh sách lớp thi của kỳ thi ";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(26, 447);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(99, 29);
            this.btnAddClass.TabIndex = 2;
            this.btnAddClass.Text = "Thêm lớp";
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(473, 447);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 29);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Lưu thay đổi";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvClassNotExistInEX
            // 
            this.dgvClassNotExistInEX.AllowUserToAddRows = false;
            this.dgvClassNotExistInEX.AllowUserToDeleteRows = false;
            this.dgvClassNotExistInEX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClassNotExistInEX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClassNotExistInEX.BackgroundColor = System.Drawing.Color.White;
            this.dgvClassNotExistInEX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassNotExistInEX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.CountMembet});
            this.dgvClassNotExistInEX.Location = new System.Drawing.Point(12, 56);
            this.dgvClassNotExistInEX.Name = "dgvClassNotExistInEX";
            this.dgvClassNotExistInEX.Size = new System.Drawing.Size(571, 370);
            this.dgvClassNotExistInEX.TabIndex = 4;
            this.dgvClassNotExistInEX.Visible = false;
            // 
            // Check
            // 
            this.Check.FalseValue = "false";
            this.Check.HeaderText = "Check";
            this.Check.IndeterminateValue = "false";
            this.Check.Name = "Check";
            this.Check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Check.ToolTipText = "Chọn lớp này";
            this.Check.TrueValue = "true";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ClassID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã lớp";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Classname";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên lớp";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // CountMembet
            // 
            this.CountMembet.DataPropertyName = "TotalStudent";
            this.CountMembet.HeaderText = "Sĩ số";
            this.CountMembet.Name = "CountMembet";
            this.CountMembet.ReadOnly = true;
            // 
            // btnDeleteClass
            // 
            this.btnDeleteClass.Location = new System.Drawing.Point(473, 447);
            this.btnDeleteClass.Name = "btnDeleteClass";
            this.btnDeleteClass.Size = new System.Drawing.Size(99, 29);
            this.btnDeleteClass.TabIndex = 5;
            this.btnDeleteClass.Text = "Xóa lớp đã chọn";
            this.btnDeleteClass.Click += new System.EventHandler(this.btnDeleteClass_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.Location = new System.Drawing.Point(265, 447);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(78, 29);
            this.BtnCancle.TabIndex = 6;
            this.BtnCancle.Text = "Hủy";
            this.BtnCancle.Visible = false;
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // frmClassExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources.background_with_wavy_lines1;
            this.ClientSize = new System.Drawing.Size(595, 488);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.btnDeleteClass);
            this.Controls.Add(this.dgvClassNotExistInEX);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dgvListClass);
            this.Name = "frmClassExam";
            this.Text = "frmClassExam";
            this.Load += new System.EventHandler(this.frmClassExam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassNotExistInEX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListClass;
        private System.Windows.Forms.Label lbTitle;
        private DevExpress.XtraEditors.SimpleButton btnAddClass;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.DataGridView dgvClassNotExistInEX;
        private DevExpress.XtraEditors.SimpleButton btnDeleteClass;
        private DevExpress.XtraEditors.SimpleButton BtnCancle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMember;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountMembet;
    }
}