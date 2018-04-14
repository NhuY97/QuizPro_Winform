using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizPro_MyUC;
using QuizPro_v._1._0.View.Student_Manager;

namespace QuizPro_v._1._0
{
    public partial class frmViewExam : Form
    {
        BDStudentManager bd_StudentInfo;
        frmStudentMain frmParent;

        public BDStudentManager BD_StudentInfo
        {
            get { return bd_StudentInfo; }
            set { bd_StudentInfo = value; }
        }

        public frmViewExam(BDStudentManager BD_StudentInfo)
        {
            this.BD_StudentInfo = BD_StudentInfo;
            InitializeComponent();
        }

        public void ThisParent(frmStudentMain f)
        {
            frmParent = f;
        }
        // lấy danh sách các môn thi chưa thi
        private void frmStudentMain_Load(object sender, EventArgs e)
        {
            DataTable dt;
            try
            {
                dt = bd_StudentInfo.getExamInfo(DAL.Username);
            }
            catch
            {
                dt = null;
            }
            if(dt == null)
            {
                MessageBox.Show("Lỗi: " + DAL.Constance.ERROR);
                return;
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                lbMaHS.Text = "Mã HS " + DAL.Username + " Class "+dt.Rows[0].ItemArray[0].ToString();
                int _locationY = 5;
                foreach (DataRow row in dt.Rows)
                {
                    if (row.ItemArray[6].ToString() == "chưa thi" || row.ItemArray[6].ToString() == "đang thi")
                    {
                        int totalSecond;
                        try
                        {
                            totalSecond = (int)row.ItemArray[7];
                            if (totalSecond < 0)
                            {
                                totalSecond = 0;
                            }
                        }
                        catch { totalSecond = 0; }
                        MyUC_ExamInfo MyEX = new MyUC_ExamInfo(totalSecond);
                        //get ExamID and Time Test
                        MyEX.Tag = row.ItemArray[5].ToString() + "+" + row.ItemArray[2];
                        MyEX.ExamName = row.ItemArray[1].ToString();
                        MyEX.DateTimeEx = row.ItemArray[3].ToString();
                        MyEX.SubName = row.ItemArray[4].ToString();
                        MyEX.Location = new Point(5, _locationY);
                        MyEX.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                        MyEX.Size = new Size(680, 127);
                        pn_Container.Controls.Add(MyEX);
                        _locationY += MyEX.Size.Height + 5;
                        MyEX.letsGoClicked += myUC_ExamInfo1_letsGoClicked;
                    }
                }
            }
        }


        private void myUC_ExamInfo1_letsGoClicked(object sender, EventArgs e)
        {
            MyUC_ExamInfo exInfo = sender as MyUC_ExamInfo;
            string[] str = exInfo.Tag.ToString().Split('+');
            string examId = str[0];
            int timeTest;
            if (!int.TryParse(str[1], out timeTest))
            {
                timeTest = 0;
            }
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Now - DateTime.Parse(exInfo.DateTimeEx);
            timeTest = timeTest * 60 - (ts.Seconds-1);
            if (timeTest < 0) timeTest = 0;
            frmDoExam frm = new frmDoExam(examId, exInfo.ExamName,timeTest);
            frm.Show();
            frm.ThisParent(frmParent);
            
            this.Hide();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            frmParent.LoadData();
            frmParent.Show();
            this.Dispose();
        }

        private void frmViewExam_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmParent.Show();
            this.Dispose();
        }
    }
}
