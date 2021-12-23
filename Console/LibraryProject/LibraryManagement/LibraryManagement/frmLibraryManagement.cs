using LibraryManagement.Models.DAO;
using LibraryManagement.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class frmLibraryManagement : Form
    {
        UserDAO userDAO = new UserDAO();

        public frmLibraryManagement()
        {
            InitializeComponent();
        }

        private byte CheckAuthentication()
        {
            return userDAO.GetSingle(UserDAO.userId).UType;
        }

        private void đọcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            ucReaderManagement uc = new ucReaderManagement();
            pnContent.Controls.Add(uc);
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // nếu là Admin thì có quyền truy cập
            if (CheckAuthentication() == 0)
            {
                pnContent.Controls.Clear();
                ucEmployeeManagement uc = new ucEmployeeManagement();
                pnContent.Controls.Add(uc);
            }
            else // nếu là nhân viên thì k có quyền truy cập
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            ucBookManagement uc = new ucBookManagement();
            pnContent.Controls.Add(uc);
        }

        private void mượntrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            ucPromissoryNote uc = new ucPromissoryNote();
            pnContent.Controls.Add(uc);
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelp frm = new frmHelp();
            frm.ShowDialog();
        }

        private void frmLibraryManagement_Load(object sender, EventArgs e)
        {
            ucIntro ucIntro = new ucIntro();
            pnContent.Controls.Add(ucIntro);
        }

        private void tàiKhoảnCủaTôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountProfile frm = new frmAccountProfile();
            frm.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // mở form đăng ký
            frmLogin frm = new frmLogin();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
