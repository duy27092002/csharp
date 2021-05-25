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
    public partial class ucSinhVien : UserControl
    {
        public ucSinhVien()
        {
            InitializeComponent();
        }

        private void ucSinhVien_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            LoadData();
        }

        private void LoadData()
        {
            SinhVienDAO dao = new SinhVienDAO();
            dgvSinhVien.DataSource = dao.GetAll();
        }
    }
}
