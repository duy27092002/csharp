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

namespace T3H_K35DL1_Winforms.Presenstation.UIKhoa
{
    public partial class frmKhoa : Form
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
        private bool result_ = false;
        public bool Result
        {
            get
            {
                return result_;
            }
        }
        private string maKhoa_ = "";
        public string MaKhoa_
        {
            set
            {
                maKhoa_ = value;
            }
        }
        public frmKhoa()
        {
            InitializeComponent();
        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                KhoaDAO dao = new KhoaDAO();
                var info = dao.GetSingleByID(maKhoa_);
                if (info != null)
                {
                    // hiển thị dữ liệu tương ứng với từng control (nếu có dữ liệu)
                    txtMaKhoa.Text = info.MaKhoa.Trim();
                    txtTenKhoa.Text = info.TenKhoa.Trim();
                    txtDiaChi.Text = info.DiaChi.Trim();
                    txtSDT.Text = info.SoDienThoai.Trim();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private Khoa InitKhoa()
        {
            Khoa khoa = new Khoa();
            khoa.MaKhoa = txtMaKhoa.Text.Trim();
            khoa.TenKhoa = txtTenKhoa.Text.Trim();
            khoa.DiaChi = txtDiaChi.Text.Trim();
            khoa.SoDienThoai = txtSDT.Text.Trim();

            return khoa;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            KhoaDAO dao = new KhoaDAO();
            // tạo biến tham chiếu
            Khoa info = InitKhoa();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
