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
    public partial class fRegistration : Form
    {
        public fRegistration()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Regex checkName = new Regex(@"^[a-zA-z\s]*$");
            string getLoginId = txtLoginId.Text.Trim();
            string getName = txtName.Text.Trim();
            string getPassword = txtPassword.Text.Trim();
            string getReEnterPsw = txtReEnterPsw.Text.Trim();
            string getAddress = txtAddress.Text.Trim();
            string getCity = txtCity.Text.Trim();

            if (getLoginId == "" || getName == "" || getPassword == "" || getReEnterPsw == "" || getAddress == "" ||
                getCity == "")
            {
                lbError.Text = "Please fill full the form!";
            } else
            {
                if (checkName.IsMatch(getName))
                {
                    if (getPassword.Length < 6 || getPassword.Length > 10)
                    {
                        lbError.Text = "Password must be between 6 and 10 characters";
                    }
                    else
                    {
                        if (getPassword != getReEnterPsw)
                        {
                            lbError.Text = "Please check your Re-enter password again!";
                        }
                        else
                        {
                            Registereduser data = new Registereduser()
                            {
                                LoginID = getLoginId,
                                Name = getName,
                                Password = getPassword,
                                Address = getAddress,
                                City = getCity
                            };

                            RegistrationDAO registrationDAO = new RegistrationDAO();

                            if (registrationDAO.AddNewUser(data))
                            {
                                lbError.Text = "";
                                txtLoginId.Text = "";
                                txtName.Text = "";
                                txtPassword.Text = "";
                                txtReEnterPsw.Text = "";
                                txtAddress.Text = "";
                                txtCity.Text = "";
                                MessageBox.Show("Add successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Add failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                } else
                {
                    lbError.Text = "Name should contain only alphabets";
                }
            }
        }
    }
}
