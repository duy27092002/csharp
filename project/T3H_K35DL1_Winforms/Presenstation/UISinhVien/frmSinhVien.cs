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

namespace T3H_K35DL1_Winforms.Presenstation.UISinhVien
{
    public partial class frmSinhVien : Form
    {
        private bool isAdd_ = true;
        public bool IsAdd
        {
            set
            {
                isAdd_ = value;
            }
        }
        private bool result_ = true;
        public bool Result
        {
            get
            {
                return result_;
            }
        }
        private string maSV_ = "";
        public string MaSV
        {
            set
            {
                maSV_ = value;
            }
        }
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                SinhVienDAO dao = new SinhVienDAO();
                var info = dao.GetSingleByID(maSV_);
                if (info != null)
                {
                    txtMaSV.Text = info.MaSV.Trim();
                    txtHoTen.Text = info.HoTen.Trim();
                    cbGioiTinh.Checked = (bool)info.GioiTinh;
                    dtpNgaySinh.Value = (DateTime)info.NgaySinh;
                    txtQueQuan.Text = info.QueQuan;
                    txtDiaChi.Text = info.DiaChi;
                    txtEMail.Text = info.EMail;
                    txtSDT.Text = info.SDT;
                    txtMaLop.Text = info.MaLop;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private SinhVien InitSinhVien()
        {
            SinhVien sinhVien = new SinhVien();
            sinhVien.MaSV = txtMaSV.Text.Trim();
            sinhVien.HoTen = txtHoTen.Text.Trim();
            sinhVien.GioiTinh = cbGioiTinh.Checked;
            sinhVien.NgaySinh = dtpNgaySinh.Value;
            sinhVien.QueQuan = txtQueQuan.Text.Trim();
            sinhVien.DiaChi = txtDiaChi.Text.Trim();
            sinhVien.EMail = txtEMail.Text.Trim();
            sinhVien.SDT = txtSDT.Text.Trim();
            sinhVien.MaLop = txtMaLop.Text.Trim();

            return sinhVien;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SinhVienDAO dao = new SinhVienDAO();
            SinhVien info = InitSinhVien();
            if (isAdd_)
            {
                if (dao.Add(info))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result_ = true;
                    this.Close();
                } else
                {
                    MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
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

        private void txtMaLop_Click(object sender, EventArgs e)
        {
            frmSelectMaLop frm = new frmSelectMaLop();

            frm.ShowDialog();

            if (frm.Result_)
            {
                txtMaLop.Text = frm.MaLop_;
            }
        }
    }
}
