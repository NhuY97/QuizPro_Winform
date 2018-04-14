namespace QuizPro_v._1._0.Presentation
{
    partial class frmSelectSubjects
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
            this.dgvSubject = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.SubID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSubject
            // 
            this.dgvSubject.AllowUserToAddRows = false;
            this.dgvSubject.AllowUserToDeleteRows = false;
            this.dgvSubject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubject.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubID,
            this.Subname});
            this.dgvSubject.Location = new System.Drawing.Point(28, 48);
            this.dgvSubject.Name = "dgvSubject";
            this.dgvSubject.ReadOnly = true;
            this.dgvSubject.Size = new System.Drawing.Size(291, 330);
            this.dgvSubject.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(246, 429);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SubID
            // 
            this.SubID.DataPropertyName = "SubID";
            this.SubID.HeaderText = "Mã môn học";
            this.SubID.Name = "SubID";
            this.SubID.ReadOnly = true;
            // 
            // Subname
            // 
            this.Subname.DataPropertyName = "Subname";
            this.Subname.HeaderText = "Tên môn học";
            this.Subname.Name = "Subname";
            this.Subname.ReadOnly = true;
            // 
            // frmSelectSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 471);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvSubject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSelectSubjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn môn học";
            this.Load += new System.EventHandler(this.frmSelectSubjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSubject;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subname;
    }
}