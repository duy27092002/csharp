using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3H_K35DL1_Winforms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }    

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddControl(Control control)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(control);
        }
        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            AddControl(new Presenstation.UISinhVien.ucSinhVien());
        }




        private void btnShowPanel_Click(object sender, EventArgs e)
        {
            UC.UcMain ucMain = new UC.UcMain();
            pnMain.Controls.Clear();
            pnMain.Controls.Add(ucMain);
        }

        private void btnShowPage_Click(object sender, EventArgs e)
        {
            UC.UcPage ucPage = new UC.UcPage();
            pnMain.Controls.Clear();
            pnMain.Controls.Add(ucPage);
        }
    }
}
