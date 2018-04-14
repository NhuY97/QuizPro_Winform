using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizPro_v._1._0
{
    public partial class FrmSettingSystem : Form
    {
        public DBLoginSystem dblogin;
        public String StrConnection;
        string please = "Please Enter ";
        BackgroundWorker bW_ConnectToServer;
        FileStream f;
        Frm_LoginSystem frm;
        public FrmSettingSystem(Frm_LoginSystem frm)
        {
            InitializeComponent();
            this.frm = frm;
            bW_ConnectToServer = new BackgroundWorker();
            bW_ConnectToServer.WorkerReportsProgress = true;
            bW_ConnectToServer.DoWork += DoWork;
            bW_ConnectToServer.RunWorkerCompleted += Complete;
            bW_ConnectToServer.ProgressChanged += new ProgressChangedEventHandler(progressChanged);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDataSource.Text = "IP or ServerName";
            txtDataSource.ForeColor = Color.Gray;
            txtPwd.Clear();
            txtUserID.Clear();
            lbMess.Text = "";
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            // check validate và tạo chuỗi kết nối
            checkValid();
            if (lbMess.Text != "")
                return;
            StrConnection = txtDataSource.Text.Trim() + "," + txtUserID.Text.Trim() + "," + txtPwd.Text;
            if (cb_Authentication.SelectedIndex == 0)
                StrConnection += "," + "true";
            else
                StrConnection += "," + "false";
            // lưu ip vào file text
            f = new FileStream("Datasource.txt", FileMode.Truncate);
            StreamWriter sw = new StreamWriter(f);
            sw.Write(txtDataSource.Text);
            sw.Flush();
            sw.Close();
            f.Close();
            pictureBox1.Visible = true;

            if (!bW_ConnectToServer.IsBusy)
                bW_ConnectToServer.RunWorkerAsync();
        }

        private void DoWork(object sender, EventArgs e)
        {
            // mở connection
            int i = 0;
            int millisecond = 25;
            for (; i < 100; i += 8)
            {
                System.Threading.Thread.Sleep(millisecond);
                bW_ConnectToServer.ReportProgress(i);
            }
            dblogin = new DBLoginSystem(StrConnection);
            if (DAL.Constance != null)
                DAL.Constance = null;
            if (DAL.Constance.conn.State == ConnectionState.Open)
                DAL.Constance.conn.Close();
            try
            {
                DAL.Constance.conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được với server\n" + ex.Message);
            }
        }

        private void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            lbMess.Text = "Đang kết nối vào máy chủ... " + e.ProgressPercentage + "%";
        }

        public void Complete(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            if (DAL.Constance.conn.State == ConnectionState.Open)
            {
                frm.lbStatus.Text = "Server: Connected";
                frm.lbStatus.ForeColor = Color.Green;
            }
            else
            {
                frm.lbStatus.Text = "Server: Not Connected";
                frm.lbStatus.ForeColor = Color.Red;
            }
            this.Hide();
        }

        private void checkValid()
        {
            lbMess.Text = "";
            if (txtDataSource.Text == "IP or ServerName")
                lbMess.Text = please + lbDataSource.Text;
            else if (txtUserID.Text == "" && cb_Authentication.SelectedIndex == 1)
                lbMess.Text = please + lbUserID.Text;
            else if (txtPwd.Text == "" && cb_Authentication.SelectedIndex == 1)
                lbMess.Text = please + lbPwd.Text;
        }

        private void txtDataSource_Leave(object sender, EventArgs e)
        {
            if (txtDataSource.Text == "")
            {
                txtDataSource.Text = "IP or ServerName";
                txtDataSource.ForeColor = Color.Gray;
            }
            checkValid();
        }

        private void txtDataSource_Enter(object sender, EventArgs e)
        {
            if (txtDataSource.Text == "IP or ServerName")
            {
                txtDataSource.Text = "";
                txtDataSource.ForeColor = Color.Black;
                if (lbMess.Text == please + lbDataSource.Text)
                {
                    lbMess.Text = "";
                }
            }
        }

        private void txtUserID_Leave(object sender, EventArgs e)
        {
            checkValid();
        }

        private void txtUserID_Enter(object sender, EventArgs e)
        {
            if (lbMess.Text == please + lbUserID.Text)
            {
                lbMess.Text = "";
            }
        }

        private void txtPwd_Leave(object sender, EventArgs e)
        {
            checkValid();
        }

        private void txtPwd_Enter(object sender, EventArgs e)
        {
            if (lbMess.Text == please + lbPwd.Text)
            {
                lbMess.Text = "";
            }
        }
        // lấy ip máy hiện tại
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "";
        }

        private void btnGetIP_Click(object sender, EventArgs e)
        {
            string ip = GetLocalIPAddress();
            if (ip != "")
            {
                txtDataSource.Text = ip;
                txtDataSource.ForeColor = Color.Black;
            }
            else MessageBox.Show("Can not get local IP address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtDataSource_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnOK.PerformClick();
        }
        bool isFirstLoad = true;

        // lấy ip từ file text
        private void FrmSettingSystem_Load(object sender, EventArgs e)
        {
            f = new FileStream("Datasource.txt", FileMode.OpenOrCreate);
            StreamReader sf = new StreamReader(f);
            txtDataSource.Text = sf.ReadLine();
            sf.Close();
            f.Close();

            if (txtDataSource.Text == "")
            {
                txtDataSource.Text = "IP or ServerName";
            }

            if (isFirstLoad)
                cb_Authentication.SelectedIndex = 0;
            lbMess.Text = "";
        }

        private void cb_Authentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Authentication.SelectedIndex == 0)
            {
                txtPwd.Text = txtUserID.Text = "";
                txtUserID.Enabled = false;
                txtPwd.Enabled = false;
            }
            else if (cb_Authentication.SelectedIndex == 1)
            {
                txtUserID.Enabled = true;
                txtPwd.Enabled = true;
            }
            isFirstLoad = false;
        }
    }
}
