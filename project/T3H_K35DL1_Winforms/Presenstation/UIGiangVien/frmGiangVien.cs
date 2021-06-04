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

namespace T3H_K35DL1_Winforms.Presenstation.UIGiangVien
{
    public partial class frmGiangVien : Form
    {
        // đánh dấu event mà người dùng chọn
        private bool isAdd_ = true;
        public bool IsAdd
        {
            set
            {
                isAdd_ = value;
            }
        }

        // đánh dấu đã thực thi xong event hay chưa? true là đã hoàn thành, false là k hoàn thành
        private bool result_ = true;
        public bool Result
        {
            get
            {
                return result_;
            }
        }
        private string maGV_ = "";
        public string MaGV
        {
            set
            {
                maGV_ = value;
            }
        }

        public frmGiangVien()
        {
            InitializeComponent();
        }

        // Hàm này sẽ load form Giảng Viên tùy thuộc vào trường đánh dấu isAdd
        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            // Hiện form edit Giảng Viên
            if (!isAdd_)
            {
                GiangVienDAO dao = new GiangVienDAO();
                var info = dao.GetSingleByID(maGV_);
                if (info != null)
                {
                    // hiển thị dữ liệu tương ứng với từng control (nếu có dữ liệu)
                    txtMaGV.Text = info.MaGV.Trim();
                    txtHoTen.Text = info.HoTen.Trim();
                    cbGioiTinh.Checked = (bool)info.GioiTinh;
                    dtpNgaySinh.Value = (DateTime)info.NgaySinh;
                    txtQueQuan.Text = info.QueQuan;
                    txtDiaChi.Text = info.DiaChi;
                    txtEMail.Text = info.EMail;
                    txtSDT.Text = info.SDT;
                    txtMaBM.Text = info.MaBM;
                }
                else
                {
                    this.Close();
                }
            }
        }

        // Hàm này lấy dữ liệu đầu vào của người nhập và trả lại những thông tin nhập vào đó
        private GiangVien InitGiangVien()
        {
            GiangVien giangVien = new GiangVien();
            giangVien.MaGV = txtMaGV.Text.Trim();
            giangVien.HoTen = txtHoTen.Text.Trim();
            giangVien.GioiTinh = cbGioiTinh.Checked;
            giangVien.NgaySinh = dtpNgaySinh.Value;
            giangVien.QueQuan = txtQueQuan.Text.Trim();
            giangVien.DiaChi = txtDiaChi.Text.Trim();
            giangVien.EMail = txtEMail.Text.Trim();
            giangVien.SDT = txtSDT.Text.Trim();
            giangVien.MaBM = txtMaBM.Text.Trim();

            return giangVien;
        }

        // Hàm này sẽ lưu lại những thông tin được sửa, thêm vào
        private void btnSave_Click(object sender, EventArgs e)
        {
            GiangVienDAO dao = new GiangVienDAO();
            // tạo biến tham chiếu
            GiangVien info = InitGiangVien();
            if (isAdd_)
            {
                if (dao.Add(info))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // đánh dấu là đã thực hiện thành công việc thêm dữ liệu để chuẩn bị Load lại danh sách
                    result_ = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dao.Edit(info))
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result_ = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hàm này cho phép người dùng khi click vào textBox mã bộ môn thì sẽ hiện form lựa chọn bộ môn
        private void txtMaBM_Click(object sender, EventArgs e)
        {
            frmSelectBoMon frm = new frmSelectBoMon();
            // hiển thị form lựa chọn bộ môn
            frm.ShowDialog();

            if (frm.Result_)
            {
                txtMaBM.Text = frm.MaBM_;
            }
        }
    }
}
