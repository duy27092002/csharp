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

namespace T3H_K35DL1_Winforms.Presenstation.UIChuyenNganh
{
    public partial class frmChuyenNganh : Form
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
        private string maCN_ = "";
        public string MaCN_
        {
            set
            {
                maCN_ = value;
            }
        }
        public frmChuyenNganh()
        {
            InitializeComponent();
        }

        private void frmChuyenNganh_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            if (!isAdd_)
            {
                ChuyenNganhDAO dao = new ChuyenNganhDAO();
                var info = dao.GetSingleByID(maCN_);
                if (info != null)
                {
                    // hiển thị dữ liệu tương ứng với từng control (nếu có dữ liệu)
                    txtMaCN.Text = info.MaCN.Trim();
                    txtTenCN.Text = info.TenCN.Trim();
                    cbbMaKhoa.SelectedValue = info.MaKhoa;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void LoadKhoa()
        {
            KhoaDAO dao = new KhoaDAO();

            cbbMaKhoa.DisplayMember = "TenKhoa";
            cbbMaKhoa.ValueMember = "MaKhoa";
            cbbMaKhoa.DataSource = dao.GetAll();
        }

        private ChuyenNganh InitCN()
        {
            ChuyenNganh chuyenNganh = new ChuyenNganh();
            chuyenNganh.MaCN = txtMaCN.Text.Trim();
            chuyenNganh.TenCN = txtTenCN.Text.Trim();
            chuyenNganh.MaKhoa = cbbMaKhoa.SelectedValue.ToString();

            return chuyenNganh;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ChuyenNganhDAO dao = new ChuyenNganhDAO();
            // tạo biến tham chiếu
            ChuyenNganh info = InitCN();
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
