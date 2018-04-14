using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizPro_v._1._0.Presentation
{
    public partial class frmSelectSubjects : Form
    {
        BDAdminManager bdAdmin;
        public static List<String> listSub;
        public frmSelectSubjects()
        {
            InitializeComponent();
            bdAdmin = new BDAdminManager();
        }

        private void frmSelectSubjects_Load(object sender, EventArgs e)
        {
            //danh sách môn học
            dgvSubject.DataSource = bdAdmin.getListSubject();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            listSub = new List<string>();
            if (dgvSubject.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn môn học nào!");
                return;
            }
            // lưu danh sách môn học đã chọn vào listSub
            foreach (DataGridViewRow row in dgvSubject.SelectedRows)
            {
                if(row.Cells[0].Value != null)
                    listSub.Add(row.Cells[0].Value.ToString());
            }
            this.Close();
        }
    }
}
