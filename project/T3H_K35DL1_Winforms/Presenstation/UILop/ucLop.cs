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

namespace T3H_K35DL1_Winforms.Presenstation.UILop
{
    public partial class ucLop : UserControl
    {
        public ucLop()
        {
            InitializeComponent();
        }

        private void ucLop_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }

        private void LoadData()
        {
            LopDAO dao = new LopDAO();
            dgvLop.DataSource = dao.GetAll().Select(t => new {
                MaLop = t.MaLop,
                TenLop = t.TenLop,
                MaGV = t.MaGV,
                MaCN = t.MaCN,
                NienKhoa = t.NienKhoa
            }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LopDAO dao = new LopDAO();
            dgvLop.DataSource = dao.GetByKeyword(txtKeyword.Text.Trim()).Select(t => new {
                MaLop = t.MaLop,
                TenLop = t.TenLop,
                MaGV = t.MaGV,
                MaCN = t.MaCN,
                NienKhoa = t.NienKhoa
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmLop frm = new frmLop();
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
            string maLop = dgvLop.CurrentRow.Cells["MaLop"].Value.ToString();
            frmLop frm = new frmLop();
            frm.IsAdd = false; // vì đây k phải event Add
            frm.Text = "Sửa thông tin lớp";
            frm.MaLop_ = maLop;
            frm.ShowDialog();
            // sau khi sửa thành công thì load lại danh sách
            if (frm.Result)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LopDAO dao = new LopDAO();
            // lấy MaGV ngay tại dòng con trỏ chuột đang ở đó
            string maLop = dgvLop.CurrentRow.Cells["MaLop"].Value.ToString();
            // thực thi xóa và load lại danh sách sau khi xóa
            if (dao.Delete(maLop))
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
