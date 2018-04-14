using QuizPro_v._1._0.Presentation.Teacher_Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuizPro_v._1._0
{

    public partial class Frm_LoginSystem : DevExpress.XtraEditors.XtraForm
    {
        // form setting tài khoản máy chủ (sql server)
        FrmSettingSystem frmSetting;
        //trạng thái đăng nhập
        int status;
        public Frm_LoginSystem()
        {
            InitializeComponent();
        }

        //khởi chạy background worker
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!bW_LoadToLogin.IsBusy)
            bW_LoadToLogin.RunWorkerAsync();
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            // mở form setting
            if (frmSetting == null)
                frmSetting = new FrmSettingSystem(this);
            frmSetting.ShowDialog();
        }

        //validate username và password người dùng nhập
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
                pic_UserName.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources._false;
            else
                pic_UserName.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources._true;
            pic_UserName.Visible = true;
        }

        private void txtPwd_Leave(object sender, EventArgs e)
        {
            if (txtPwd.Text.Length < 5)
                pic_Pwd.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources._false;
            else
                pic_Pwd.BackgroundImage = global::QuizPro_v._1._0.Properties.Resources._true;
            pic_Pwd.Visible = true;
        }

        private void Frm_LoginSystem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.PerformClick();
            }
        }

        private void bW_LoadToLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            AccessData();
        }
        private void AccessData()
        {
            try
            {
                // lấy chuỗi kết nối từ form setting
                frmSetting.dblogin = new DBLoginSystem(frmSetting.StrConnection);
            }
            
            catch (NullReferenceException nre) { Console.WriteLine(nre.Message); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            if (rb_Student.Checked)
                DAL.Rolename = rb_Student.Text.ToLower();
            else if (rb_Teacher.Checked)
                DAL.Rolename = rb_Teacher.Text.ToLower();
            else if (rb_Admin.Checked)
                DAL.Rolename = rb_Admin.Text.ToLower();

            try
            {
                DAL.Username = txtUsername.Text;
                DAL.Password = txtPwd.Text;
                // mã hóa password
                status = frmSetting.dblogin.isConnect(txtUsername.Text.Trim(), Encrypter.Encrypt(txtPwd.Text), DAL.Rolename);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = (int)DBLoginSystem.connStatus.notconnect;
            }

        }
        private void bW_LoadToLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (status == (int)DBLoginSystem.connStatus.success)
            {
                if (rb_Student.Checked)
                {
                    //khoi tao va truyen Data cho frmStudentMain
                    frmStudentMain frmStudent = new frmStudentMain();
                    frmStudent.MyActiveForm(this);
                }
                else
                    if (rb_Admin.Checked)
                {
                    //khoi tao va truyen Data cho frmAdminMain
                    frmAdminMain frmAdmin = new frmAdminMain();
                    frmAdmin.MyActiveForm(this);
                }
                else if (rb_Teacher.Checked)
                {
                    //khoi tao va truyen Data cho frmTeacher_Main
                    frmTeacher_Main frmTeacher = new frmTeacher_Main();
                    frmTeacher.MyActiveForm(this);
                }

                this.txtPwd.Clear();
                this.Hide();
            }
            else if (status == (int)DBLoginSystem.connStatus.fail)
            {
                MessageBox.Show(this, "Tài khoản không chính xác hoặc đã được đăng nhập\nVui lòng kiểm tra lại", "QuizPro Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
            }
            else
            {
                // mở lại form setting
                if (frmSetting == null)
                    frmSetting = new FrmSettingSystem(this);
                frmSetting.ShowDialog();
                btnLogin.PerformClick();
            }
        }
    }
}
