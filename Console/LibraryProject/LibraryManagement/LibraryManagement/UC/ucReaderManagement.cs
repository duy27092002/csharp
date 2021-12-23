using LibraryManagement.Models.DAO;
using LibraryManagement.Models.EF;
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
    public partial class ucReaderManagement : UserControl
    {
        ReaderDAO readerDAO = new ReaderDAO();

        int currentPage = 1;

        public ucReaderManagement()
        {
            InitializeComponent();

            txtRId.Text = SetRId();

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

        private void RestartForm()
        {
            txtRId.Text = SetRId();
            txtName.Text = "";
            txtPhone.Text = "";
            txtIdCardNumber.Text = "";
            txtAddress.Text = "";
            cbbStatus.SelectedItem = "";
        }

        private void LoadList(int currentPage)
        {
            dgvReader.DataSource = readerDAO.GetListByPage(currentPage);
        }

        private string SetRId()
        {
            return BaseDAO.RandomString(10);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string setRId = txtRId.Text;
            string getName = txtName.Text.Trim();
            string getPhone = txtPhone.Text.Trim();
            string getIdCardNumber = txtIdCardNumber.Text.Trim();
            string getAddress = txtAddress.Text.Trim();
            string getStatus = cbbStatus.Text;

            if (readerDAO.Add(setRId, getName, getPhone, getAddress, getIdCardNumber, getStatus))
            {
                RestartForm();
                LoadList(1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string setRId = txtRId.Text;
            string getName = txtName.Text.Trim();
            string getPhone = txtPhone.Text.Trim();
            string getIdCardNumber = txtIdCardNumber.Text.Trim();
            string getAddress = txtAddress.Text.Trim();
            string getStatus = cbbStatus.Text;

            if (readerDAO.Save(setRId, getName, getPhone, getAddress, getIdCardNumber, getStatus))
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
            string setRId = txtRId.Text;

            if (readerDAO.Delete(setRId))
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
            if (currentPage < readerDAO.GetPageCount())
            {
                LoadList(++currentPage);
                SetTrueEnabledForFirstAndPrevBtn();
            }

            if (currentPage == readerDAO.GetPageCount())
            {
                SetTrueEnabledForFirstAndPrevBtn();
                SetFalseEnabledForLastAndNextBtn();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = readerDAO.GetPageCount();

            LoadList(currentPage);

            SetTrueEnabledForFirstAndPrevBtn();
            SetFalseEnabledForLastAndNextBtn();
        }

        private void dgvReader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = btnDelete.Enabled = true;

            string getRId = dgvReader.CurrentRow.Cells["RId"].Value.ToString();

            var getInfo = readerDAO.GetSingleById(getRId);

            txtRId.Text = getInfo.RId;
            txtName.Text = getInfo.RName;
            txtPhone.Text = getInfo.RPhone;
            txtIdCardNumber.Text = getInfo.RIdCardNumber;
            txtAddress.Text = getInfo.RAddress;
            cbbStatus.SelectedItem = getInfo.RStatus == 1 ? "Còn dịch vụ" : "Đã hết dịch vụ";
        }
    }
}
