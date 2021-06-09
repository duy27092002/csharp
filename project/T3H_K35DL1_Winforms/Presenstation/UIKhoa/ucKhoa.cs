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

namespace T3H_K35DL1_Winforms.Presenstation.UIKhoa
{
    public partial class ucKhoa : UserControl
    {
        public ucKhoa()
        {
            InitializeComponent();
        }

        private void ucKhoa_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }

        private void LoadData()
        {
            KhoaDAO dao = new KhoaDAO();
            dgvKhoa.DataSource = dao.GetAll().Select(t => new { 
                MaKhoa = t.MaKhoa,
                TenKhoa = t.TenKhoa,
                DiaChi = t.DiaChi,
                SoDienThoai = t.SoDienThoai
            }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            KhoaDAO dao = new KhoaDAO();
            dgvKhoa.DataSource = dao.GetByKeyword(txtKeyword.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmKhoa frm = new frmKhoa();
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
            string maKhoa = dgvKhoa.CurrentRow.Cells["MaKhoa"].Value.ToString();
            frmKhoa frm = new frmKhoa();
            frm.IsAdd = false; // vì đây k phải event Add
            frm.Text = "Sửa thông tin khoa";
            frm.MaKhoa_ = maKhoa;
            frm.ShowDialog();
            // sau khi sửa thành công thì load lại danh sách
            if (frm.Result)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            KhoaDAO dao = new KhoaDAO();
            // lấy MaGV ngay tại dòng con trỏ chuột đang ở đó
            string maKhoa = dgvKhoa.CurrentRow.Cells["MaKhoa"].Value.ToString();
            // thực thi xóa và load lại danh sách sau khi xóa
            if (dao.Delete(maKhoa))
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
