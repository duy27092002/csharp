using LibraryManagement.Models.DAO;
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
    public partial class frmSignUp : Form
    {
        UserDAO dao = new UserDAO();

        public frmSignUp()
        {
            InitializeComponent();
        }

        private void OpenLoginForm()
        {
            frmLogin frm = new frmLogin();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string getName = txtName.Text.Trim();
            string getPhone = txtPhone.Text.Trim();
            string getAddress = txtAddress.Text.Trim();
            string getUsername = txtUsername.Text.Trim();
            string getPwd = txtPwd.Text.Trim();

            if (dao.SignUp(getName, getPhone, getAddress, getUsername, getPwd))
            {
                // mở form đăng nhập
                OpenLoginForm();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void llbLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // mở form đăng nhập
            OpenLoginForm();
        }

        private void frmSignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
