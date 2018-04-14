using QuizPro_v._1._0.Presentation.Admin_Manager;
using QuizPro_v._1._0.View.Admin_Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace QuizPro_v._1._0
{
    public partial class frmAdminMain : Form
    {
        // bảng chứa thông tin user và nhân bản của nó
        System.Data.DataTable dt, dtClone;
        BDAdminManager adManager;
        // phân trang: số lượng entry trong 1 trang
        static int _pageSize = 20;
        // số thứ tự trang
        int pageIndex;
        // tổng số record
        int RecordNo = 0;
        // user có quyền nào
        int whichUser;
        DataGridViewRow SelectedRow;
        // form đăng nhập
        Frm_LoginSystem frmParent;
        bool frmParentStatus;
        // form có bị resize không (để điều chỉnh page button)
        bool isResize = false;
        // mở, đóng xem mật khẩu
        bool isEyeOpen = true;
        public frmAdminMain()
        {
            InitializeComponent();
            adManager = new BDAdminManager();
        }

        private void LoadData(int pageIndex)
        {
            dt = new System.Data.DataTable();

            using (dt = adManager.getListUser(whichUser, pageIndex, _pageSize, ref RecordNo))
            {
                if(dt == null)
                {
                    MessageBox.Show(DAL.Constance.ERROR);
                    return;
                }
                dtClone = dt.Clone();
                dtClone.Columns[7].DataType = typeof(string);
                dtClone.Columns[3].DataType = typeof(string);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dtClone.ImportRow(dt.Rows[i]);
                    if (dtClone.Rows[i].ItemArray[7].ToString() == "False")
                    {
                        dtClone.Rows[i].SetField("Status", "Ẩn");

                    }
                    else dtClone.Rows[i].SetField("Status", "Đang hoạt động");
                    if (dtClone.Rows[i].ItemArray[3].ToString() == "False")
                    {
                        dtClone.Rows[i].SetField("Gender", "Nữ");
                    }
                    else dtClone.Rows[i].SetField("Gender", "Nam");
                    dtClone.Rows[i].SetField("Rolename", dtClone.Rows[i].ItemArray[6].ToString().ToUpper());
                }
                dgvListUser.DataSource = dtClone;
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
                for (int i = 0; i <= page; i++)
                {
                    System.Windows.Forms.Button btnPage = new System.Windows.Forms.Button();
                    btnPage.Text = (i + 1).ToString();
                    btnPage.Click += BtnPage_Click;
                    btnPage.Size = new Size(47, 30);
                    btnPage.Location = new System.Drawing.Point(VTx + 10 * i + i * 47, 5);
                    btnPage.BackColor = Color.Gray;
                    btnPage.Anchor = (AnchorStyles)(AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right );
                    if (i == 0) btnPage.BackColor = Color.Blue;
                    pnPage.Controls.Add(btnPage);
                }
        }
        private void btnListUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pnChangePwd.Visible == true)
                pnChangePwd.Visible = false;
            isResize = false;
            _pageSize = 20;
            whichUser = (int)BDAdminManager.WhichUser.ALL;
            pageIndex = 1;
            LoadData(pageIndex);
            SetPanelPage();
            pnPage.Visible = true;
            dgvListUser.Visible = true;
        }

        private void resetBG()
        {
            foreach(System.Windows.Forms.Button btn in pnPage.Controls)
            {
                btn.BackColor = Color.Gray;
            }
        }

        private void BtnPage_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            pageIndex = int.Parse(btn.Text);
            resetBG();
            btn.BackColor = Color.Blue;
            LoadData(int.Parse(btn.Text.ToString()));
        }

        private void btnListAdmin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            isResize = false;
            _pageSize = 20;
            if (pnChangePwd.Visible == true)
                pnChangePwd.Visible = false;
            whichUser = (int)BDAdminManager.WhichUser.ADMIN;
            pageIndex = 1;
            LoadData(pageIndex);
            SetPanelPage();
            pnPage.Visible = true;
            dgvListUser.Visible = true;
        }

        private void btnListTeacher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            isResize = false;
            _pageSize = 20;
            if (pnChangePwd.Visible == true)
                pnChangePwd.Visible = false;
            whichUser = (int)BDAdminManager.WhichUser.TEACHER;
            pageIndex = 1;
            LoadData(pageIndex);
            SetPanelPage();
            pnPage.Visible = true;
            dgvListUser.Visible = true;
        }

        private void btnListStudent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            isResize = false;
            _pageSize = 20;
            if (pnChangePwd.Visible == true)
                pnChangePwd.Visible = false;
            whichUser = (int)BDAdminManager.WhichUser.STUDENT;
            pageIndex = 1;
            LoadData(pageIndex);
            SetPanelPage();
            pnPage.Visible = true;
            dgvListUser.Visible = true;
        }

        private void btnDeleteUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pnChangePwd.Visible == true)
                pnChangePwd.Visible = false;
            string strResult = "";
            int rowCompleted = 0;
            List<DataGridViewRow> ListRow = new List<DataGridViewRow>();
            ListRow = getListRowSelected();
            if (ListRow == null)
            {
                MessageBox.Show("Không có user nào được chọn hoặc đã xảy ra lỗi\nVui lòng kiểm trai lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            foreach (DataGridViewRow Row in ListRow)
            {
                string us = Row.Cells["Username"].Value.ToString();
                
                try
                {
                    if (adManager.deleteUser(us))
                    {
                        strResult += us + ": Complete\n";
                        rowCompleted++;
                    }
                    else
                    {
                        strResult += us + ": Fail\n";
                        MessageBox.Show(adManager.error);
                    }
                }
                catch
                {
                    strResult += us + ": Fail\n";
                }
            }
            strResult += "Total: " + rowCompleted + "/" + ListRow.Count;
            MessageBox.Show(strResult, "Result List", MessageBoxButtons.OK);
            LoadData(pageIndex);
        }

        private void btnEditUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pnChangePwd.Visible == true)
                pnChangePwd.Visible = false;

            List<DataGridViewRow> ListRow = new List<DataGridViewRow>();
            ListRow = getListRowSelected();
            if (ListRow != null && ListRow.Count > 0)
            {
                frmAdminEditUser frm = new frmAdminEditUser(ListRow.FirstOrDefault());
                frm.ShowDialog();
            }
            else { MessageBox.Show("Không có user nào được chọn hoặc đã xảy ra lỗi"); }
        }

        private void btnExportUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pnChangePwd.Visible == true)
                pnChangePwd.Visible = false;

            SaveFileDialog fSave = new SaveFileDialog();
            fSave.FileOk += DoSave;
            fSave.Filter = "(Excel)|*.xlsx;*.xls";
            fSave.FileName = "DanhSachUser.xlsx";
            fSave.ShowDialog();
        }

        private void DoSave(object sender, EventArgs e)
        {
            SaveFileDialog fSave = sender as SaveFileDialog;
            if (fSave.FileName != "")
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet sheet = null;
                try
                {
                    sheet = wb.ActiveSheet;
                    sheet.Name = "Danh sách User";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, dgvListUser.Columns.Count]].Merge();
                    sheet.Cells[1, 1] = "Danh Sách User [QuizPro]";
                    sheet.Cells[1, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                    for(int c=1 ; c <= dgvListUser.Columns.Count; c++)
                    {
                        sheet.Cells[2, c] = dgvListUser.Columns[c - 1].HeaderText;
                        sheet.Cells[2, c].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                        sheet.Cells[2, c].Font.Size = 16;
                    }

                    for (int r = 1; r <= dgvListUser.Rows.Count; r++)
                    {
                        for (int c = 1; c <= dgvListUser.Columns.Count; c++)
                        {
                            sheet.Cells[r + 2, c] = dgvListUser.Rows[r-1].Cells[c - 1].Value.ToString();
                            sheet.Cells[r + 2, c].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                            sheet.Cells[r + 2, c].Font.Size = 14;
                        }
                    }
                    wb.SaveAs(fSave.FileName);
                    MessageBox.Show("Đã lưu thành công!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sheet = null;
                    wb.Close();
                    app.Quit();
                    wb = null;
                }
            }
            else MessageBox.Show("Vui lòng đặt tên file!");
        }

        private void btnImportUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pnChangePwd.Visible == true)
                pnChangePwd.Visible = false;

            frmImportUser frm = new frmImportUser();
            frm.ShowDialog();
            
        }

        private void btnUpAvatar_Click(object sender, EventArgs e)
        {
            openAvatar.Multiselect = false;
            openAvatar.Filter = "Image File(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif|All File(*.*)|*.*";
            openAvatar.FilterIndex = 0;
            DialogResult dialogRS = openAvatar.ShowDialog();
            if(dialogRS == DialogResult.OK)
            {
                if(openAvatar.FileName != null)
                {
                    try
                    {
                        string fileName = openAvatar.FileName.Split('\\').LastOrDefault();
                        if(adManager.updateAvatar(SelectedRow.Cells["username"].Value.ToString(), fileName))
                        {
                            picAvatar.Image = Image.FromFile(openAvatar.FileName);
                            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                            MessageBox.Show("Đã cập nhật ảnh đại diện cho user " + lbFullname.Text);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\nDAL Error:" + adManager.error);
                    }
                    finally {
                        LoadData(pageIndex);
                    }
                }
            }
        }

        private void btnResetPwd_Click(object sender, EventArgs e)
        {
            string strResult = "";
            int rowCompleted = 0;
            List<DataGridViewRow> ListRow = new List<DataGridViewRow>();
            ListRow = getListRowSelected();
            if (ListRow == null)
            {
                MessageBox.Show("Không có user nào được chọn hoặc đã xảy ra lỗi\nVui lòng kiểm trai lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            foreach (DataGridViewRow Row in ListRow)
            {
                string birthday = Row.Cells["Birthday"].Value.ToString();
                string us = Row.Cells["Username"].Value.ToString();

                string pwd = "";
                try
                {
                    birthday = birthday.Split(' ')[0];
                    string[] s = birthday.Split('/');
                    if (s[1].Length == 1)
                        s[1] = "0" + s[1];
                    pwd += s[1];
                    if (s[0].Length == 1)
                        s[0] = "0" + s[0];
                    pwd += s[0];
                    pwd += s[2];
                }
                catch
                {
                    pwd = us;
                }
                try
                {
                    if (adManager.changePwd(us, pwd))
                    {
                        strResult += us + ": Complete\n";
                        rowCompleted++;
                    }
                    else strResult += us + ": Fail\n";
                }
                catch {
                    strResult += us + ": Fail\n";
                }
            }
            strResult += "Total: "+ rowCompleted + "/" + ListRow.Count;
            MessageBox.Show(strResult, "Result List", MessageBoxButtons.OK);
        }

        private void frmAdminMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            string error = (new UpdateUserStatus()).ChangeStatus(DAL.Username);
            if (error != "")
            {
                MessageBox.Show(this, error, "Error System");
            }
            if(!frmParentStatus)
                frmParent.Close();
            this.Dispose();
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            lbChoose.Text = "Chọn quyền";
            List<string> listRole = new List<string>();
            listRole.Add("ADMIN");
            listRole.Add("TEACHER");
            listRole.Add("STUDENT");
            cbbEdit.DataSource = listRole;
            lbChoose.Visible = true;
            cbbEdit.Visible = true;
            btnOK.Visible = true;
        }

        private List<DataGridViewRow> getListRowSelected()
        {
            List<DataGridViewRow> ListRow = new List<DataGridViewRow>();
            if (dgvListUser.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvListUser.SelectedRows)
                    ListRow.Add(row);
            }
            else if (dgvListUser.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in dgvListUser.SelectedCells)
                {
                    ListRow.Add(dgvListUser.Rows[cell.RowIndex]);
                }
                ListRow = ListRow.Distinct().ToList();
            }
            else
            {
                ListRow = null;
            }
            return ListRow;
        }
        private void btnStatus_Click(object sender, EventArgs e)
        {
            string strResult = "";
            int rowCompleted = 0;
            List<DataGridViewRow> ListRow = new List<DataGridViewRow>();
            ListRow = getListRowSelected();
            if(ListRow == null)
            {
                MessageBox.Show("Không có user nào được chọn hoặc đã xảy ra lỗi\nVui lòng kiểm trai lại!","Thông báo", MessageBoxButtons.OK);
                return;
            }
            
            if (MessageBox.Show("Thay đổi trạng thái của tất cả user đã chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow Row in ListRow)
                {
                    string us = Row.Cells["Username"].Value.ToString();
                    string er = "";
                    try
                    {
                        er = (new UpdateUserStatus()).ChangeStatus(us);
                        if (er == "")
                        {
                            strResult += us + ": Complete\n";
                            rowCompleted++;
                        }
                        else strResult += us + ": Fail\n";
                    }
                    catch { strResult += us + ": Fail\n"; }
                }
                strResult += "Total: " + rowCompleted + "/" + ListRow.Count;
                MessageBox.Show(strResult,"Result List", MessageBoxButtons.OK);
                LoadData(pageIndex);
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strResult = "";
            int rowCompleted = 0;
            List<DataGridViewRow> ListRow = new List<DataGridViewRow>();
            ListRow = getListRowSelected();
            if (ListRow == null)
            {
                MessageBox.Show("Không có user nào được chọn hoặc đã xảy ra lỗi\nVui lòng kiểm trai lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            foreach (DataGridViewRow Row in ListRow)
            {
                string us = Row.Cells["Username"].Value.ToString();
                try {
                    if(adManager.ChangeRole(cbbEdit.SelectedItem.ToString(), us))
                    {
                        strResult += us + ": Complete\n";
                        rowCompleted++;
                    }
                    else strResult += us + ": Fail\n";
                }
                catch
                {
                    strResult += us + ": Fail\n";
                }
        }
            strResult += "Total: " + rowCompleted + "/" + ListRow.Count;
            MessageBox.Show(strResult, "Result List", MessageBoxButtons.OK);
            LoadData(pageIndex);
            lbChoose.Visible = false;
            cbbEdit.Visible = false;
            btnOK.Visible = false;
        }

        private void dgvListUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SelectedRow = dgvListUser.Rows[dgvListUser.SelectedCells[0].RowIndex];
                lbFullname.Text = SelectedRow.Cells["Fullname"].Value.ToString();
                string filepath = SelectedRow.Cells["Avatar"].Value.ToString();
                if (filepath == null || filepath == "")
                {
                    filepath = System.Windows.Forms.Application.StartupPath + @"\avatar\avt.jpg";
                }
                else filepath = System.Windows.Forms.Application.StartupPath +"\\avatar\\"+ filepath;
                picAvatar.Image = null;
                picAvatar.Image = Image.FromFile(filepath);
                picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message,"error");
            }
            pnInfo.Visible = true;       
        }

        //sign out button
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmParentStatus = true;
            frmParent.Show();
            this.Close();
        }

        private void btnChangePwd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnInfo.Visible = false;
            dgvListUser.Visible = false;
            pnPage.Visible = false;
            pnChangePwd.Visible = true;
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {

        }

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
            foreach(Control ct in pnChangePwd.Controls)
            {
                if(ct.Name.ToString() == btn.Tag.ToString())
                {
                    System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)ct;
                    tb.UseSystemPasswordChar = tb.UseSystemPasswordChar == true? false:true;
                    return;
                }
            }
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
                if(txb.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin","Thông báo",MessageBoxButtons.OK);
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
            if(txtNewPwd.Text == txtOldPwd.Text)
            {
                MessageBox.Show("Mật khẩu mới không được phép trùng với mật khẩu cũ", "Thông báo", MessageBoxButtons.OK);
                txtNewPwd.Focus();
                return;
            }
            if(txtNewPwd2.Text != txtNewPwd.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp", "Thông báo", MessageBoxButtons.OK);
                txtNewPwd2.Focus();
                return;
            }
            if (txtNewPwd.Text.Length<5)
            {
                MessageBox.Show("Mật khẩu mới quá ngắn", "Thông báo", MessageBoxButtons.OK);
                txtNewPwd.Focus();
                return;
            }
            if(txtOldPwd.Text == DAL.Password)
                if (adManager.changePwd(DAL.Username, txtNewPwd.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                    DAL.Password = txtNewPwd.Text;
                    txtOldPwd.Text = txtNewPwd.Text = txtNewPwd2.Text = "";
                }
                else MessageBox.Show(adManager.error,"Error");
            else MessageBox.Show("Mật khẩu cũ không đúng, vui lòng kiểm tra lại!", "Thông báo");
        }
        private bool checkPwd(string pwd)
        {
            foreach(char c in pwd)
            {
                if(c <48 || (c > 57 && c < 65) || (c > 90 && c < 97) || c > 122)
                {
                    return false;
                }
            }
            return true;
        }

        private void txtOldPwd_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txb = sender as System.Windows.Forms.TextBox;
            txb.BackColor = Color.Aqua;
        }

        private void btnMyInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(pnChangePwd.Visible == true)
            pnChangePwd.Visible = false;
        }

        private void txtOldPwd_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
            tb.BackColor = Color.White;
        }

        private void frmAdminMain_SizeChanged(object sender, EventArgs e)
        {
            isResize = true;
            SetPanelPage();
        }

        //refresh this page
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData(pageIndex);
        }

        //add new user by input from keyboard
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAdminEditUser frm = new frmAdminEditUser();
            frm.ShowDialog();
        }

        public void MyActiveForm(Frm_LoginSystem f)
        {
            this.Show();
            frmParent = f;
            frmParentStatus = false;
        }
    }
}
