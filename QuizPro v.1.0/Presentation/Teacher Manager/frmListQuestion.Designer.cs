namespace QuizPro_v._1._0.Presentation.Teacher_Manager
{
    partial class frmListQuestion
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkboxSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QuesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuesContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkboxSelect,
            this.QuesID,
            this.QuesContent});
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(724, 441);
            this.dataGridView1.TabIndex = 0;
            // 
            // checkboxSelect
            // 
            this.checkboxSelect.FalseValue = "false";
            this.checkboxSelect.HeaderText = "Check";
            this.checkboxSelect.IndeterminateValue = "false";
            this.checkboxSelect.Name = "checkboxSelect";
            this.checkboxSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.checkboxSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.checkboxSelect.ToolTipText = "Thêm câu hỏi này";
            this.checkboxSelect.TrueValue = "true";
            // 
            // QuesID
            // 
            this.QuesID.DataPropertyName = "QuesID";
            this.QuesID.HeaderText = "Mã câu hỏi";
            this.QuesID.Name = "QuesID";
            this.QuesID.ReadOnly = true;
            // 
            // QuesContent
            // 
            this.QuesContent.DataPropertyName = "QuesContent";
            this.QuesContent.FillWeight = 450F;
            this.QuesContent.HeaderText = "Nội dung câu hỏi";
            this.QuesContent.Name = "QuesContent";
            this.QuesContent.ReadOnly = true;
            this.QuesContent.Width = 450;
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(12, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(723, 19);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Thêm câu hỏi vào kỳ thi ";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(614, 484);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(121, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Thêm Vào Kỳ Thi";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmListQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources.background_with_wavy_lines1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(748, 519);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmListQuestion";
            this.Text = "frmListQuestion";
            this.Load += new System.EventHandler(this.frmListQuestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbTitle;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkboxSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuesContent;
    }
}