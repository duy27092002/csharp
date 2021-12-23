using LibraryManagement.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.UC
{
    public partial class ucBookManagement : UserControl
    {
        BookDAO bookDAO = new BookDAO();

        int currentPage = 1;

        public ucBookManagement()
        {
            InitializeComponent();

            txtBId.Text = SetBId();

            LoadList(1);

            btnSave.Enabled = btnDelete.Enabled = false;

            SetFalseEnabledForFirstAndPrevBtn();
        }

        private void SetTrueEnabledForFirstAndPrevBtn()
        {
            btnPreviousPage.Enabled = btnFirstPage.Enabled = true;
        }

        private void SetFalseEnabledForFirstAndPrevBtn()
        {
            btnFirstPage.Enabled = btnPreviousPage.Enabled = false;
        }

        private void SetTrueEnabledForLastAndNextBtn()
        {
            btnNextPage.Enabled = btnLastPage.Enabled = true;
        }

        private void SetFalseEnabledForLastAndNextBtn()
        {
            btnNextPage.Enabled = btnLastPage.Enabled = false;
        }

        private string SetBId()
        {
            return BaseDAO.RandomString(10);
        }

        private void RestartForm()
        {
            txtBId.Text = SetBId();
            txtName.Text = "";
            txtAuthor.Text = "";
            txtPublisher.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtYear.Text = "";
        }

        private void LoadList(int currentPage)
        {
            dgvBook.DataSource = bookDAO.GetListByPage(currentPage);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string getBId = txtBId.Text;
            string getBName = txtName.Text.Trim();
            string getBAuthor = txtAuthor.Text.Trim();
            string getBPublisher = txtPublisher.Text.Trim();
            string getPrice = txtPrice.Text.Trim();
            string getQuantity = txtQuantity.Text.Trim();
            string getInportTime = dtpInportTime.Value.ToString();
            string getBYear = txtYear.Text.Trim();

            if (bookDAO.Add(getBId, getBName, getBAuthor, getBPublisher, getPrice, getQuantity, getInportTime, getBYear))
            {
                RestartForm();
                LoadList(1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string getBId = txtBId.Text;
            string getBName = txtName.Text.Trim();
            string getBAuthor = txtAuthor.Text.Trim();
            string getBPublisher = txtPublisher.Text.Trim();
            string getPrice = txtPrice.Text.Trim();
            string getQuantity = txtQuantity.Text.Trim();
            string getInportTime = dtpInportTime.Value.ToString();
            string getBYear = txtYear.Text.Trim();

            if (bookDAO.Save(getBId, getBName, getBAuthor, getBPublisher, getPrice, getQuantity, getInportTime, getBYear))
            {
                RestartForm();
                LoadList(currentPage);
            }
            else
            {
                RestartForm();
            }

            btnAdd.Enabled = true;
            btnSave.Enabled = btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string getBId = txtBId.Text;

            if (bookDAO.Delete(getBId))
            {
                RestartForm();
                LoadList(currentPage);
            }
            else
            {
                RestartForm();
            }

            btnDelete.Enabled = btnSave.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 1;

            LoadList(currentPage);

            SetFalseEnabledForFirstAndPrevBtn();
            SetTrueEnabledForLastAndNextBtn();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                LoadList(--currentPage);
                SetTrueEnabledForLastAndNextBtn();
            }

            if (currentPage == 1)
            {
                SetFalseEnabledForFirstAndPrevBtn();
                SetTrueEnabledForLastAndNextBtn();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < bookDAO.GetPageCount())
            {
                LoadList(++currentPage);
                SetTrueEnabledForFirstAndPrevBtn();
            }

            if (currentPage == bookDAO.GetPageCount())
            {
                SetTrueEnabledForFirstAndPrevBtn();
                SetFalseEnabledForLastAndNextBtn();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = bookDAO.GetPageCount();

            LoadList(currentPage);

            SetTrueEnabledForFirstAndPrevBtn();
            SetFalseEnabledForLastAndNextBtn();
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = btnDelete.Enabled = true;

            string getBId = dgvBook.CurrentRow.Cells["BId"].Value.ToString();

            var getInfo = bookDAO.GetSingleById(getBId);

            txtBId.Text = getInfo.BId;
            txtName.Text = getInfo.BName;
            txtAuthor.Text = getInfo.BAuthor;
            txtPublisher.Text = getInfo.BPublisher;
            txtPrice.Text = getInfo.BPrice.ToString();
            txtQuantity.Text = getInfo.BQuantity.ToString();
            txtYear.Text = getInfo.BYear.ToString();
            dtpInportTime.Text = getInfo.BInportTime.ToString("MM/dd/yyyy");
        }
    }
}
