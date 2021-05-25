using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3H_K35DL1_Winforms.Account
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = "admin asd asd asd á";

            string str ="";
            for(int i = 0; i < taiKhoan.Length;i++)
            {
                if(i - 1 >= 0 && taiKhoan[i-1] == ' ')
                {
                    str += taiKhoan[i].ToString().ToUpper();
                }
                else
                {
                    str += taiKhoan[i];
                }
            }

            MessageBox.Show(str);
            string matKhau = "admin";
            //if(taiKhoan == txtTaiKhoan.Text.Trim() && matKhau == txtMatKhau.Text.Trim())
            if (taiKhoan.Equals(txtTaiKhoan.Text.Trim()) && matKhau.Equals(txtMatKhau.Text.Trim()))
            {
                MessageBox.Show("Đăng nhập thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu, đăng nhập thất bại!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
