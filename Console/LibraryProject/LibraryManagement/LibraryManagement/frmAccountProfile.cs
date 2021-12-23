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
    public partial class frmAccountProfile : Form
    {
        UserDAO userDAO = new UserDAO();

        public frmAccountProfile()
        {
            InitializeComponent();

            GetAccountProfile();
        }

        private void GetAccountProfile()
        {
            var getInfo = userDAO.GetSingle(UserDAO.userId);

            txtName.Text = getInfo.UName;
            txtPhone.Text = getInfo.UPhone;
            txtAddress.Text = getInfo.UAddress;
            txtUsername.Text = getInfo.UUsername;
            txtPassword.Text = getInfo.UPassword;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string getName = txtName.Text.Trim();
            string getPhone = txtPhone.Text.Trim();
            string getAddress = txtAddress.Text.Trim();
            string getUsername = txtUsername.Text.Trim();
            string getPwd = txtPassword.Text.Trim();

            if (userDAO.UpdateAccount(getName, getPhone, getAddress, getUsername, getPwd))
            {
                GetAccountProfile();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
