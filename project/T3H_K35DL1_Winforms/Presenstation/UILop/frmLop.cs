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

namespace T3H_K35DL1_Winforms.Presenstation.UILop
{
    public partial class frmLop : Form
    {
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
        private string maLop_ = "";
        public string MaLop_
        {
            set
            {
                maLop_ = value;
            }
        }
        public frmLop()
        {
            InitializeComponent();
        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            LoadMaGV();
            LoadMaCN();
            if (!isAdd_)
            {
                LopDAO dao = new LopDAO();
                var info = dao.GetSingleByID(maLop_);
                if (info != null)
                {
                    // hiển thị dữ liệu tương ứng với từng control (nếu có dữ liệu)
                    txtMaLop.Text = info.MaLop.Trim();
                    txtTenLop.Text = info.TenLop.Trim();
                    cbbMaGV.SelectedValue = info.MaGV.Trim();
                    cbbMaCN.SelectedValue = info.MaCN.Trim();
                    nudNienKhoa.Value = info.NienKhoa.Value;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void LoadMaGV()
        {
            GiangVienDAO dao = new GiangVienDAO();

            cbbMaGV.DisplayMember = "MaGV";
            cbbMaGV.ValueMember = "MaGV";
            cbbMaGV.DataSource = dao.GetAll();
        }

        private void LoadMaCN()
        {
            ChuyenNganhDAO dao = new ChuyenNganhDAO();

            cbbMaCN.DisplayMember = "MaCN";
            cbbMaCN.ValueMember = "MaCN";
            cbbMaCN.DataSource = dao.GetAll();
        }

        private Lop InitLop()
        {
            Lop lop = new Lop();
            lop.MaLop = txtMaLop.Text.Trim();
            lop.TenLop = txtTenLop.Text.Trim();
            lop.MaGV = cbbMaGV.SelectedValue.ToString();
            lop.MaCN = cbbMaCN.SelectedValue.ToString();
            lop.NienKhoa = (int)nudNienKhoa.Value;

            return lop;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LopDAO dao = new LopDAO();
            // tạo biến tham chiếu
            Lop info = InitLop();
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
