using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3H_K35DL1_Winforms.Models.DAO;
using T3H_K35DL1_Winforms.Models.EF;

namespace T3H_K35DL1_Winforms.Presenstation.UISinhVien
{
    public partial class ucSinhVien : UserControl
    {
        public ucSinhVien()
        {
            InitializeComponent();
        }

        private void ucSinhVien_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            LoadData();
        }

        private void LoadData()
        {
            SinhVienDAO dao = new SinhVienDAO();
            dgvSinhVien.DataSource = dao.GetAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SinhVienDAO dao = new SinhVienDAO();
            dgvSinhVien.DataSource = dao.GetByKeyword(txtKeyword.Text.Trim());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string maSV = dgvSinhVien.CurrentRow.Cells["MaSV"].Value.ToString();
            frmSinhVien frm = new frmSinhVien();
            frm.IsAdd = false;
            frm.MaSV = maSV;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSinhVien frm = new frmSinhVien();
            frm.IsAdd = true;
            frm.ShowDialog();
            if (frm.Result)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SinhVienDAO dao = new SinhVienDAO();

            string maSV = dgvSinhVien.CurrentRow.Cells["MaSV"].Value.ToString();

            if (dao.Delete(maSV))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            } else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
