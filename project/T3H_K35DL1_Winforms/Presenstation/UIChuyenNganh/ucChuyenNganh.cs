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

namespace T3H_K35DL1_Winforms.Presenstation.UIChuyenNganh
{
    public partial class ucChuyenNganh : UserControl
    {
        public ucChuyenNganh()
        {
            InitializeComponent();
        }

        private void ucChuyenNganh_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }

        private void LoadData()
        {
            ChuyenNganhDAO dao = new ChuyenNganhDAO();
            dgvChuyenNganh.DataSource = dao.GetAll().Select(t => new {
                MaCN = t.MaCN,
                TenCN = t.TenCN,
                MaKhoa = t.MaKhoa,
                TenKhoa = t.Khoa.TenKhoa
            }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ChuyenNganhDAO dao = new ChuyenNganhDAO();
            dgvChuyenNganh.DataSource = dao.GetByKeyword(txtKeyword.Text.Trim()).Select(t => new {
                MaCN = t.MaCN,
                TenCN = t.TenCN,
                MaKhoa = t.MaKhoa,
                TenKhoa = t.Khoa.TenKhoa
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmChuyenNganh frm = new frmChuyenNganh();
            // vì đây là event Add nên IsAdd = true;
            frm.IsAdd = true;
            frm.ShowDialog();
            // sau khi thêm thành công thì thực hiện Load lại danh sách
            if (frm.Result)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // lấy ra maGV ở cái dòng hiện tại mà con trỏ chuột đang trỏ (tức là k nhất thiết phải chọn cả 1 dòng)
            string maCN = dgvChuyenNganh.CurrentRow.Cells["MaCN"].Value.ToString();
            frmChuyenNganh frm = new frmChuyenNganh();
            frm.IsAdd = false; // vì đây k phải event Add
            frm.Text = "Sửa thông tin chuyên ngành";
            frm.MaCN_ = maCN;
            frm.ShowDialog();
            // sau khi sửa thành công thì load lại danh sách
            if (frm.Result)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ChuyenNganhDAO dao = new ChuyenNganhDAO();
            // lấy MaGV ngay tại dòng con trỏ chuột đang ở đó
            string maCN = dgvChuyenNganh.CurrentRow.Cells["MaCN"].Value.ToString();
            // thực thi xóa và load lại danh sách sau khi xóa
            if (dao.Delete(maCN))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
