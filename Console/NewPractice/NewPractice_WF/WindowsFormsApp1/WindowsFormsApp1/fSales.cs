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
    public partial class fSales : Form
    {
        public fSales()
        {
            InitializeComponent();
            btnSave.Enabled = false;
        }

        SalesDAO salesDAO = new SalesDAO();
        Regex isNumber = new Regex(@"^[0-9]+$");

        // thêm mới item
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            string getItemNo = txtItemNo.Text.Trim();
            string getItemName = txtItemName.Text.Trim();
            string getPrice = txtPrice.Text.Trim();
            string getQuantity = txtQuantity.Text.Trim();
            string getDateOfSales = dtpDateOfSales.Text.Trim();

            bool cashChecked = rdCash.Checked;
            bool creditCashChecked = rdCreditCard.Checked;

            string getModeOfPayment = cashChecked == true ? rdCash.Text :
                               creditCashChecked == true ? rdCreditCard.Text : "";

            if (getItemNo == "" || getItemName == "" || getPrice == "" || getQuantity == "" ||
                getDateOfSales == "" || getModeOfPayment == "")
            {
                lbErr.Text = "Please fill full the form!";
            } else
            {
                if (isNumber.IsMatch(getPrice) && isNumber.IsMatch(getQuantity))
                {
                    Sale data = new Sale()
                    {
                        ItemNo = getItemNo,
                        ItemName = getItemName,
                        Price = getPrice,
                        Quantity = int.Parse(getQuantity),
                        DateOfSales = getDateOfSales,
                        ModeOfPayment = getModeOfPayment
                    };

                    if (salesDAO.AddNewItem(data))
                    {
                        lbErr.Text = "";
                        MessageBox.Show("Add successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSave.Enabled = true;
                        btnAddNew.Enabled = false;
                        txtItemNo.Enabled = false;
                    } else
                    {
                        MessageBox.Show("Add failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    lbErr.Text = "Wrong digit format!";
                }
            }
        }

        // sửa thông tin item
        private void btnSave_Click(object sender, EventArgs e)
        {
            string getItemNo = txtItemNo.Text;
            string getItemName = txtItemName.Text.Trim();
            string getPrice = txtPrice.Text.Trim();
            string getQuantity = txtQuantity.Text.Trim();
            string getDateOfSales = dtpDateOfSales.Text.Trim();

            bool cashChecked = rdCash.Checked;
            bool creditCashChecked = rdCreditCard.Checked;

            string getModeOfPayment = cashChecked == true ? rdCash.Text :
                               creditCashChecked == true ? rdCreditCard.Text : "";

            if (getItemName == "" || getPrice == "" || getQuantity == "" ||
                getDateOfSales == "" || getModeOfPayment == "")
            {
                lbErr.Text = "Please fill full the form!";
            }
            else
            {
                if (isNumber.IsMatch(getPrice) && isNumber.IsMatch(getQuantity))
                {
                    Sale data = new Sale()
                    {
                        ItemNo = getItemNo,
                        ItemName = getItemName,
                        Price = getPrice,
                        Quantity = int.Parse(getQuantity),
                        DateOfSales = getDateOfSales,
                        ModeOfPayment = getModeOfPayment
                    };

                    if (salesDAO.SaveItem(data))
                    {
                        lbErr.Text = "";
                        MessageBox.Show("Save successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSave.Enabled = true;
                        btnAddNew.Enabled = false;
                        txtItemNo.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Save failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    lbErr.Text = "Wrong digit format!";
                }
            }
        }

        // đóng form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
