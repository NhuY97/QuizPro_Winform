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
    public partial class frmTeacher_Main : Form
    {
        DataTable dt;
        Frm_LoginSystem frmParent;
        bool frmParentStatus;
        BDTeacherManager tcManager;
        BDAdminManager adManager;
        bool isEyeOpen; // chế độ ẩn hiện mật khẩu
        bool isResize; // form có bị resize không
        static int _pageSize = 20; // số lượng entry của từng trang
        int pageIndex; // số thứ tự trang
        int RecordNo = 0; // tổng số dòng (lấy từ kết quả query trả về)
        int whichObj; // đối tượng cần hiển thị
        bool isViewExam; // có phải đang xem kỳ thi không
        bool isClickDetailBtn; // có phải đang xem câu hỏi trong đề thi đó không
        //
        string quesID, quesContent, typeName, examID;
        public frmTeacher_Main()
        {
            InitializeComponent();
            isViewExam = false;
            isEyeOpen = true;
            isResize = false;
            isClickDetailBtn = false;
            adManager = new BDAdminManager();
            tcManager = new BDTeacherManager();
        }

        public void MyActiveForm(Frm_LoginSystem f)
        {
            this.Show();
            frmParent = f;
            frmParentStatus = false;
        }
        // mở form import câu hỏi
        private void btnImportQuestion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmImportQues frm = new frmImportQues();
            frm.ShowDialog();
            btnListQuestion.PerformClick();
        }

        // xóa dòng đã chọn
        private void btnDeleteUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(!dgvContainerQues.Visible && !dgvContainerExam.Visible)
            {
                return;
            }
            if (pnChangePwd.Visible == true)
                pnChangePwd.Visible = false;
            string strResult = "";
            int rowCompleted = 0;
            List<DataGridViewRow> ListRow = new List<DataGridViewRow>();
            if(dgvContainerQues.Visible)
                ListRow = getListRowSelected(dgvContainerQues);
            else
            {
                ListRow = getListRowSelected(dgvContainerExam);
            }
            if (ListRow == null)
            {
                string ms = dgvContainerQues.Visible ? "câu hỏi" : "kỳ thi";
                MessageBox.Show("Không có " + ms +" nào được chọn hoặc đã xảy ra lỗi\nVui lòng kiểm trai lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            foreach (DataGridViewRow Row in ListRow)
            {
                string id = Row.Cells[1].Value.ToString();

                try
                {
                    bool execResult = false ;
                    if (!isViewExam)
                    {
                        execResult = tcManager.DeleteQuestion(id);
                    }
                    else if (dgvContainerQues.Visible)
                    {
                        execResult = tcManager.DeleteQuestionInExam(id,tcManager.Examid);
                    }
                    else
                    {
                        execResult = tcManager.DeleteExam(id);
                    }
                    if (execResult)
                    {
                        strResult += id + ": Complete\n";
                        rowCompleted++;
                    }
                    else
                    {
                        strResult += id + ": Fail\n";
                        MessageBox.Show(tcManager.error);
                    }
                }
                catch
                {
                    strResult += id + ": Fail\n";
                }
            }
            strResult += "Total: " + rowCompleted + "/" + ListRow.Count;
            MessageBox.Show(strResult, "Result List", MessageBoxButtons.OK);
            LoadData(pageIndex);
        }

        //danh sách dòng đã chọn
        private List<DataGridViewRow> getListRowSelected(DataGridView dgv)
        {
            List<DataGridViewRow> ListRow = new List<DataGridViewRow>();
            if (dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.SelectedRows)
                    ListRow.Add(row);
            }
            else if (dgv.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    ListRow.Add(dgv.Rows[cell.RowIndex]);
                }
                ListRow = ListRow.Distinct().ToList();
            }
            else
            {
                ListRow = null;
            }
            if (ListRow != null)
            {
                examID = ListRow.FirstOrDefault().Cells[1].Value.ToString();
            }
            return ListRow;
        }

        private void frmTeacher_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            string error = (new UpdateUserStatus()).ChangeStatus(DAL.Username);
            if (error != "")
            {
                MessageBox.Show(this, error, "Error System");
            }
            if (!frmParentStatus)
                frmParent.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmParentStatus = true;
            frmParent.Show();
            this.Close();
        }

        private void btnChangePwd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lbTitle.Text= "";
            dgvContainerExam.Visible = false;
            dgvContainerQues.Visible = false;
            pnChangePwd.Visible = true;
        }
        // thay đổi hiển thị password
        private void btnEye1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            Image imgEyeOpen = global::QuizPro_v._1._0.Properties.Resources.eyeOpen;
            Image imgEyeClose = global::QuizPro_v._1._0.Properties.Resources.eyeClose;
            if (isEyeOpen)
            {
                btn.BackgroundImage = imgEyeClose;
                isEyeOpen = false;
            }
            else
            {
                btn.BackgroundImage = imgEyeOpen;
                isEyeOpen = true;
            }
            foreach (Control ct in pnChangePwd.Controls)
            {
                if (ct.Name.ToString() == btn.Tag.ToString())
                {
                    System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)ct;
                    tb.UseSystemPasswordChar = tb.UseSystemPasswordChar == true ? false : true;
                    return;
                }
            }
        }
        // validate dữ liệu
        private bool checkPwd(string pwd)
        {
            foreach (char c in pwd)
            {
                if (c < 48 || (c > 57 && c < 65) || (c > 90 && c < 97) || c > 122)
                {
                    return false;
                }
            }
            return true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (Control ct in pnChangePwd.Controls)
            {
                System.Windows.Forms.TextBox txb;
                try
                {
                    txb = (System.Windows.Forms.TextBox)ct;
                }
                catch { continue; }
                if (txb.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                    txb.Focus();
                    return;
                }
                if (!checkPwd(txb.Text))
                {
                    MessageBox.Show("Mật khẩu không được chứa ký tự đặc biệt", "Thông báo", MessageBoxButtons.OK);
                    txb.Focus();
                    return;
                }
            }
            if (txtNewPwd.Text == txtOldPwd.Text)
            {
                MessageBox.Show("Mật khẩu mới không được phép trùng với mật khẩu cũ", "Thông báo", MessageBoxButtons.OK);
                txtNewPwd.Focus();
                return;
            }
            if (txtNewPwd2.Text != txtNewPwd.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp", "Thông báo", MessageBoxButtons.OK);
                txtNewPwd2.Focus();
                return;
            }
            if (txtNewPwd.Text.Length < 5)
            {
                MessageBox.Show("Mật khẩu mới quá ngắn", "Thông báo", MessageBoxButtons.OK);
                txtNewPwd.Focus();
                return;
            }
            if (txtOldPwd.Text == DAL.Password)
                if (adManager.changePwd(DAL.Username, txtNewPwd.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                    DAL.Password = txtNewPwd.Text;
                    txtOldPwd.Text = txtNewPwd.Text = txtNewPwd2.Text = "";
                }
                else MessageBox.Show(adManager.error, "Error");
            else MessageBox.Show("Mật khẩu cũ không đúng, vui lòng kiểm tra lại!", "Thông báo");
        }

        private void LoadData(int pageIndex)
        {
            RecordNo = 0;
            dt = new System.Data.DataTable();
            if(isViewExam && isClickDetailBtn)
            {
                whichObj = (int)BDTeacherManager.WhichObj.QUESTIONSOFEXAM;
                tcManager.Examid = examID == null ? "":examID;
                using (dt = tcManager.getListObj(whichObj, pageIndex, _pageSize, ref RecordNo))
                {
                    dgvContainerQues.DataSource = dt;
                }
            }
            else if(isViewExam)
                using (dt = tcManager.getListObj(whichObj, pageIndex, _pageSize, ref RecordNo))
                {
                
                    dgvContainerExam.DataSource = dt;
                }
            else
            {
                using (dt = tcManager.getListObj(whichObj, pageIndex, _pageSize, ref RecordNo))
                {

                    dgvContainerQues.DataSource = dt;
                }
            }
        }

        private void SetPanelPage()
        {
            pnPage.Controls.Clear();
            int page = RecordNo / _pageSize;
            //find total btn width
            //width of each btn = 47px
            //margin: 10px
            int btnwidth = (page + 1) * 47 + page * 10;
            while (btnwidth >= pnPage.Width - 104 && !isResize)
            {
                if (RecordNo > 3000)
                    _pageSize += 130;
                else if (RecordNo > 2000)
                    _pageSize += 80;
                else if (RecordNo > 1000)
                    _pageSize += 50;
                else if (RecordNo > 500)
                    _pageSize += 20;
                else _pageSize += 5;
                page = RecordNo / _pageSize;
                btnwidth = (page + 1) * 47 + page * 10;
            }
            int VTx = pnPage.Width / 2 - btnwidth / 2;
            if (page > 0)
            {
                for (int i = 0; i <= page; i++)
                {
                    System.Windows.Forms.Button btnPage = new System.Windows.Forms.Button();
                    btnPage.Text = (i + 1).ToString();
                    btnPage.Click += BtnPage_Click;
                    btnPage.Size = new Size(47, 30);
                    btnPage.Location = new System.Drawing.Point(VTx + 10 * i + i * 47, 5);
                    btnPage.BackColor = Color.Gray;
                    btnPage.Anchor = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
                    if (i == 0) btnPage.BackColor = Color.Blue;
                    pnPage.Controls.Add(btnPage);
                }
                pnPage.Visible = true;
            }
            else pnPage.Visible = false;

        }

        private void resetBG()
        {
            foreach (System.Windows.Forms.Button btn in pnPage.Controls)
            {
                btn.BackColor = Color.Gray;
            }
        }

        private void BtnPage_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            pageIndex = int.Parse(btn.Text);
            resetBG();
            btn.BackColor = Color.Blue;
            LoadData(int.Parse(btn.Text.ToString()));
        }

        private void btnListQuestion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnChangePwd.Visible = false;
            dgvContainerExam.Visible = false;
            isClickDetailBtn = false;
            isViewExam = false;
            isResize = false;
            _pageSize = 20;
            whichObj = (int)BDTeacherManager.WhichObj.QUESTION;
            pageIndex = 1;
            LoadData(pageIndex);
            if (RecordNo == 0)
            {
                lbTitle.Text = "Không có câu hỏi nào trong hệ thống";
            }
            else
            {
                lbTitle.Text = "Danh sách tất cả câu hỏi trong môn học";
                dgvContainerQues.Visible = true;
                SetPanelPage();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isViewExam)
            {
                return;
            }
            DataGridViewRow row = getListRowSelected(dgvContainerExam).FirstOrDefault();
            frmEditExam frm = new frmEditExam(row);
            frm.ShowDialog();
            LoadData(pageIndex);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isViewExam)
            {
                getListRowSelected(dgvContainerExam).FirstOrDefault();
                frmListQuestion frm = new frmListQuestion(examID);
                frm.ShowDialog();
                LoadData(pageIndex);
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isViewExam) return;
            getListRowSelected(dgvContainerExam).FirstOrDefault();
            frmClassExam frm = new frmClassExam(examID);
            frm.ShowDialog();
            LoadData(pageIndex);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEditExam frm = new frmEditExam();
            frm.ShowDialog();
            if (dgvContainerExam.Visible)
                LoadData(pageIndex);
            else btnListExam.PerformClick();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmUserInfo().ShowDialog();
        }

        private void btnListExam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dgvContainerQues.Visible = false;
            pnChangePwd.Visible = false;
            isClickDetailBtn = false;
            isViewExam = true;
            isResize = false;
            _pageSize = 20;
            whichObj = (int)BDTeacherManager.WhichObj.EXAM;
            pageIndex = 1;
            LoadData(pageIndex);
            if(RecordNo == 0)
            {
                lbTitle.Text = "Bạn Chưa Tạo Kỳ Thi Nào";
            }
            else
            {
                dgvContainerExam.Visible = true;
                lbTitle.Text = "Tất Cả Kỳ Thi Bạn Đã Tạo";
                SetPanelPage();
            }
        }

        private void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData(pageIndex);
            SetPanelPage();
        }

        private void btnViewDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isClickDetailBtn = true;
            if (dgvContainerQues.Visible)
            {
                DataGridViewRow row;
                row = getListRowSelected(dgvContainerQues).FirstOrDefault();
                if (row == null) return;
                try
                {
                    quesID = row.Cells[1].Value.ToString();
                    quesContent = row.Cells[2].Value.ToString();
                    typeName = row.Cells[3].Value.ToString();
                    frmQuestionDetail frm = new frmQuestionDetail(quesID, quesContent, typeName);
                    frm.ShowDialog();
                    LoadData(pageIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi!\n" + ex.Message);
                }
            }
            else if (dgvContainerExam.Visible)
            {
                DataGridViewRow row;
                row = getListRowSelected(dgvContainerExam).FirstOrDefault();
                if (row == null) return;
                try
                {
                    LoadData(pageIndex);
                    dgvContainerQues.Visible = true;
                    lbTitle.Text = "Mã kỳ thi " + examID +": " + row.Cells["ExName"].Value.ToString().Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi!\n" + ex.Message);
                }
            }
        }
    }
}
