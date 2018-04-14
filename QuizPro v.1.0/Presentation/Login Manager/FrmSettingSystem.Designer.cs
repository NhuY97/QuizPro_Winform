namespace QuizPro_v._1._0
{
    partial class FrmSettingSystem
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
            this.lbDataSource = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.lbPwd = new System.Windows.Forms.Label();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lbMess = new System.Windows.Forms.Label();
            this.btnGetIP = new System.Windows.Forms.Button();
            this.tooltip_getIP = new System.Windows.Forms.ToolTip(this.components);
            this.cb_Authentication = new System.Windows.Forms.ComboBox();
            this.lb_authentication = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDataSource
            // 
            this.lbDataSource.AutoSize = true;
            this.lbDataSource.BackColor = System.Drawing.Color.Transparent;
            this.lbDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataSource.Location = new System.Drawing.Point(36, 51);
            this.lbDataSource.Name = "lbDataSource";
            this.lbDataSource.Size = new System.Drawing.Size(86, 15);
            this.lbDataSource.TabIndex = 10;
            this.lbDataSource.Text = "Data Source";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.BackColor = System.Drawing.Color.Transparent;
            this.lbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserID.Location = new System.Drawing.Point(36, 86);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(55, 15);
            this.lbUserID.TabIndex = 11;
            this.lbUserID.Text = "User ID";
            // 
            // lbPwd
            // 
            this.lbPwd.AutoSize = true;
            this.lbPwd.BackColor = System.Drawing.Color.Transparent;
            this.lbPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPwd.Location = new System.Drawing.Point(36, 118);
            this.lbPwd.Name = "lbPwd";
            this.lbPwd.Size = new System.Drawing.Size(69, 15);
            this.lbPwd.TabIndex = 12;
            this.lbPwd.Text = "Password";
            // 
            // txtDataSource
            // 
            this.txtDataSource.ForeColor = System.Drawing.Color.Gray;
            this.txtDataSource.Location = new System.Drawing.Point(135, 51);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(223, 20);
            this.txtDataSource.TabIndex = 1;
            this.txtDataSource.Text = "IP or ServerName";
            this.txtDataSource.Enter += new System.EventHandler(this.txtDataSource_Enter);
            this.txtDataSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataSource_KeyPress);
            this.txtDataSource.Leave += new System.EventHandler(this.txtDataSource_Leave);
            // 
            // txtUserID
            // 
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.Location = new System.Drawing.Point(135, 86);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(223, 20);
            this.txtUserID.TabIndex = 2;
            this.txtUserID.Enter += new System.EventHandler(this.txtUserID_Enter);
            this.txtUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataSource_KeyPress);
            this.txtUserID.Leave += new System.EventHandler(this.txtUserID_Leave);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(135, 118);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(223, 20);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.UseSystemPasswordChar = true;
            this.txtPwd.Enter += new System.EventHandler(this.txtPwd_Enter);
            this.txtPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataSource_KeyPress);
            this.txtPwd.Leave += new System.EventHandler(this.txtPwd_Leave);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.White;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnOK.Location = new System.Drawing.Point(317, 150);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnClear.Location = new System.Drawing.Point(12, 150);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lbMess
            // 
            this.lbMess.AutoSize = true;
            this.lbMess.BackColor = System.Drawing.Color.Transparent;
            this.lbMess.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMess.ForeColor = System.Drawing.Color.Red;
            this.lbMess.Location = new System.Drawing.Point(58, -4);
            this.lbMess.Name = "lbMess";
            this.lbMess.Size = new System.Drawing.Size(86, 26);
            this.lbMess.TabIndex = 13;
            this.lbMess.Text = "label Mess";
            this.lbMess.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnGetIP
            // 
            this.btnGetIP.BackColor = System.Drawing.Color.BlueViolet;
            this.btnGetIP.Location = new System.Drawing.Point(367, 53);
            this.btnGetIP.Name = "btnGetIP";
            this.btnGetIP.Size = new System.Drawing.Size(28, 18);
            this.btnGetIP.TabIndex = 14;
            this.tooltip_getIP.SetToolTip(this.btnGetIP, "Get IP Address");
            this.btnGetIP.UseVisualStyleBackColor = false;
            this.btnGetIP.Click += new System.EventHandler(this.btnGetIP_Click);
            // 
            // cb_Authentication
            // 
            this.cb_Authentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Authentication.FormattingEnabled = true;
            this.cb_Authentication.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cb_Authentication.Location = new System.Drawing.Point(135, 20);
            this.cb_Authentication.Name = "cb_Authentication";
            this.cb_Authentication.Size = new System.Drawing.Size(223, 21);
            this.cb_Authentication.TabIndex = 15;
            this.cb_Authentication.SelectedIndexChanged += new System.EventHandler(this.cb_Authentication_SelectedIndexChanged);
            // 
            // lb_authentication
            // 
            this.lb_authentication.AutoSize = true;
            this.lb_authentication.BackColor = System.Drawing.Color.Transparent;
            this.lb_authentication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_authentication.Location = new System.Drawing.Point(36, 21);
            this.lb_authentication.Name = "lb_authentication";
            this.lb_authentication.Size = new System.Drawing.Size(98, 15);
            this.lb_authentication.TabIndex = 16;
            this.lb_authentication.Text = "Authentication";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::QuizPro_v._1._0.Properties.Resources.gifLoad;
            this.pictureBox1.Location = new System.Drawing.Point(2, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // FrmSettingSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources.images;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(404, 177);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_authentication);
            this.Controls.Add(this.cb_Authentication);
            this.Controls.Add(this.btnGetIP);
            this.Controls.Add(this.lbMess);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtDataSource);
            this.Controls.Add(this.lbPwd);
            this.Controls.Add(this.lbUserID);
            this.Controls.Add(this.lbDataSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettingSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "System Setting";
            this.Load += new System.EventHandler(this.FrmSettingSystem_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataSource_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDataSource;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.Label lbPwd;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbMess;
        private System.Windows.Forms.Button btnGetIP;
        private System.Windows.Forms.ToolTip tooltip_getIP;
        private System.Windows.Forms.ComboBox cb_Authentication;
        private System.Windows.Forms.Label lb_authentication;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}