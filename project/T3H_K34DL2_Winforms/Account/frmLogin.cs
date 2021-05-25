using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3H_K34DL2_Winforms.Account
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += .05;
                this.Refresh();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           // txtUserName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = "admin";
            string password = "admin";

            if (userName.Equals(txtUserName.Text.Trim()) && password.Equals(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu, đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblFogotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Comming soon!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
