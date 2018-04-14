using QuizPro_v._1._0.BLL;
using QuizPro_v._1._0.Controller;
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
    public partial class frmImportQues : Form
    {
        // open file excel
        OpenFileDialog fopen;
        BDTeacherManager tcManager;
        public frmImportQues()
        {
            InitializeComponent();
            tcManager = new BDTeacherManager();
            fopen = new OpenFileDialog();
            fopen.FileOk += fOpenOKClick;
        }
        private void fOpenOKClick(Object sender, EventArgs e)
        {
            if (fopen.FileName == "")
            {
                lbFileName.Text = "Bạn chưa chọn File";
                return;
            }
            // tạo app excel, workbook từ filename và sheet đầu tiên của workbook đó
            lbFileName.Text = fopen.FileName;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application(); ;
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(fopen.FileName);
            Microsoft.Office.Interop.Excel.Worksheet workSheet = workBook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = workSheet.UsedRange;
            try
            {
                int rows = range.Rows.Count;
                int cols = range.Columns.Count;
                //get header
                for (int c = 1; c <= cols; c++)
                {
                    DataGridViewTextBoxColumn DGVColumn = new DataGridViewTextBoxColumn();
                    DGVColumn.Name = "Col" + c;
                    DGVColumn.HeaderText = range.Cells[1, c].Value == null || range.Cells[1, c].Value.ToString().Trim() == "" ? "": range.Cells[1, c].Value.ToString();
                    DGVColumn.Visible = true;
                    DGVColumn.Frozen = false;
                    DGVColumn.ReadOnly = false;
                    if (c == 1)
                    {
                        dgvQuestion.Rows.Clear();
                        dgvQuestion.Columns.Clear();
                    }
                    dgvQuestion.Columns.Add(DGVColumn);
                }
                //get row
                for (int r = 2; r <= rows; r++)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    for (int c = 1; c <= cols; c++)
                    {
                        DataGridViewCell cell = new DataGridViewTextBoxCell();
                        cell.Value = range.Cells[r, c].Value == null || range.Cells[r, c].Value.ToString().Trim() == "" ? "" : range.Cells[r, c].Value.ToString();
                        dgvRow.Cells.Add(cell);
                    }

                    dgvQuestion.Rows.Add(dgvRow);
                }

                btnOK.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                range.Clear();
                workSheet = null;
                workBook.Close();
                app.Quit();
                workBook = null;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            fopen.Filter = "(File Excel)|*.xlsx;*.xls";
            fopen.ShowDialog();
        }
        // hướng dẫn người dùng
        private void btnGuid_Click(object sender, EventArgs e)
        {
         MessageBox.Show("File excel gồm 1 sheet\nGồm 4 cột lần lượt là: nội dung câu hỏi, phương án 1, phương án 2, phương án 3, phương án 4, đáp án\nĐáp án là số thứ tự của phương án (từ 1 đến 4)\nVui lòng liên hệ www.facebook.com/yzenny97\n---Author TNT Nhu Y ---", "QuizPro version 1.0", MessageBoxButtons.OK);
        }

        private void frmImportQues_Load(object sender, EventArgs e)
        {
            cbSubject.DataSource = tcManager.getListSubject();
            cbSubject.ValueMember = "SubID";
            cbSubject.DisplayMember = "Subname";
        }
        // hiển thị nhóm nội dung cho từng môn học
        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTypeQues.DataSource = tcManager.getListTypeQuesOfSubj(cbSubject.SelectedValue.ToString());
            if(cbTypeQues.DataSource != null && ((DataTable)cbTypeQues.DataSource).Rows.Count > 0)
            {
            cbTypeQues.DisplayMember = "Typename";
            cbTypeQues.ValueMember = "TypeID";
            cbTypeQues.SelectedIndex = 0;
            }
            else cbTypeQues.Text = "";
            cbTypeQues.SelectedIndex = -1;
        }

        // lưu vào CSDL
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(cbTypeQues.SelectedValue == null || cbSubject.SelectedValue == null)
            {
                MessageBox.Show("Nội dung câu hỏi chưa được chọn!");
                return;
            }
            string subid = cbSubject.SelectedValue.ToString();
            string typequesid = cbTypeQues.SelectedValue.ToString();
            string quesContent;
            string option1;
            string option2;
            string option3;
            string option4;
            int iscorrect;
            string listQuesFail = "";
            for (int i = 0;i < dgvQuestion.Rows.Count; i++)
            {
                DataGridViewRow row = dgvQuestion.Rows[i];
                quesContent = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
                option1 = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                option2 = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
                option3 = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString();
                option4 = row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString();
                if(row.Cells[5].Value == null || !int.TryParse(row.Cells[5].Value.ToString(), out iscorrect))
                {
                    iscorrect = 0;
                }
                List<AnswerObj> listAns = new List<AnswerObj>();
                listAns.Add(new AnswerObj("",option1,false));
                listAns.Add(new AnswerObj("", option2, false));
                listAns.Add(new AnswerObj("", option3, false));
                listAns.Add(new AnswerObj("", option4, false));
                if (iscorrect > 0 && iscorrect < 5)
                    listAns.ElementAt(iscorrect - 1).IsCorrect = true; 
                if (!tcManager.insertQuestion(quesContent, cbTypeQues.SelectedValue.ToString()))
                {
                    listQuesFail += "\nCâu hỏi thứ " + (i + 1);
                }
                else
                {
                    string idquest = tcManager.getIdOfLastQuestion();
                    int id;
                    if(int.TryParse(idquest.Substring(2),out id))
                    {
                        id--;
                        if (id < 10) idquest = "QU00" + id;
                        else if (id < 100) idquest = "QU0" + id;
                        else idquest = id.ToString();
                        if (!tcManager.UpdateAnswer(listAns, idquest))
                        {
                            listQuesFail += "\nĐáp án câu hỏi thứ " + (i + 1);
                        }
                    }
                    else listQuesFail += "\nĐáp án câu hỏi thứ " + (i + 1);
                }
            }
            if (listQuesFail != "")
                MessageBox.Show("Danh sách lỗi : " + listQuesFail);
                    this.Dispose();
                    this.Close();
        }
    }
}
