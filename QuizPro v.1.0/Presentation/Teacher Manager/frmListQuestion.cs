using QuizPro_v._1._0.BLL;
using System;
using System.Collections;
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
    public partial class frmListQuestion : Form
    {
        string examID; //mã kỳ thi
        BDTeacherManager tcManager;
        public frmListQuestion(string examID)
        {
            InitializeComponent();
            this.examID = examID;
            tcManager = new BDTeacherManager();
        }

        private void frmListQuestion_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            DataTable dt;
            try
            {
                // Danh sách câu hỏi chưa có trong kỳ thi 
                dt = tcManager.ListQuestionToInsForExam(examID);
            }
            catch { dt = null; }
            if (dt == null)
            {
                MessageBox.Show("Lỗi: " + DAL.Constance.ERROR);
                return;
            }
            dataGridView1.DataSource = dt;
            lbTitle.Text += examID;
        }
        // thêm danh sách câu hỏi
        private void btnOK_Click(object sender, EventArgs e)
        {
            string listQuesError = "";
            int i = 0;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Cells[0].Value != null && row.Cells[0].Value.ToString() == "true")
                {
                    if (!tcManager.insertQuesToExam(row.Cells[1].Value.ToString(), examID))
                    {
                        listQuesError += "\n" + row.Cells[1].Value.ToString();
                    }
                    else i++;
                }
            }
            if(listQuesError != "")
            {
                MessageBox.Show("Danh sách các câu hỏi chưa thêm được: " + listQuesError + "\n Error: " + tcManager.error, "QuizPro Version Beta");
            }
            MessageBox.Show("Đã thêm " + i + "câu hỏi");
            LoadData();
        }
    }
}
