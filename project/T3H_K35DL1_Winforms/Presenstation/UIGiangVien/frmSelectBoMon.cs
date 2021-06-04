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
    public partial class frmSelectBoMon : Form
    {
        private bool result_ = false;

        public bool Result_ { get => result_; }

        private string maBM_;

        public string MaBM_ { get => maBM_; }

        public frmSelectBoMon()
        {
            InitializeComponent();
        }

        private void frmSelectBoMon_Load(object sender, EventArgs e)
        {
            LoadKhoa();
        }

        // Hàm này sẽ load tên khoa
        private void LoadKhoa()
        {
            KhoaDAO dao = new KhoaDAO();

            cbbKhoa.DisplayMember = "TenKhoa"; // hiển thị tên khoa
            cbbKhoa.ValueMember = "MaKhoa"; // khi nhấn chọn tên khoa thì thực chất là chọn mã khoa tương ứng
            cbbKhoa.DataSource = dao.GetAll(); // đổ hết tên khoa ra cbbKhoa (ở đây đổ dữ liệu theo DisplayMember)
        }

        // Hàm này sẽ load tên chuyên ngành tương ứng với mã khoa
        private void LoadChuyenNganh()
        {
            string maKhoa = "";

            // lấy mã khoa từ cbbKhoa
            if (cbbKhoa.Items.Count > 0)
            {
                maKhoa = cbbKhoa.SelectedValue.ToString().Trim();
            }

            ChuyenNganhDAO dao = new ChuyenNganhDAO();

            cbbChuyenNganh.DisplayMember = "TenCN";
            cbbChuyenNganh.ValueMember = "MaCN";
            // đổ dữ liệu tương ứng với maKhoa dc chọn vào cbbChuyenNganh
            cbbChuyenNganh.DataSource = dao.GetByMaKhoa(maKhoa);
        }

        // Hàm này sẽ hiển thị dữ liệu liên quan đến mã khoa trong bảng Bộ Môn
        private void LoadBM()
        {
            string maKhoa = "";

            if (cbbChuyenNganh.Items.Count > 0)
            {
                maKhoa = cbbKhoa.SelectedValue.ToString().Trim();
            }

            BoMonDAO dao = new BoMonDAO();

            var list = dao.GetByMaKhoa(maKhoa);

            dgvBoMon.DataSource = list;

            // nếu tồn tại danh sách đc lấy theo maKhoa thì mới hiển thị nút chọn bộ môn
            if (list.Count > 0)
            {
                btnChonBM.Enabled = true;
            }
            else
            {
                btnChonBM.Enabled = false;
            }
        }

        // Hàm này cho biết khi thay đổi lựa chọn trong cbbKhoa thì giá trị hiển thị bên cbbChuyenNganh cũng thay đổi tương ứng
        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChuyenNganh();
        }

        private void cbbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBM();
        }

        private void btnChonBM_Click(object sender, EventArgs e)
        {
            maBM_ = dgvBoMon.CurrentRow.Cells["MaBM"].Value.ToString();
            // đánh dấu đã thực hiện thành công event
            result_ = true;

            this.Close();
        }
    }
}
