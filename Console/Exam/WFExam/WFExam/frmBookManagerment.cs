using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFExam.Models;

namespace WFExam
{
    public partial class frmBookManagerment : Form
    {
        public frmBookManagerment()
        {
            InitializeComponent();
        }

        // load danh sách book
        private void frmBookManagerment_Load(object sender, EventArgs e)
        {
            var books = new List<Book>()
            {
                 new Book("Alex Smith", 10, "abcabc", "What's happend!", 1)
            };
            dgvBookList.DataSource = books;
        }

        // thêm mới book
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string getAuthor = txtAuthor.Text.Trim();
            string getTitle = txtTitle.Text.Trim();
            string getISBN = txtISBN.Text.Trim();

            if (getAuthor.Length == 0 || getTitle.Length == 0 || getISBN.Length == 0)
            {
                lbError.Text = "Please fill full the form!";
            } else
            {
                lbError.Text = "";

                // thực hiện thêm book mới
            }
        }

        // xóa book
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        // Nút lùi trang
        private void btnPageBackward_Click(object sender, EventArgs e)
        {

        }

        // Nút trang tiếp theo
        private void btnPageForward_Click(object sender, EventArgs e)
        {

        }

        // lấy đối tượng book cần xóa
        private void dgvBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
