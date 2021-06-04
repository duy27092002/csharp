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

namespace T3H_K35DL1_Winforms.Presenstation.UIGiangVien
{
    public partial class ucGiangVien : UserControl
    {
        public ucGiangVien()
        {
            InitializeComponent();
        }

        //Load tất cả dữ liệu trong bảng Giảng Viên (liệt kê danh sách)
        // Những thời điểm Load lại: ban đầu khi vào form và sau khi thêm, sửa, xóa
        private void ucGiangVien_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }

        // Hàm load danh sách Giảng Viên
        private void LoadData()
        {
            GiangVienDAO dao = new GiangVienDAO();
            dgvGiangVien.DataSource = dao.GetAll();
        }

        // Hàm trả về danh sách các Giảng Viên phù hợp với keyword
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GiangVienDAO dao = new GiangVienDAO();
            dgvGiangVien.DataSource = dao.GetByKeyword(txtKeyword.Text.Trim());
        }

        // Hàm này Show ra form thêm Giảng Viên
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmGiangVien frm = new frmGiangVien();
            // vì đây là event Add nên IsAdd = true;
            frm.IsAdd = true;
            frm.ShowDialog();
            // sau khi thêm thành công thì thực hiện Load lại danh sách
            if (frm.Result)
            {
                LoadData();
            }
        }

        // Hàm này sẽ Show ra form edit Giảng Viên với thông tin lấy theo maGV truyền vào
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // lấy ra maGV ở cái dòng hiện tại mà con trỏ chuột đang trỏ (tức là k nhất thiết phải chọn cả 1 dòng)
            string maGV = dgvGiangVien.CurrentRow.Cells["MaGV"].Value.ToString();
            frmGiangVien frm = new frmGiangVien();
            frm.IsAdd = false; // vì đây k phải event Add
            frm.MaGV = maGV;
            frm.ShowDialog();
            // sau khi sửa thành công thì load lại danh sách
            if (frm.Result)
            {
                LoadData();
            }
        }

        // Hàm này xóa 1 Giảng Viên theo maGV
        private void btnDelete_Click(object sender, EventArgs e)
        {
            GiangVienDAO dao = new GiangVienDAO();
            // lấy MaGV ngay tại dòng con trỏ chuột đang ở đó
            string maGV = dgvGiangVien.CurrentRow.Cells["MaGV"].Value.ToString();
            // thực thi xóa và load lại danh sách sau khi xóa
            if (dao.Delete(maGV))
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
