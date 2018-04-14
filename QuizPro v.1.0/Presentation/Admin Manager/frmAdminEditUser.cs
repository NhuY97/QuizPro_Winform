using QuizPro_v._1._0.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizPro_v._1._0.View.Admin_Manager
{
    public partial class frmAdminEditUser : Form
    {
        // thông tin truyền vào thi sửa
        DataGridViewRow row;
        // thao tác hiện tại có phải là thêm mới hay không
        bool isAddNewUSer;
        BDAdminManager bdAM;
        String classid;
        // danh sách lớp
        List<String> ListSubject = new List<string>();
        // construcor dành cho thao tác sửa
        public frmAdminEditUser(DataGridViewRow row)
        {
            InitializeComponent();
            bdAM = new BDAdminManager();
            this.row = row;
            isAddNewUSer = false;
        }

        //constructor dành cho thao tác thêm
        public frmAdminEditUser()
        {
            InitializeComponent();
            bdAM = new BDAdminManager();
            isAddNewUSer = true;
        }
        // lấy danh sách lớp
        public void LoadClass()
        {
            cbClass.DataSource = bdAM.getListClass();
            cbClass.DisplayMember = "Classname";
            cbClass.ValueMember = "ClassID";

        }

        private void frmAdminEditUser_Load(object sender, EventArgs e)
        {
            LoadClass();
            if (isAddNewUSer)
            {
                lbRole.Visible = true;
                cbbRolename.Visible = true;
                txtUsername.Enabled = true;
                btnOK.Text = "Add";
                label.Text = "Add New User";
                dTPbirthday.Value = new DateTime(1997,08,19);
                cbbGender.SelectedIndex = 0;
                cbbRolename.SelectedIndex = 0;
            }
            else
            {
                // truyền thông tin vào form khi sửa
                lbRole.Visible = true;
                cbbRolename.Visible = true ;
                txtUsername.Enabled = false;
                btnOK.Text = "Update";
                label.Text = "Edit User Info";
                txtUsername.Text = row.Cells[1].Value.ToString();
                txtFullname.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value.ToString().Equals("Nam"))
                {
                    cbbGender.SelectedIndex = 0;
                }
                else cbbGender.SelectedIndex = 1;
                dTPbirthday.Value = (DateTime)row.Cells[4].Value;
            }
        }
        // lưu vào CSDL
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Please fill all the field");
                txtFullname.Focus();
                return;
            }
            
                bool gender = cbbGender.SelectedIndex == 1 ? false : true;
                bool f;
            if (isAddNewUSer)
            {
                string roleid = bdAM.getRoleid(cbbRolename.SelectedItem.ToString());
                f = bdAM.addUser(txtUsername.Text, txtFullname.Text, gender, dTPbirthday.Value, roleid);
                if (cbClass.Text.Trim() != "" && cbbRolename.SelectedIndex == 0)
                {
                    f = bdAM.addListClass(cbClass.Text, txtUsername.Text);
                }
                if(ListSubject != null && ListSubject.Count > 0 && cbbRolename.SelectedIndex == 1)
                {
                    foreach(String subid in ListSubject)
                    {
                        f = bdAM.insertTeacher(subid, txtUsername.Text);
                    }
                }
            }
            else
            {
                f = bdAM.updateUser(txtUsername.Text, txtFullname.Text, gender, dTPbirthday.Value);
                f = bdAM.ChangeRole(cbbRolename.Text.Trim().ToLower(), txtUsername.Text);
                if (cbClass.Text.Trim() != "" && cbbRolename.SelectedIndex == 0)
                {
                    f = bdAM.updateListClass(classid, txtUsername.Text);
                }
                if (ListSubject != null && ListSubject.Count > 0 && cbbRolename.SelectedIndex == 1)
                {
                    f = bdAM.deleteTeacher(txtUsername.Text);
                    foreach (String subid in ListSubject)
                    {
                        f = bdAM.updateTeacher(subid, txtUsername.Text);
                    }
                }
            }
                if (f)
                {
                    MessageBox.Show("Successfully, please refresh this page");
                }
                else {
                    if(bdAM.error.Contains("PRIMARY KEY"))
                    {
                        MessageBox.Show("Username đã tồn tại hoặc không đúng định dạng, vui lòng kiểm tra lại\nError Message: " + bdAM.error);
                        txtUsername.Focus();
                    }
                    else MessageBox.Show("Error: " + bdAM.error);
                }
            this.Close();
        }

        private void cbClass_VisibleChanged(object sender, EventArgs e)
        {
            lbTitleClass.Visible = cbClass.Visible;
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            frmSelectSubjects frm = new frmSelectSubjects();
            frm.ShowDialog();
            if (frmSelectSubjects.listSub == null || frmSelectSubjects.listSub.Count == 0)
                MessageBox.Show("Bạn chưa chọn môn học nào");
            else ListSubject = frmSelectSubjects.listSub;
        }

        // hiện lớp nếu là học sinh, danh sách môn học nếu là giáo viên
        private void cbbRolename_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbRolename.SelectedIndex == 0)
            {
                cbClass.Visible = true;
                btnSubject.Visible = false;
            }
            else if(cbbRolename.SelectedIndex == 1)
            {
                cbClass.Visible = false;
                btnSubject.Visible = true;
            }
            else
            {
                cbClass.Visible = false;
                btnSubject.Visible = false;
            }
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            classid = cbClass.SelectedValue.ToString();
        }
    }
}
