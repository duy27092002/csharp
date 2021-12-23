using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models.DAO;
using WindowsFormsApp1.Models.EF;

namespace WindowsFormsApp1
{
    public partial class fCustomerManagementSystem : Form
    {
        CustomerDAO customerDAO = new CustomerDAO();
        Regex isPhone = new Regex(@"^[\d]+$");
        Regex isEmail = new Regex(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");

        int currentPage = 1;

        private void SetTrueEnabledForFirstAndPrevBtn()
        {
            btnPrevPage.Enabled = true;
            btnFirstPage.Enabled = true;
        }

        private void SetFalseEnabledForFirstAndPrevBtn()
        {
            btnFirstPage.Enabled = false;
            btnPrevPage.Enabled = false;
        }

        private void SetTrueEnabledForLastAndNextBtn()
        {
            btnNextPage.Enabled = true;
            btnLastPage.Enabled = true;
        }

        private void SetFalseEnabledForLastAndNextBtn()
        {
            btnNextPage.Enabled = false;
            btnLastPage.Enabled = false;
        }

        private void ClearForm()
        {
            lbError.Text = "";
            txtCustomerId.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        public fCustomerManagementSystem()
        {
            InitializeComponent();
            btnSave.Enabled = false;
            SetFalseEnabledForFirstAndPrevBtn();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string getCustomerId = txtCustomerId.Text;
            string getFirstname = txtFirstname.Text.Trim();
            string getLastname = txtLastname.Text.Trim();
            string getPhone = txtPhone.Text.Trim();
            string getEmail = txtEmail.Text.Trim();
            string getAddress = txtAddress.Text.Trim();

            if (getFirstname == "" || getLastname == "" || getPhone == "" ||
                getEmail == "" || getAddress == "")
            {
                lbError.Text = "Please fill full the form!";
            }
            else
            {
                if (isPhone.IsMatch(getPhone) && isEmail.IsMatch(getEmail))
                {
                    Customer data = new Customer()
                    {
                        CustomerId = getCustomerId,
                        FirstName = getFirstname,
                        LastName = getLastname,
                        Phone = getPhone,
                        Email = getEmail,
                        Address = getAddress
                    };

                    if (!customerDAO.UpdateCustomer(data))
                    {
                        ClearForm();
                        btnAdd.Enabled = true;
                        btnSave.Enabled = false;
                        txtCustomerId.Enabled = true;
                        MessageBox.Show("Save successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvEmployeeDetails.DataSource = customerDAO.GetCusByPage(1);
                    }
                    else
                    {
                        MessageBox.Show("Save failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    lbError.Text = "Wrong Phone or Email format!";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string getCustomerId = txtCustomerId.Text.Trim();
            string getFirstname = txtFirstname.Text.Trim();
            string getLastname = txtLastname.Text.Trim();
            string getPhone = txtPhone.Text.Trim();
            string getEmail = txtEmail.Text.Trim();
            string getAddress = txtAddress.Text.Trim();

            if (getCustomerId == "" || getFirstname == "" || getLastname == "" || getPhone == "" ||
                getEmail == "" || getAddress == "")
            {
                lbError.Text = "Please fill full the form!";
            } else
            {
                if (isPhone.IsMatch(getPhone) && isEmail.IsMatch(getEmail))
                {
                    Customer data = new Customer()
                    {
                        CustomerId = getCustomerId,
                        FirstName = getFirstname,
                        LastName = getLastname,
                        Phone = getPhone,
                        Email = getEmail,
                        Address = getAddress
                    };

                    if (customerDAO.AddNewCustomer(data))
                    {
                        ClearForm();
                        MessageBox.Show("Add successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvEmployeeDetails.DataSource = customerDAO.GetCusByPage(1);
                    } else
                    {
                        MessageBox.Show("Add failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    lbError.Text = "Wrong Phone or Email format!";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // load danh sách khách hàng
        private void fCustomerManagementSystem_Load(object sender, EventArgs e)
        {
            dgvEmployeeDetails.DataSource = customerDAO.GetCusByPage(1);
        }

        private void dgvEmployeeDetails_Click(object sender, EventArgs e)
        {
            string getCustId = dgvEmployeeDetails.CurrentRow.Cells["CustomerId"].Value.ToString();

            Customer getCustomer = customerDAO.GetCustomerById(getCustId);

            if (getCustomer != null)
            {
                txtCustomerId.Text = getCustomer.CustomerId;
                txtFirstname.Text = getCustomer.FirstName;
                txtLastname.Text = getCustomer.LastName;
                txtPhone.Text = getCustomer.Phone;
                txtEmail.Text = getCustomer.Email;
                txtAddress.Text = getCustomer.Address;
                txtCustomerId.Enabled = false;
                btnAdd.Enabled = false;
                btnSave.Enabled = true;
            }
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            dgvEmployeeDetails.DataSource = customerDAO.GetCusByPage(currentPage);

            currentPage = 1;

            SetFalseEnabledForFirstAndPrevBtn();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                dgvEmployeeDetails.DataSource = customerDAO.GetCusByPage(--currentPage);
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
            if (currentPage < customerDAO.GetPageCount())
            {
                dgvEmployeeDetails.DataSource = customerDAO.GetCusByPage(++currentPage);
                SetTrueEnabledForFirstAndPrevBtn();
            }

            if (currentPage == customerDAO.GetPageCount())
            {
                SetTrueEnabledForFirstAndPrevBtn();
                SetFalseEnabledForLastAndNextBtn();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = customerDAO.GetPageCount();

            dgvEmployeeDetails.DataSource = customerDAO.GetCusByPage(currentPage);

            SetTrueEnabledForFirstAndPrevBtn();
            SetFalseEnabledForLastAndNextBtn();
        }
    }
}
