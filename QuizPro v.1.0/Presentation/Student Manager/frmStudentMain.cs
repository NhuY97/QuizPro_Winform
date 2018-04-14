using QuizPro_v._1._0.View.Student_Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizPro_v._1._0
{
    public partial class frmStudentMain : Form
    {
        //form đăng nhập
        Frm_LoginSystem frmParent;
        BDStudentManager bd_StudentInfo;
        public BDStudentManager BD_StudentInfo
        {
            get { return bd_StudentInfo; }
            set { bd_StudentInfo = value; }
        }

        public frmStudentMain()
        {
            InitializeComponent();
        }

        private void frmStudentMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            BD_StudentInfo = new BDStudentManager();
            try
            {
                lb_fullname.Text = "Hello " + BD_StudentInfo.getFullname(DAL.Username);
            }
            catch
            {
                MessageBox.Show("Lỗi khi lấy tên user: "+ DAL.Constance.ERROR);
            }
        }
        //khong the goi form login truc tiep nen dung cach nay
        public void MyActiveForm(Frm_LoginSystem f)
        {
            this.Show();
            frmParent = f;
        }

        private void frmStudentMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            string error = (new UpdateUserStatus()).ChangeStatus(DAL.Username);
            if (error != "")
            {
                MessageBox.Show(this, error, "Error System");
            }
        }

        private void tileItemQuit_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure?", "QuizPro v.1.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

        private void tileItemSignOut_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frmParent.Show();
            this.Close();
        }

        private void tileItemInfo_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frmUserInfo frm = new frmUserInfo();
            frm.ShowDialog();
        }

        private void tileItemExam_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frmViewExam f = new frmViewExam(BD_StudentInfo);
            f.ThisParent(this);
            f.Show();
            this.Hide();
        }

        private void tileItem_History_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frmViewHistory f = new frmViewHistory(BD_StudentInfo);
            f.ThisParent(this);
            f.Show();
            this.Hide();
        }
    }
}
