namespace QuizPro_v._1._0.View.Admin_Manager
{
    partial class frmAdminEditUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.dTPbirthday = new System.Windows.Forms.DateTimePicker();
            this.cbbGender = new System.Windows.Forms.ComboBox();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.cbbRolename = new System.Windows.Forms.ComboBox();
            this.lbRole = new System.Windows.Forms.Label();
            this.lbTitleClass = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.btnSubject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(51, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(51, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fullname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(51, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gender";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(51, 234);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Birthday";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(129, 18);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(186, 31);
            this.label.TabIndex = 4;
            this.label.Text = "Edit User Info";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(135, 69);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(262, 24);
            this.txtUsername.TabIndex = 5;
            // 
            // txtFullname
            // 
            this.txtFullname.Location = new System.Drawing.Point(135, 124);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(262, 24);
            this.txtFullname.TabIndex = 6;
            // 
            // dTPbirthday
            // 
            this.dTPbirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPbirthday.Location = new System.Drawing.Point(135, 229);
            this.dTPbirthday.MaxDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dTPbirthday.Name = "dTPbirthday";
            this.dTPbirthday.Size = new System.Drawing.Size(123, 24);
            this.dTPbirthday.TabIndex = 7;
            this.dTPbirthday.Value = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            // 
            // cbbGender
            // 
            this.cbbGender.FormattingEnabled = true;
            this.cbbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbbGender.Location = new System.Drawing.Point(135, 177);
            this.cbbGender.Name = "cbbGender";
            this.cbbGender.Size = new System.Drawing.Size(89, 26);
            this.cbbGender.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(322, 435);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Update";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbbRolename
            // 
            this.cbbRolename.FormattingEnabled = true;
            this.cbbRolename.Items.AddRange(new object[] {
            "student",
            "teacher",
            "admin"});
            this.cbbRolename.Location = new System.Drawing.Point(135, 275);
            this.cbbRolename.Name = "cbbRolename";
            this.cbbRolename.Size = new System.Drawing.Size(123, 26);
            this.cbbRolename.TabIndex = 10;
            this.cbbRolename.SelectedIndexChanged += new System.EventHandler(this.cbbRolename_SelectedIndexChanged);
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.BackColor = System.Drawing.Color.Transparent;
            this.lbRole.Location = new System.Drawing.Point(51, 278);
            this.lbRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(39, 18);
            this.lbRole.TabIndex = 11;
            this.lbRole.Text = "Role";
            // 
            // lbTitleClass
            // 
            this.lbTitleClass.AutoSize = true;
            this.lbTitleClass.BackColor = System.Drawing.Color.Transparent;
            this.lbTitleClass.Location = new System.Drawing.Point(51, 337);
            this.lbTitleClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitleClass.Name = "lbTitleClass";
            this.lbTitleClass.Size = new System.Drawing.Size(33, 18);
            this.lbTitleClass.TabIndex = 13;
            this.lbTitleClass.Text = "Lớp";
            this.lbTitleClass.Visible = false;
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Items.AddRange(new object[] {
            "student",
            "teacher",
            "admin"});
            this.cbClass.Location = new System.Drawing.Point(135, 334);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(123, 26);
            this.cbClass.TabIndex = 12;
            this.cbClass.Visible = false;
            this.cbClass.SelectedIndexChanged += new System.EventHandler(this.cbClass_SelectedIndexChanged);
            this.cbClass.VisibleChanged += new System.EventHandler(this.cbClass_VisibleChanged);
            // 
            // btnSubject
            // 
            this.btnSubject.Location = new System.Drawing.Point(54, 382);
            this.btnSubject.Name = "btnSubject";
            this.btnSubject.Size = new System.Drawing.Size(144, 33);
            this.btnSubject.TabIndex = 14;
            this.btnSubject.Text = "Chọn môn học";
            this.btnSubject.UseVisualStyleBackColor = true;
            this.btnSubject.Visible = false;
            this.btnSubject.Click += new System.EventHandler(this.btnSubject_Click);
            // 
            // frmAdminEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources.background_with_wavy_lines1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(418, 470);
            this.Controls.Add(this.btnSubject);
            this.Controls.Add(this.lbTitleClass);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.lbRole);
            this.Controls.Add(this.cbbRolename);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbbGender);
            this.Controls.Add(this.dTPbirthday);
            this.Controls.Add(this.txtFullname);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAdminEditUser";
            this.Text = "QuizPro v.1.0";
            this.Load += new System.EventHandler(this.frmAdminEditUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.DateTimePicker dTPbirthday;
        private System.Windows.Forms.ComboBox cbbGender;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.ComboBox cbbRolename;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.Label lbTitleClass;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Button btnSubject;
    }
}