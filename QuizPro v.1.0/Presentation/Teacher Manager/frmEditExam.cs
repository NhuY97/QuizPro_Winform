using QuizPro_v._1._0.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizPro_v._1._0.Presentation.Teacher_Manager
{
    public partial class frmEditExam : Form
    {
        string examid; // mã kỳ thi
        string examname; // tên kỳ thi
        int timetest; // thời gian thi (phút)
        DateTime datetest; // ngày thi
        BDTeacherManager tcManager;
        bool isEdit; // có phải là sửa hay không

        //constructor cho thao tác sửa kỳ thi
        public frmEditExam(DataGridViewRow row)
        {
            InitializeComponent();
            examid = row.Cells["ExID"].Value.ToString().Trim();
            examname = row.Cells["ExName"].Value.ToString().Trim();
            if (!int.TryParse(row.Cells["TimeTest"].Value.ToString().Trim(),out timetest) || !DateTime.TryParse(row.Cells["DateTest"].Value.ToString().Trim(), out datetest))
            {
                timetest = 0;
                datetest = new DateTime(2000, 01, 01);
            }
            txtExName.Text = examname;
            cbTimeTest.Text = timetest.ToString();
            dtpDateStart.Value = datetest > dtpDateStart.MinDate ? datetest: new DateTime(2000, 01, 01);
            tcManager = new BDTeacherManager();
            isEdit = true;
        }
        // constructor cho thao tác thêm mới
        public frmEditExam()
        {
            InitializeComponent();
            tcManager = new BDTeacherManager();
            dtpDateStart.Value = DateTime.Now;
            lbTitle.Text = "Create New Exam";
            cbTimeTest.SelectedIndex = 2;
            isEdit = false;
        }
        // lưu vào CSDL
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckValidateForm()) return;
            lbError.Text = "";
            examname = txtExName.Text;
            datetest = dtpDateStart.Value;
            if (isEdit ? !tcManager.UpdateExam(examid, examname, timetest, datetest): !tcManager.insertExam(examname, timetest, datetest))
            {
                lbError.Text = tcManager.error;
            }
            else
            {
                MessageBox.Show("Successfuly!");
                this.Close();
            }
        }
        // kiểm tra validate cho form
        private bool CheckValidateForm()
        {
            if (txtExName.Text.Trim() == "" || txtExName.Text.Trim().Length < 5)
            {
                lbError.Text = "Error: Tên kỳ thi không được để trống và tối thiểu 5 ký tự";
                txtExName.Focus();
                return false;
            }
            if (!int.TryParse(cbTimeTest.Text, out timetest))
            {
                lbError.Text = "Error: Thời gian thi không hợp lệ";
                cbTimeTest.Focus();
                return false;
            }
            if (dtpDateStart.Value == null)
            {
                lbError.Text = "Error: Ngày bắt đầu thi không hợp lệ";
                dtpDateStart.Focus();
                return false; ;
            }
            return true;
        }
    }
}
