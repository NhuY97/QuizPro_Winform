using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizPro_v._1._0
{
    public partial class frmUserInfo : Form
    {
        BDAdminManager adManager;
        public frmUserInfo()
        {
            InitializeComponent();
            adManager = new BDAdminManager();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pnInfo.Visible = false;
            pnChangePwd.Visible = true;
            btnChangePass.Visible = false;
        }
        // đổi mật khẩu
        private void simpleButton2_Click(object sender, EventArgs e)
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
                    btnChangePass.Visible = true;
                    pnChangePwd.Visible = false;
                    pnInfo.Visible = true;
                }
                else MessageBox.Show(adManager.error, "Error");
            else MessageBox.Show("Mật khẩu cũ không đúng, vui lòng kiểm tra lại!", "Thông báo");
        }
        // validate password
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

        private void txtOldPwd_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txb = sender as System.Windows.Forms.TextBox;
            txb.BackColor = Color.Aqua;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNewPwd.Clear();
            txtNewPwd2.Clear();
            txtOldPwd.Clear();
            pnChangePwd.Visible = false;
            pnInfo.Visible = true;
        }
        // lấy thông tin user từ username
        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            lbUserName.Text = DAL.Username;
            DataTable dt = adManager.getUserInfo();
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu");
                this.Close();
            }
            lbFullname.Text = dt.Rows[0].ItemArray[0].ToString();
            lbSex.Text = dt.Rows[0].ItemArray[1].ToString() == "0" ? "Nữ" : "Nam";
            lbDateOfBirth.Text = dt.Rows[0].ItemArray[2].ToString().Split(' ')[0];
            lbRole.Text = dt.Rows[0].ItemArray[4].ToString().ToUpper();
            string filepath = Application.StartupPath + "\\avatar\\" + dt.Rows[0].ItemArray[3].ToString();
            picAvatar.Image = Image.FromFile(filepath);
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            if (lbRole.Text.Trim() == "ADMIN")
            {
                lbLop.Visible = false;
                lbClass.Visible = false;
            }
            else if (lbRole.Text.Trim() == "STUDENT")
            {
                lbLop.Visible = true;
                lbClass.Visible = true;
                lbLop.Text = "Lớp: ";
                lbClass.Text = adManager.getClassName().ToString();
                if (lbClass.Text.Trim() == "") lbClass.Text = "Không nằm trong lớp nào";
            }
            else if (lbRole.Text.Trim() == "TEACHER")
            {
                lbLop.Visible = true;
                lbClass.Visible = true;
                lbLop.Text = "Môn giảng dạy: ";
                DataTable dtSubj = adManager.getSubject();
                if (dtSubj == null || dtSubj.Rows.Count == 0)
                    lbClass.Text = "Chưa có môn học nào";
                else
                {
                    string listSubject = "";
                    foreach(DataRow row in dtSubj.Rows)
                    {
                        listSubject += row.ItemArray[1] + "    ";
                    }
                    lbClass.Text = listSubject;
                }
            }
        }
    }
}
