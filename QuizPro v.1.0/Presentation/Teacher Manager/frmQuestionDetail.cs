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
    public partial class frmQuestionDetail : Form
    {
        string quesID, quesContent, typeName;
        bool isEditClick;
        BDTeacherManager bdTeacher;
        BDStudentManager stManager;
        List<AnswerObj> listAnswer;

        public frmQuestionDetail(string quesID, string quesContent, string typeName)
        {
            InitializeComponent();

            stManager = new BDStudentManager();
            bdTeacher = new BDTeacherManager();

            this.quesID = quesID;
            this.quesContent = quesContent;
            this.typeName = typeName;
            isEditClick = false;
        }

        private void frmQuestionDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        // lấy nội dung câu hỏi, nhóm nội dung và các phương án ứng với câu hỏi đó
        private void LoadData()
        {
            txtQuesContent.Text = quesContent;
            lbTypeName.Text = typeName;
            lableForContent.Text = "Nội dung câu hỏi " + quesID + ":";
            if (listAnswer != null)
                listAnswer.Clear();
            listAnswer = stManager.getAnswer(quesID);
            if (listAnswer.Count == 0 || listAnswer == null) return;
            ShowTextBoxAns(listAnswer.Count);
            for (int i = 0; i < listAnswer.Count; i++)
            {
                if (listAnswer.ElementAt(i).IsCorrect == true)
                {
                    cbAnswer.SelectedIndex = i;
                }
            }
        }
        // show giao diện theo số lượng phương án trong câu hỏi
        private void ShowTextBoxAns(int countAnw)
        {
            txtOptionA.Visible = false;
            txtOptionB.Visible = false;
            txtOptionC.Visible = false;
            txtOptionD.Visible = false;
            if (countAnw > 0)
            {
                txtOptionA.Text = listAnswer.ElementAt(0).AnswerName;
                txtOptionA.Tag = listAnswer.ElementAt(0).AnswerId;
                txtOptionA.Visible = true;
            }
            if (countAnw > 1)
            {
                txtOptionB.Text = listAnswer.ElementAt(1).AnswerName;
                txtOptionB.Tag = listAnswer.ElementAt(1).AnswerId;
                txtOptionB.Visible = true;
            }
            if (countAnw > 2)
            {
                txtOptionC.Text = listAnswer.ElementAt(2).AnswerName;
                txtOptionC.Tag = listAnswer.ElementAt(2).AnswerId;
                txtOptionC.Visible = true;
            }
            if (countAnw > 3)
            {
                txtOptionD.Text = listAnswer.ElementAt(3).AnswerName;
                txtOptionD.Tag = listAnswer.ElementAt(3).AnswerId;
                txtOptionD.Visible = true;
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            isEditClick = false;
            LoadData();
        }

        private void GetAnswerInfo()
        {
            listAnswer.Clear();
            listAnswer.Add(new AnswerObj(txtOptionA.Tag == null ? "" : txtOptionA.Tag.ToString(), txtOptionA.Text.Trim(), false));
            listAnswer.Add(new AnswerObj(txtOptionB.Tag == null ? "" : txtOptionB.Tag.ToString(), txtOptionB.Text.Trim(), false));
            listAnswer.Add(new AnswerObj(txtOptionC.Tag == null ? "" : txtOptionC.Tag.ToString(), txtOptionC.Text.Trim(), false));
            listAnswer.Add(new AnswerObj(txtOptionD.Tag == null ? "" : txtOptionD.Tag.ToString(), txtOptionD.Text.Trim(), false));
            AnswerObj ans = listAnswer.ElementAt(cbAnswer.SelectedIndex);
            ans.IsCorrect = true;
            listAnswer.Remove(ans);
            listAnswer.Add(ans);
        }

        // sửa câu hỏi
        private void btnEditQues_Click(object sender, EventArgs e)
        {
            //lưu thông tin đã sửa
            if (isEditClick)
            {
                if (cbAnswer.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn đáp án");
                    return;
                }
                chechComboboxAns();
                GetAnswerInfo();
                if (bdTeacher.UpdateQuestion(quesID, txtQuesContent.Text, cbTypeQues.SelectedValue.ToString()) & bdTeacher.UpdateAnswer(listAnswer, quesID))
                {
                    quesContent = txtQuesContent.Text;
                    typeName = cbTypeQues.Text;
                    lbTypeName.Text = typeName;
                    MessageBox.Show("Đã cập nhật thay đổi");
                }
                else
                {
                    MessageBox.Show("Lỗi " + bdTeacher.error, "Error");
                }
                isEditClick = false;
                LoadData();
            }
            else // cho phép sửa
            {
                isEditClick = true;
                LoadContent();
            }
            SetEditQuestionMode();
        }

        private void cbAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            chechComboboxAns();
        }
        // check validate
        private void chechComboboxAns()
        {
            bool check = true;
            switch (cbAnswer.SelectedIndex)
            {
                case 0:
                    if (txtOptionA.Text.Trim() == "")
                        check = false;
                    break;
                case 1:
                    if (txtOptionB.Text.Trim() == "")
                        check = false;
                    break;
                case 2:
                    if (txtOptionC.Text.Trim() == "")
                        check = false;
                    break;
                case 3:
                    if (txtOptionD.Text.Trim() == "")
                        check = false;
                    break;
            }
            if (!check)
            {
                MessageBox.Show("Phương án này rỗng!");
                cbAnswer.SelectedIndex = -1;
            }
        }

        private void txtOptionA_VisibleChanged(object sender, EventArgs e)
        {
            lbA.Visible = txtOptionA.Visible;
            if (!txtOptionA.Visible)
            {
                txtOptionA.Text = "";
                txtOptionA.Tag = null;
            }
        }

        private void txtOptionC_VisibleChanged(object sender, EventArgs e)
        {
            lbC.Visible = txtOptionC.Visible;
            if (!txtOptionC.Visible)
            {
                txtOptionC.Text = "";
                txtOptionC.Tag = null;
            }
        }
        private void txtOptionB_VisibleChanged(object sender, EventArgs e)
        {
            lbB.Visible = txtOptionB.Visible;
            if (!txtOptionB.Visible)
            {
                txtOptionB.Text = "";
                txtOptionB.Tag = null;
            }
        }

        private void txtOptionD_VisibleChanged(object sender, EventArgs e)
        {
            lbD.Visible = txtOptionD.Visible;
            if (!txtOptionD.Visible)
            {
                txtOptionD.Text = "";
                txtOptionD.Tag = null;
            }
        }

        private void SetEditQuestionMode()
        {
            if (isEditClick)
            {
                txtOptionA.Visible = true;
                txtOptionB.Visible = true;
                txtOptionC.Visible = true;
                txtOptionD.Visible = true;
            }
            txtQuesContent.ReadOnly = !isEditClick;
            txtOptionA.ReadOnly = !isEditClick;
            txtOptionB.ReadOnly = !isEditClick;
            txtOptionC.ReadOnly = !isEditClick;
            txtOptionD.ReadOnly = !isEditClick;
            cbAnswer.Enabled = isEditClick;
            txtQuesContent.ForeColor = isEditClick ? Color.White : Color.MediumSpringGreen;
            txtOptionA.ForeColor = isEditClick ? Color.White : Color.MediumSpringGreen;
            txtOptionB.ForeColor = isEditClick ? Color.White : Color.MediumSpringGreen;
            txtOptionC.ForeColor = isEditClick ? Color.White : Color.MediumSpringGreen;
            txtOptionD.ForeColor = isEditClick ? Color.White : Color.MediumSpringGreen;
            lbTypeName.Visible = !isEditClick;
            cbTypeQues.Visible = isEditClick;
            btnCancle.Visible = isEditClick;
            btnEditQues.Text = isEditClick ? "Lưu lại" : "Chỉnh sửa";
        }

        void LoadContent()
        {
            DataTable dt = bdTeacher.getListTypeName();
            cbTypeQues.DataSource = dt;
            cbTypeQues.DisplayMember = "Typename";
            cbTypeQues.ValueMember = "TypeID";
            cbTypeQues.Text = typeName;
        }
    }
}
