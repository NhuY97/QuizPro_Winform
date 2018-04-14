using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizPro_v._1._0.View.Student_Manager
{
    public partial class frmViewHistory : Form
    {
        BDStudentManager bd_StudentInfo;
        frmStudentMain frmParent;

        public BDStudentManager BD_StudentInfo
        {
            get { return bd_StudentInfo; }
            set { bd_StudentInfo = value; }
        }
        public frmViewHistory()
        {
            InitializeComponent();
        }
        public frmViewHistory(BDStudentManager BD_StudentInfo)
        {
            this.BD_StudentInfo = BD_StudentInfo;
            InitializeComponent();
        }
        public void ThisParent(frmStudentMain f)
        {
            frmParent = f;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            frmParent.LoadData();
            frmParent.Show();
            this.Dispose();
        }

        private void frmViewHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmParent.Show();
            this.Dispose();
        }

        private void frmViewHistory_Load(object sender, EventArgs e)
        {
            DataTable dt;
            try
            {
                dt = bd_StudentInfo.getExamHistory(DAL.Username);
            }
            catch { dt = null; }
            if(dt == null )
            {
                MessageBox.Show("Lỗi: " + DAL.Constance.ERROR);
                return;
            }
            lbMaHS.Text = "Mã HS " + DAL.Username;
            lbMarkAVG.Text = bd_StudentInfo.getAVGMark();
            if(dt != null)
            dataGridView1.DataSource = dt;
        }
    }
}
