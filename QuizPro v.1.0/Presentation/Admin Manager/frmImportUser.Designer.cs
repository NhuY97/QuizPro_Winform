namespace QuizPro_v._1._0.Presentation.Admin_Manager
{
    partial class frmImportUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbFileName = new System.Windows.Forms.Label();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.lbClassName = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.lbMember = new System.Windows.Forms.Label();
            this.numMember = new System.Windows.Forms.NumericUpDown();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMember)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFileName.ForeColor = System.Drawing.Color.Fuchsia;
            this.lbFileName.Location = new System.Drawing.Point(135, 29);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(0, 16);
            this.lbFileName.TabIndex = 1;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(22, 23);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(98, 26);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Chọn File";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lbClassName
            // 
            this.lbClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClassName.AutoSize = true;
            this.lbClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClassName.Location = new System.Drawing.Point(299, 56);
            this.lbClassName.Name = "lbClassName";
            this.lbClassName.Size = new System.Drawing.Size(57, 18);
            this.lbClassName.TabIndex = 3;
            this.lbClassName.Text = "Tên lớp";
            this.lbClassName.Visible = false;
            // 
            // txtClassName
            // 
            this.txtClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClassName.Location = new System.Drawing.Point(375, 56);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(121, 20);
            this.txtClassName.TabIndex = 4;
            this.txtClassName.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(627, 491);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(111, 33);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Hoàn tất";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(4, 90);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.Size = new System.Drawing.Size(727, 379);
            this.dgvUser.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(534, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Quyền";
            // 
            // cbRole
            // 
            this.cbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "Học sinh",
            "Giáo viên",
            "Admin"});
            this.cbRole.Location = new System.Drawing.Point(610, 9);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(121, 21);
            this.cbRole.TabIndex = 8;
            this.cbRole.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbMember
            // 
            this.lbMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMember.AutoSize = true;
            this.lbMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMember.Location = new System.Drawing.Point(517, 56);
            this.lbMember.Name = "lbMember";
            this.lbMember.Size = new System.Drawing.Size(82, 18);
            this.lbMember.TabIndex = 9;
            this.lbMember.Text = "Sĩ số tối đa";
            this.lbMember.Visible = false;
            // 
            // numMember
            // 
            this.numMember.Location = new System.Drawing.Point(612, 55);
            this.numMember.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMember.Name = "numMember";
            this.numMember.Size = new System.Drawing.Size(120, 20);
            this.numMember.TabIndex = 10;
            this.numMember.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMember.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(22, 491);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(128, 33);
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "Hướng dẫn";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmImportUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 536);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.numMember);
            this.Controls.Add(this.lbMember);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.lbClassName);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lbFileName);
            this.Name = "frmImportUser";
            this.Text = "ImportUser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImportUser_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbFileName;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private System.Windows.Forms.Label lbClassName;
        private System.Windows.Forms.TextBox txtClassName;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label lbMember;
        private System.Windows.Forms.NumericUpDown numMember;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}