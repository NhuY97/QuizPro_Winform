using System;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizPro_v._1._0.Presentation.Admin_Manager
{
    public partial class frmImportUser : Form
    {
        OpenFileDialog fopen;
        BDAdminManager bdAdmin;
        public frmImportUser()
        {
            InitializeComponent();
            bdAdmin = new BDAdminManager();
            // tạo file open
            fopen = new OpenFileDialog();
            fopen.FileOk += fOpenOKClick;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            fopen.Filter = "(File Excel)|*.xlsx;*.xls";
            fopen.ShowDialog();
        }
        private void fOpenOKClick(Object sender,EventArgs e)
        {
            if (fopen.FileName == "")
            {
                lbFileName.Text = "Bạn chưa chọn File";
                return;
            }
            // tạo app excel, mở workbook theo filename và sheet đầu tiên của workbook đó  
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
                    DGVColumn.HeaderText = range.Cells[1,c].Value.ToString();
                    DGVColumn.Visible = true;
                    DGVColumn.Frozen = false;
                    DGVColumn.ReadOnly = false;
                    dgvUser.Columns.Add(DGVColumn);
                }
                //get row
                for(int r = 2; r < rows; r++)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    for (int c = 1; c <= cols; c++)
                    {
                        DataGridViewCell cell = new DataGridViewTextBoxCell();
                        cell.Value = range.Cells[r,c].Value.ToString();
                        dgvRow.Cells.Add(cell);
                    }

                    dgvUser.Rows.Add(dgvRow);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbRole.SelectedIndex == 0)
            {
                lbClassName.Visible = true;
                txtClassName.Visible = true;
                lbMember.Visible = true;
                numMember.Visible = true;

                txtClassName.Focus();
            }
            else
            {
                lbClassName.Visible = false;
                txtClassName.Visible = false;
                lbMember.Visible = false;
                numMember.Visible = false;

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string rolename = "";
            bool isClassAdded = false;
            if (cbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn quyền!","QuizPro",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                cbRole.Focus();
                return;
            }


            switch (cbRole.SelectedIndex)
            {
                case 0:
                    rolename = "student";
                    break;
                case 1:
                    rolename = "teacher";
                    break;
                case 2:
                    rolename = "admin";
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn quyền");
                    return;
            }

            if (rolename == "student")
            {
                if (txtClassName.Text == "" || !bdAdmin.addClass(txtClassName.Text, (int)numMember.Value))
                {
                    if (MessageBox.Show("Bạn chưa chọn lớp hoặc lớp đã bị trùng tên\n Bạn vẫn muốn thêm tất cả học sinh này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                else isClassAdded = true;
            }
            // đưa dữ liệu vào datagridview
            string listUserAdded = "";
            string listUserNotAdded = "";
            string listUserNotAddedIntoClass = "";
            for (int i =0; i < dgvUser.Rows.Count; i++)
            {
                try
                {
                    string username = dgvUser.Rows[i].Cells[0].Value.ToString();
                    string fullname = dgvUser.Rows[i].Cells[1].Value.ToString();
                    string strGender = dgvUser.Rows[i].Cells[2].Value.ToString();
                    bool gender;
                    if ((strGender = strGender.ToLower()) == "nam" || strGender == "nữ")
                    gender = strGender == "nam" ? true : false;
                    else
                    {
                        MessageBox.Show("Giới tính của user " + username + " không đúng định dạng!");
                        return;
                    }
                    int _day, _month, _year;
                    string strBirthDay = dgvUser.Rows[i].Cells[3].Value.ToString();
                    try
                    {
                        _day = int.Parse(strBirthDay.Substring(0, 2));
                        _month = int.Parse(strBirthDay.Substring(3, 2));
                        _year = int.Parse(strBirthDay.Substring(6, 4));
                    }
                    catch(Exception exc)
                    {
                        MessageBox.Show("Ngày sinh không đúng định dạng\nError: "+exc.Message);
                        return;
                    }
                    DateTime birthday = new DateTime(_year,_month,_day);
                    
                    string roleID = bdAdmin.getRoleid(rolename);
                    try
                    {
                        if(bdAdmin.addUser(username, fullname, gender, birthday, roleID))
                        {
                            string pwd = strBirthDay.Substring(0, 2)+ strBirthDay.Substring(3, 2)+ strBirthDay.Substring(6, 4);
                            bdAdmin.changePwd(username,pwd);
                            listUserAdded += "\n" + username;
                            if(rolename == "student" && isClassAdded)
                            {
                                if(!bdAdmin.addListClass(txtClassName.Text, username))
                                {
                                    listUserNotAddedIntoClass += "\n" + username;
                                }

                            }
                        }
                        else
                        {
                            if (bdAdmin.error.Contains("PRIMARY KEY") && bdAdmin.error.Contains("duplicate"))
                            {
                                listUserNotAdded += "\n" + username;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi khi thêm user " + username + "\nError: "+bdAdmin.error);
                    }
                 }
                catch(Exception ex)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin user " +dgvUser.Rows[i].Cells[0].Value.ToString() +"\nError: "+ex.Message);
                    return;
                }
            }
            if(listUserNotAdded != "")
                MessageBox.Show("Danh sách user đã tồn tại: "+listUserNotAdded);
            MessageBox.Show(listUserAdded == "" ? "Không có user nào được thêm!": "Danh sách user đã thêm: " + listUserAdded);
            if(listUserNotAddedIntoClass != "")
                MessageBox.Show("Danh sách user chưa được thêm vào lớp: " + listUserNotAddedIntoClass);
        }
        // hướng dẫn người dùng
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("File excel gồm 1 sheet\nGồm 4 cột lần lượt là: username, họ tên, giới tính, ngày sinh\nGiới tính là 'nam' hoặc 'nữ'\nNgày sinh phải đúng định dạng dd/mm/yyyy hoặc dd-mm-yyyy\nPassword mặc định của mỗi user là ngày sinh của user đó\n Nếu thêm vào danh sách các học sinh thì có thể chọn lớp cho các học sinh đó\nVui lòng liên hệ www.facebook.com/yzenny97\n---Author TNT Nhu Y ---", "QuizPro version 1.0", MessageBoxButtons.OK);
        }
        
        private void frmImportUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
