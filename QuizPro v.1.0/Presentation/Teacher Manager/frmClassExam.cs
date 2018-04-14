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
    public partial class frmClassExam : Form
    {
        BDTeacherManager tcManager;
        string examID;
        public frmClassExam(string examID)
        {
            InitializeComponent();
            tcManager = new BDTeacherManager();
            this.examID = examID;
        }

        private void frmClassExam_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvClassNotExistInEX.Visible = false;
            dgvListClass.Visible = true;
            btnDeleteClass.Visible = true;
            btnAddClass.Visible = true;
            BtnCancle.Visible = false;
            btnOK.Visible = false;
            DataTable dt;
            try
            {
                // lấy danh sách lớp trong kỳ thi
                dt = tcManager.ListClassExam(examID);
            }
            catch { dt = null; }
            if(dt == null)
            {
                MessageBox.Show("Lỗi: " +DAL.Constance.ERROR);
                return;
            }
            dgvListClass.DataSource = dt;
            lbTitle.Text = "Danh sách lớp thi của kỳ thi " + examID;
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            dgvClassNotExistInEX.Visible = true;
            BtnCancle.Visible = true;
            btnOK.Visible = true;
            btnDeleteClass.Visible = false;
            dgvListClass.Visible = false;
            DataTable dt;
            try
            {
                // lấy danh sách lớp không nằm trong kỳ thi
               dt = tcManager.ListClassNotExistInExam(examID);
            }
            catch { dt = null; }
            if (dt == null)
            {
                MessageBox.Show("Lỗi: " + DAL.Constance.ERROR);
                return;
            }
            dgvClassNotExistInEX.DataSource = dt;
            lbTitle.Text = "Danh sách lớp không nằm trong kỳ thi";
        }

        // thêm lớp vào kỳ thi
        private void btnOK_Click(object sender, EventArgs e)
        {
            string listClassError = "";
            int i = 0;
            foreach (DataGridViewRow row in dgvClassNotExistInEX.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == "true")
                {
                    if (!tcManager.insertClassToExam(row.Cells[1].Value.ToString(), examID))
                    {
                        listClassError += "\n" + row.Cells[1].Value.ToString();
                    }
                    else i++;
                }
            }
            if (listClassError != "")
            {
                MessageBox.Show("Danh sách các lớp chưa thêm được: " + listClassError + "\n Error: " + tcManager.error, "QuizPro Version Beta");
            }
            MessageBox.Show("Đã thêm " + i + "lớp vào kỳ thi");
            LoadData();
        }

        // xóa lớp khỏi kỳ thi
        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach(DataGridViewRow r in dgvListClass.SelectedRows)
            {
                rows.Add(r);
            }
            foreach(DataGridViewCell c in dgvListClass.SelectedCells)
            {
                rows.Add(dgvListClass.Rows[c.RowIndex]);
            }
            rows.Distinct();
            string listClassError = "";
            int i = 0;
            foreach (DataGridViewRow r in rows)
            {
                if (r.Cells[0].Value == null || !tcManager.deleteClassExam(examID, r.Cells[0].Value.ToString()))
                {
                    listClassError += "\n" + r.Cells[1].Value.ToString();
                }
                else i++;
            }
            if (listClassError != "")
                {
                    MessageBox.Show("Danh sách các lớp chưa xóa được: " + listClassError + "\n Error: " + tcManager.error, "QuizPro Version Beta");
                }
                MessageBox.Show("Đã xóa " + i + "lớp trong kỳ thi");
                LoadData();
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
