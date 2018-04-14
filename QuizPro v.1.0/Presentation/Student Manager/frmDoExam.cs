using QuizPro_v._1._0.Controller;
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

namespace QuizPro_v._1._0.View.Student_Manager
{
    public partial class frmDoExam : Form
    {
        BDStudentManager bdStudentManager;
        ArrayList listQuestion;
        string examID;
        string examName;
        frmStudentMain frmParent;
        int timeTest;
        //thoi gian lam bai thi luc dau
        int timeTestBefore;
        //doi mau Time remaining neu thoi gian con lai < 5phut
        bool isColorChanged;
        //map luu noi dung phuong an dung
        Hashtable mapcorrectAnswer;
        //mang bool co cac phan tu la cau hoi tuong ung
        //0 neu user chon sai, nguoc lai la 1
        bool[] listStateAnswer;
        //mang luu lai radio btn da chon
        Hashtable mapRadioBtnChoosed;
        int TotalNumberQuestion;
        int currentQuestionNo;
        Button[] listButton;
        public frmDoExam(string examID, string examName, int timeTest)
        {
            InitializeComponent();

            isColorChanged = false;
            this.ExamID = examID;
            this.examName = examName;
            this.TimeTest = timeTest;
            bdStudentManager = new BDStudentManager();
        }
        public string ExamName { get => examName; set => examName = value; }
        public string ExamID { get => examID; set => examID = value; }
        public int TimeTest { get => timeTest; set => timeTest = value; }

        private void frmDoExam_Load(object sender, EventArgs e)
        {
            listQuestion = getlistQuestion();
            TotalNumberQuestion = listQuestion.Count;
            listButton = new Button[TotalNumberQuestion];
            mapcorrectAnswer = new Hashtable();
            mapRadioBtnChoosed = new Hashtable();
            listStateAnswer = new bool[TotalNumberQuestion];
            LoadBtnNumQues(listQuestion); //note --- button dau tien (cau hoi dau tien) duoc perform sau khi load
            lbExamName.Text = ExamName;
            ShowTimeRemaining();
            timeTestBefore = TimeTest;
            timer1.Start();
        }

        private void ShowTimeRemaining()
        {
            lbTimeRemaining.Text = TimeTest / 60 + ":" + TimeTest % 60;
        }
        public void ThisParent(frmStudentMain f)
        {
            frmParent = f;
        }

        private void LoadQuestion(int QuesNo)
        {
            ArrayList listAnswer;
            currentQuestionNo = --QuesNo;
            try
            {
                listAnswer = getListAnswer(((QuestionObj)listQuestion[QuesNo]).QuesId.ToString());
                lbQuesName.Text = ((QuestionObj)listQuestion[QuesNo]).QuesName.ToString();
            }
            catch
            {
                return;
            }
            rOptionA.Visible = false;
            rOptionB.Visible = false;
            rOptionC.Visible = false;
            rOptionD.Visible = false;

            rOptionA.Checked = false;
            rOptionB.Checked = false;
            rOptionC.Checked = false;
            rOptionD.Checked = false;
            try
            {
                ((RadioButton)mapRadioBtnChoosed[currentQuestionNo]).Checked = true;
            }
            catch
            { }
            for (int i = 0; i < listAnswer.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        rOptionA.Text = ((AnswerObj)listAnswer[i]).AnswerName;
                        rOptionA.Visible = true;
                        break;
                    case 1:
                        rOptionB.Text = ((AnswerObj)listAnswer[i]).AnswerName;
                        rOptionB.Visible = true;
                        break;
                    case 2:
                        rOptionC.Text = ((AnswerObj)listAnswer[i]).AnswerName;
                        rOptionC.Visible = true;
                        break;
                    default:
                        rOptionD.Text = ((AnswerObj)listAnswer[i]).AnswerName;
                        rOptionD.Visible = true;
                        break;
                }
            }
        }

