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

namespace T3H_K35DL1_Winforms.Presenstation.UIBoMon
{
    public partial class ucBoMon : UserControl
    {
        public ucBoMon()
        {
            InitializeComponent();
        }

        private void ucBoMon_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }

        private void LoadData()
        {
            BoMonDAO dao = new BoMonDAO();
            dgvBM.DataSource = dao.GetAll().Select(t => new {
                MaBM = t.MaBM,
                TenBM = t.TenBM,
                MaKhoa = t.MaKhoa,
                TenKhoa = t.Khoa.TenKhoa
            }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BoMonDAO dao = new BoMonDAO();
            dgvBM.DataSource = dao.GetByKeyword(txtKeyword.Text.Trim()).Select(t => new {
                MaBM = t.MaBM,
                TenBM = t.TenBM,
                MaKhoa = t.MaKhoa,
                TenKhoa = t.Khoa.TenKhoa
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBoMon frm = new frmBoMon();
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
            string maBM = dgvBM.CurrentRow.Cells["MaBM"].Value.ToString();
            frmBoMon frm = new frmBoMon();
            frm.IsAdd = false; // vì đây k phải event Add
            frm.Text = "Sửa thông tin bộ môn";
            frm.MaBM_ = maBM;
            frm.ShowDialog();
            // sau khi sửa thành công thì load lại danh sách
            if (frm.Result)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BoMonDAO dao = new BoMonDAO();
            // lấy MaGV ngay tại dòng con trỏ chuột đang ở đó
            string maBM = dgvBM.CurrentRow.Cells["MaBM"].Value.ToString();
            // thực thi xóa và load lại danh sách sau khi xóa
            if (dao.Delete(maBM))
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
