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

namespace LibraryManagement.UC
{
    public partial class ucEmployeeManagement : UserControl
    {
        UserDAO userDAO = new UserDAO();

        int currentPage = 1;

        public ucEmployeeManagement()
        {
            InitializeComponent();

            txtUId.Text = SetUId();

            LoadList(1);

            btnSave.Enabled = btnDelete.Enabled = false;

            SetFalseEnabledForFirstAndPrevBtn();
        }

        private void SetTrueEnabledForFirstAndPrevBtn()
        {
            btnPreviousPage.Enabled = btnFirstPage.Enabled = true;
        }

        private void SetFalseEnabledForFirstAndPrevBtn()
        {
            btnFirstPage.Enabled = btnPreviousPage.Enabled = false;
        }

        private void SetTrueEnabledForLastAndNextBtn()
        {
            btnNextPage.Enabled = btnLastPage.Enabled = true;
        }

        private void SetFalseEnabledForLastAndNextBtn()
        {
            btnNextPage.Enabled = btnLastPage.Enabled = false;
        }

        private void RestartForm()
        {
            txtUId.Text = SetUId();
            txtName.Text = "";
            txtPhone.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtAddress.Text = "";
            cbbStatus.SelectedItem = "";
            cbbRole.SelectedItem = "";
        }

        private void LoadList(int currentPage)
        {
            dgvEmp.DataSource = userDAO.GetListByPage(currentPage);
        }

        private string SetUId()
        {
            return BaseDAO.RandomString(10);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string getUId = txtUId.Text;
            string getName = txtName.Text.Trim();
            string getPhone = txtPhone.Text.Trim();
            string getUsername = txtUsername.Text.Trim();
            string getPassword = txtPassword.Text.Trim();
            string getAddress = txtAddress.Text.Trim();
            string getStatus = cbbStatus.Text;
            string getUserType = cbbRole.Text;

            if (userDAO.Add(getUId, getName, getPhone, getAddress, getUsername, getPassword, getUserType, getStatus))
            {
                RestartForm();
                LoadList(1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string getUId = txtUId.Text;
            string getName = txtName.Text.Trim();
            string getPhone = txtPhone.Text.Trim();
            string getUsername = txtUsername.Text.Trim();
            string getPassword = txtPassword.Text.Trim();
            string getAddress = txtAddress.Text.Trim();
            string getStatus = cbbStatus.Text;
            string getUserType = cbbRole.Text;

            if (userDAO.Save(getUId, getName, getPhone, getAddress, getUsername, getPassword, getUserType, getStatus))
            {
                RestartForm();
                LoadList(currentPage);
            }
            else
            {
                RestartForm();
            }

            btnAdd.Enabled = true;
            btnSave.Enabled = btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string getUId = txtUId.Text;

            if (userDAO.Delete(getUId))
            {
                RestartForm();
                LoadList(currentPage);
            }
            else
            {
                RestartForm();
            }

            btnDelete.Enabled = btnSave.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 1;

            LoadList(currentPage);

            SetFalseEnabledForFirstAndPrevBtn();
            SetTrueEnabledForLastAndNextBtn();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                LoadList(--currentPage);
                SetTrueEnabledForLastAndNextBtn();
            }

            if (currentPage == 1)
            {
                SetFalseEnabledForFirstAndPrevBtn();
                SetTrueEnabledForLastAndNextBtn();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < userDAO.GetPageCount())
            {
                LoadList(++currentPage);
                SetTrueEnabledForFirstAndPrevBtn();
            }

            if (currentPage == userDAO.GetPageCount())
            {
                SetTrueEnabledForFirstAndPrevBtn();
                SetFalseEnabledForLastAndNextBtn();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = userDAO.GetPageCount();

            LoadList(currentPage);

            SetTrueEnabledForFirstAndPrevBtn();
            SetFalseEnabledForLastAndNextBtn();
        }

        private void dgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = btnDelete.Enabled = true;

            string getUId = dgvEmp.CurrentRow.Cells["UId"].Value.ToString();

            var getInfo = userDAO.GetSingle(getUId);

            txtUId.Text = getInfo.UId;
            txtName.Text = getInfo.UName;
            txtPhone.Text = getInfo.UPhone;
            txtUsername.Text = getInfo.UUsername;
            txtPassword.Text = getInfo.UPassword;
            txtAddress.Text = getInfo.UAddress;
            cbbStatus.SelectedItem = getInfo.UStatus == 1 ? "Đang làm việc" : "Đã nghỉ việc";
            cbbRole.SelectedItem = getInfo.UType == 1 ? "Nhân viên" : "Admin";
        }
    }
}
