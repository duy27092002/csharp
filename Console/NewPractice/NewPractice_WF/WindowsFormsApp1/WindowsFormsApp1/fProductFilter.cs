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
    public partial class fProductFilter : Form
    {

        CategoryDAO categoryDAO = new CategoryDAO();
        ProductDAO productDAO = new ProductDAO();

        public fProductFilter()
        {
            InitializeComponent();

            // lấy danh sách tên category
            foreach(Category item in categoryDAO.GetCategoryList())
            {
                cbbCategory.Items.Add(item.CategoryName);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Regex isNumber = new Regex(@"^[0-9]+$");
            string getCategoryName = cbbCategory.Text;
            string getMinPrice = txtMinPrice.Text.Trim();
            string getMaxPrice = txtMaxPrice.Text.Trim();

            if (getCategoryName == null || getMinPrice == "" || getMaxPrice == "")
            {
                lbError.Text = "Please fill full the form!";
            } else
            {
                if (isNumber.IsMatch(getMinPrice) && isNumber.IsMatch(getMaxPrice))
                {
                    if (float.Parse(getMinPrice) < float.Parse(getMaxPrice))
                    {
                        lbError.Text = "";
                        dgvProducts.DataSource = productDAO.GetProducts(categoryDAO.GetCategoryId(getCategoryName), float.Parse(getMinPrice), float.Parse(getMaxPrice));
                    } else
                    {
                        lbError.Text = "Please check min price and max price again!";
                    }
                } else
                {
                    lbError.Text = "Wrong digit format!";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
