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

namespace T3H_K35DL1_Winforms.Presenstation.UISinhVien
{
    public partial class frmSelectMaLop : Form
    {
        private bool result_ = false;

        public bool Result_ { get => result_;}
        
        private string maLop_;

        public string MaLop_ { get => maLop_;}

        public frmSelectMaLop()
        {
            InitializeComponent();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {

        }

        private void frmSelectMaLop_Load(object sender, EventArgs e)
        {
            LoadKhoa();
        }

        private void LoadKhoa()
        {
            KhoaDAO dao = new KhoaDAO();

            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "MaKhoa";
            cbbKhoa.DataSource = dao.GetAll();
        }

        private void LoadChuyenNganh()
        {
            string maKhoa = "";

            if (cbbKhoa.Items.Count > 0)
            {
                maKhoa = cbbKhoa.SelectedValue.ToString().Trim();
            }

            ChuyenNganhDAO dao = new ChuyenNganhDAO();

            cbbChuyenNganh.DisplayMember = "TenCN";
            cbbChuyenNganh.ValueMember = "MaCN";
            cbbChuyenNganh.DataSource = dao.GetByMaKhoa(maKhoa);
        }

        private void LoadLop()
        {
            string maCN = "";

            if (cbbChuyenNganh.Items.Count > 0)
            {
                maCN = cbbChuyenNganh.SelectedValue.ToString().Trim();
            }

            LopDAO dao = new LopDAO();

            var list = dao.GetByMaChuyenNganh(maCN);

            dgvLop.DataSource = list;

            if (list.Count > 0)
            {
                btnChosseClass.Enabled = true;
            } else
            {
                btnChosseClass.Enabled = false;
            }
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChuyenNganh();
        }

        private void cbbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLop();
        }

        private void btnChosseClass_Click(object sender, EventArgs e)
        {
            maLop_ = dgvLop.CurrentRow.Cells["MaLop"].Value.ToString();

            result_ = true;

            this.Close();
        }
    }
}