        private void LoadBtnNumQues(ArrayList listQuestion)
        {
            pnlNumQues.Controls.Clear();
            int btnwidth = 60;
            int btnHeight = 30;

            for (int i = 0; i < TotalNumberQuestion; i++)
            {
                listButton[i] = new Button();
                listButton[i].Text = "Câu " + (i + 1).ToString();
                listButton[i].Click += btnQues_Click;
                listButton[i].Size = new Size(btnwidth, btnHeight);
                listButton[i].BackColor = Color.MediumSlateBlue;
                listButton[i].ForeColor = Color.White;
                if (i == 0) listButton[i].PerformClick();
                pnlNumQues.Controls.Add(listButton[i]);
            }
        }
        private void btnQues_Click(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            LoadQuestion(int.Parse(btn.Text.Split(' ')[1].ToString()));
        }

        private ArrayList getlistQuestion()
        {
            ArrayList listQuestion = new ArrayList();
            List<QuestionObj> listQues = bdStudentManager.getQuestion(ExamID);
            if (listQues == null)
            {
                MessageBox.Show("Lỗi khi load câu hỏi: " + DAL.Constance.ERROR);
                return null;
            }
            foreach (QuestionObj q in listQues)
            {
                listQuestion.Add(q);
            }
            return listQuestion;
        }

        private ArrayList getListAnswer(string quesId)
        {
            ArrayList lstAnswer = new ArrayList();
            bool isAdded = false;
            List<AnswerObj> listAns = bdStudentManager.getAnswer(quesId);
            if (listAns == null)
            {
                MessageBox.Show("Lỗi khi load phương án: " + DAL.Constance.ERROR);
                return null;
            }
            foreach (AnswerObj ans in listAns)
            {
                lstAnswer.Add(ans);
                if (ans.IsCorrect && !isAdded)
                {
                    if(!mapcorrectAnswer.ContainsKey(currentQuestionNo))
                    mapcorrectAnswer.Add(currentQuestionNo, ans.AnswerName);
                }
            }
            return lstAnswer;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Không thể làm lại bài thi sau khi thoát!\n Bạn có đồng ý thoát?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Submit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeTest--;
            if (TimeTest > 0)
            {
                if (TimeTest < 300 && !isColorChanged)
                {
                    lbTimeRemaining.ForeColor = Color.Red;
                }
                ShowTimeRemaining();
            }
            else
            {
                ((Timer)sender).Stop();
                btnSubmit.Click -= btnSubmit_Click;
                lbTimeRemaining.Text = "Hết giờ!";
                Submit();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vẫn còn " + TimeTest / 60 + " phút " + TimeTest % 60 + " giây!\n Bạn có muốn nộp bài? ", "QuizPro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                Submit();
            }
        }
        private void Submit()
        {
            timer1.Stop();
            int timeComplete = timeTestBefore - TimeTest;
            string strTimeComplete = timeComplete / 60 + " phút " + timeComplete % 60 + " giây";
            int numberOfCorrectAns = getNumberOfCorrectAns();
            double mark = Math.Round(((double)numberOfCorrectAns / TotalNumberQuestion) * 10, 2);
            if (!bdStudentManager.submitExam(ExamID, mark, strTimeComplete))
            {
                MessageBox.Show("Error: " + bdStudentManager.error + "\nVui lòng liên hệ giáo viên!", "Error System", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Bạn đã hoàn thành bài thi với thời gian là " + strTimeComplete + "\nSố câu hỏi đúng: " + numberOfCorrectAns + "/" + TotalNumberQuestion + "\nĐiểm: " + mark);
            }
            this.Dispose();
            frmParent.Show();
        }
        private int getNumberOfCorrectAns()
        {
            int numberOfCorrectAns = 0;
            foreach (bool b in listStateAnswer)
            {
                if (b) numberOfCorrectAns++;
            }
            return numberOfCorrectAns;
        }
        private void rOption_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                listButton[currentQuestionNo].BackColor = Color.Green;
                if (mapRadioBtnChoosed.ContainsKey(currentQuestionNo))
                {
                    mapRadioBtnChoosed[currentQuestionNo] = radio;
                }
                else mapRadioBtnChoosed.Add(currentQuestionNo,radio);

                if (radio.Text == mapcorrectAnswer[currentQuestionNo].ToString())
                {
                    listStateAnswer[currentQuestionNo] = true;
                }
                else listStateAnswer[currentQuestionNo] = false;
            }
        }
    }
}
