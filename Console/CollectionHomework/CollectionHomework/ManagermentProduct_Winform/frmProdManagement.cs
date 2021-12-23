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

namespace ManagermentProduct_Winform
{
    public partial class frmProd : Form
    {
        Application_ application = new Application_();

        private void LoadData(List<Product> products)
        {
            dgvProduct.Rows.Clear();

            foreach(Product item in products)
            {
                dgvProduct.Rows.Add(item.Id.ToString(), item.PName, item.Price, item.Discounting);
            }
        }

        private void ClearForm()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtDiscounting.Text = "";
        }

        public frmProd()
        {
            InitializeComponent();
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id, name, price, discounting;

            id = txtId.Text.Trim();
            name = txtName.Text.Trim();
            price = txtPrice.Text.Trim();
            discounting = txtDiscounting.Text.Trim();

            if (application.Add(name, id, price, discounting))
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvProduct.Rows.Add(id, name, price, discounting);

                // reset form
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name, price;
            name = txtName.Text.Trim();
            price = txtPrice.Text.Trim();

            if (application.Update(txtId.Text, name, price, txtDiscounting.Text))
            {
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(application.GetList());
            } 
            else
            {
                MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearForm();

            txtId.Enabled = true;
            txtDiscounting.Enabled = true;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (application.Delete(txtId.Text))
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(application.GetList());
            } 
            else
            {
                MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearForm();

            txtId.Enabled = true;
            txtDiscounting.Enabled = true;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnCountByMaxPrice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Có " + application.CountByMaxPrice() + " sản phẩm với giá cao nhất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string minPrice = txtMinPrice.Text.Trim();
            string maxPrice = txtMaxPrice.Text.Trim();

            if (application.CheckMinMaxPrice(minPrice, maxPrice))
            {
                var getList = application.GetProductListByPrice(minPrice, maxPrice);
                LoadData(getList);
            } 
            else
            {
                return;
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;

            string getId = dgvProduct.CurrentRow.Cells["Id"].Value.ToString();

            var getProductInfo = application.GetProductById(int.Parse(getId));

            // đưa dữ liệu product vào các textbox
            txtId.Text = getProductInfo.Id.ToString();
            txtName.Text = getProductInfo.PName;
            txtPrice.Text = getProductInfo.Price.ToString();
            txtDiscounting.Text = getProductInfo.Discounting.ToString();
            txtId.Enabled = false;
            txtDiscounting.Enabled = false;
        }
    }
}
