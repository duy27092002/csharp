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

namespace T3H_K35DL1_Winforms.Presenstation.UIBoMon
{
    public partial class frmBoMon : Form
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
        private string maBM_ = "";
        public string MaBM_
        {
            set
            {
                maBM_ = value;
            }
        }
        public frmBoMon()
        {
            InitializeComponent();
        }

        private void frmBoMon_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            if (!isAdd_)
            {
                BoMonDAO dao = new BoMonDAO();
                var info = dao.GetSingleByID(maBM_);
                if (info != null)
                {
                    // hiển thị dữ liệu tương ứng với từng control (nếu có dữ liệu)
                    txtMaBM.Text = info.MaBM.Trim();
                    txtTenBM.Text = info.TenBM.Trim();
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

        private BoMon InitBM()
        {
            BoMon boMon = new BoMon();
            boMon.MaBM = txtMaBM.Text.Trim();
            boMon.TenBM = txtTenBM.Text.Trim();
            boMon.MaKhoa = cbbMaKhoa.SelectedValue.ToString();

            return boMon;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BoMonDAO dao = new BoMonDAO();
            // tạo biến tham chiếu
            BoMon info = InitBM();
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
