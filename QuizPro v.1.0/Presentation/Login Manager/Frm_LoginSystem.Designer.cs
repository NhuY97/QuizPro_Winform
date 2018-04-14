namespace QuizPro_v._1._0
{
        partial class Frm_LoginSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LoginSystem));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.rg_Role = new DevExpress.XtraEditors.RadioGroup();
            this.rb_Student = new System.Windows.Forms.RadioButton();
            this.rb_Teacher = new System.Windows.Forms.RadioButton();
            this.rb_Admin = new System.Windows.Forms.RadioButton();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pic_UserName = new System.Windows.Forms.PictureBox();
            this.pic_Pwd = new System.Windows.Forms.PictureBox();
            this.bW_LoadToLogin = new System.ComponentModel.BackgroundWorker();
            this.lbStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rg_Role.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_UserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Pwd)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(44, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(341, 66);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Welcome to QuizPro v1.0";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe Print", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(47, 121);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 26);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "User Name";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe Print", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(47, 183);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 26);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Password";
            // 
            // rg_Role
            // 
            this.rg_Role.Location = new System.Drawing.Point(47, 235);
            this.rg_Role.Name = "rg_Role";
            this.rg_Role.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rg_Role.Properties.Appearance.Options.UseBackColor = true;
            this.rg_Role.Size = new System.Drawing.Size(289, 45);
            this.rg_Role.TabIndex = 5;
            this.rg_Role.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_LoginSystem_KeyPress);
            // 
            // rb_Student
            // 
            this.rb_Student.AutoSize = true;
            this.rb_Student.BackColor = System.Drawing.Color.Transparent;
            this.rb_Student.Checked = true;
            this.rb_Student.Location = new System.Drawing.Point(56, 247);
            this.rb_Student.Name = "rb_Student";
            this.rb_Student.Size = new System.Drawing.Size(63, 17);
            this.rb_Student.TabIndex = 2;
            this.rb_Student.TabStop = true;
            this.rb_Student.Text = "Student";
            this.rb_Student.UseVisualStyleBackColor = false;
            this.rb_Student.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_LoginSystem_KeyPress);
            // 
            // rb_Teacher
            // 
            this.rb_Teacher.AutoSize = true;
            this.rb_Teacher.BackColor = System.Drawing.Color.Transparent;
            this.rb_Teacher.Location = new System.Drawing.Point(152, 247);
            this.rb_Teacher.Name = "rb_Teacher";
            this.rb_Teacher.Size = new System.Drawing.Size(64, 17);
            this.rb_Teacher.TabIndex = 4;
            this.rb_Teacher.Text = "Teacher";
            this.rb_Teacher.UseVisualStyleBackColor = false;
            this.rb_Teacher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_LoginSystem_KeyPress);
            // 
            // rb_Admin
            // 
            this.rb_Admin.AutoSize = true;
            this.rb_Admin.BackColor = System.Drawing.Color.Transparent;
            this.rb_Admin.Location = new System.Drawing.Point(249, 247);
            this.rb_Admin.Name = "rb_Admin";
            this.rb_Admin.Size = new System.Drawing.Size(54, 17);
            this.rb_Admin.TabIndex = 5;
            this.rb_Admin.Text = "Admin";
            this.rb_Admin.UseVisualStyleBackColor = false;
            this.rb_Admin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_LoginSystem_KeyPress);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(152, 126);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(184, 21);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "15110378";
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_LoginSystem_KeyPress);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(152, 188);
            this.txtPwd.MaxLength = 50;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(184, 21);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.Text = "nhuy1997";
            this.txtPwd.UseSystemPasswordChar = true;
            this.txtPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_LoginSystem_KeyPress);
            this.txtPwd.Leave += new System.EventHandler(this.txtPwd_Leave);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Yellow;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Blue;
            this.btnLogin.Location = new System.Drawing.Point(121, 355);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(148, 52);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Sign In";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(44, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Forgot Password ?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(2, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Copyright © 2017 HCMUTE - TNTNY";
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources.tools;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.ForeColor = System.Drawing.Color.Transparent;
            this.btnSetting.Location = new System.Drawing.Point(344, 424);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(52, 44);
            this.btnSetting.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnSetting, "Setting System");
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Magenta;
            this.label3.Location = new System.Drawing.Point(75, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 27);
            this.label3.TabIndex = 19;
            this.label3.Text = "The Taste of a new Generation";
            // 
            // pic_UserName
            // 
            this.pic_UserName.BackColor = System.Drawing.Color.Transparent;
            this.pic_UserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_UserName.Location = new System.Drawing.Point(355, 123);
            this.pic_UserName.Name = "pic_UserName";
            this.pic_UserName.Size = new System.Drawing.Size(30, 24);
            this.pic_UserName.TabIndex = 20;
            this.pic_UserName.TabStop = false;
            this.pic_UserName.Visible = false;
            // 
            // pic_Pwd
            // 
            this.pic_Pwd.BackColor = System.Drawing.Color.Transparent;
            this.pic_Pwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_Pwd.Location = new System.Drawing.Point(355, 188);
            this.pic_Pwd.Name = "pic_Pwd";
            this.pic_Pwd.Size = new System.Drawing.Size(30, 23);
            this.pic_Pwd.TabIndex = 21;
            this.pic_Pwd.TabStop = false;
            this.pic_Pwd.Visible = false;
            // 
            // bW_LoadToLogin
            // 
            this.bW_LoadToLogin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bW_LoadToLogin_DoWork);
            this.bW_LoadToLogin.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bW_LoadToLogin_RunWorkerCompleted);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Location = new System.Drawing.Point(2, 435);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(154, 15);
            this.lbStatus.TabIndex = 24;
            this.lbStatus.Text = "Server: Not Connected";
            // 
            // Frm_LoginSystem
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::QuizPro_v._1._0.Properties.Resources.background_with_wavy_lines1;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(397, 469);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.pic_Pwd);
            this.Controls.Add(this.pic_UserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.rb_Admin);
            this.Controls.Add(this.rb_Teacher);
            this.Controls.Add(this.rb_Student);
            this.Controls.Add(this.rg_Role);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_LoginSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Quiz version 1.0";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_LoginSystem_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.rg_Role.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_UserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Pwd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion
            private DevExpress.XtraEditors.LabelControl labelControl1;
            private DevExpress.XtraEditors.LabelControl labelControl2;
            private DevExpress.XtraEditors.LabelControl labelControl3;
            private DevExpress.XtraEditors.RadioGroup rg_Role;
            private System.Windows.Forms.RadioButton rb_Student;
            private System.Windows.Forms.RadioButton rb_Teacher;
            private System.Windows.Forms.RadioButton rb_Admin;
            private System.Windows.Forms.Button btnLogin;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Button btnSetting;
            private System.Windows.Forms.ToolTip toolTip1;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.PictureBox pic_UserName;
            private System.Windows.Forms.PictureBox pic_Pwd;
        private System.ComponentModel.BackgroundWorker bW_LoadToLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPwd;
        public System.Windows.Forms.Label lbStatus;
    }
    }

