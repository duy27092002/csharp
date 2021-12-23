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
    public partial class ucPromissoryNote : UserControl
    {
        PromissoryDAO pnDAO = new PromissoryDAO();
        PromissoryNoteDetailsDAO pndDAO = new PromissoryNoteDetailsDAO();

        int currentPageOfPN = 1, currentPageOfPNDetails = 1;

        public ucPromissoryNote()
        {
            InitializeComponent();

            LoadComboboxList(1);

            LoadComboboxList(2);

            LoadComboboxList(3);

            // set mã phiếu tự random và mã nhân viên mặc định sau khi đăng nhập thành công
            txtPNId.Text = SetPNId();
            txtUId.Text = UserDAO.userId;

            LoadPromissoryNoteList(1, true);

            LoadPromissoryNoteList(1, false);

            txtCost.Text = "5000";

            // false enable nút sửa và xóa phần tạo phiếu mới
            btnSavePN.Enabled = btnDeletePN.Enabled = false;

            // false enable nút sửa và xóa phần tạo chi tiết phiếu
            btnSavePNDetails.Enabled = btnDeletePNDetails.Enabled = false;

            // false enable 2 nút trang 1, trang trước phần tạo phiếu mới
            SetFalseEnabledForFirstAndPrevBtn(true);

            // false enable 2 nút trang 1, trang trước phần tạo chi tiết phiếu
            SetFalseEnabledForFirstAndPrevBtn(false);
        }

        // load danh sách trong các combobox
        // 1 đánh dấu cho combobox mã đọc giả
        // 2 đánh dấu cho combobox mã phiếu
        // 3 đánh dấu cho combobox mã sách
        private void LoadComboboxList(byte type)
        {
            if (type == 1)
            {
                cbbRId.DataSource = pnDAO.GetRIdList();
                cbbRId.DisplayMember = "RId";
                cbbRId.ValueMember = "RId";
            }
            else if (type == 2)
            {
                cbbPNId.DataSource = pndDAO.GetPNIdList();
                cbbPNId.DisplayMember = "PNId";
                cbbPNId.ValueMember = "PNId";
            }
            else
            {
                cbbBId.DataSource = pndDAO.GetBIdList();
                cbbBId.DisplayMember = "BId";
                cbbBId.ValueMember = "BId";
            }
        }

        private void SetTrueEnabledForFirstAndPrevBtn(bool type)
        {
            if (type)
            {
                btnPreviousPagePN.Enabled = btnFirstPagePN.Enabled = true;
            }
            else
            {
                btnPreviousPagePNDetails.Enabled = btnFirstPagePNDetails.Enabled = true;
            }
        }

        private void SetFalseEnabledForFirstAndPrevBtn(bool type)
        {
            if (type)
            {
                btnFirstPagePN.Enabled = btnPreviousPagePN.Enabled = false;
            }
            else
            {
                btnFirstPagePNDetails.Enabled = btnPreviousPagePNDetails.Enabled = false;
            }
        }

        private void SetTrueEnabledForLastAndNextBtn(bool type)
        {
            if (type)
            {
                btnNextPagePN.Enabled = btnLastPagePN.Enabled = true;
            }
            else
            {
                btnNextPagePNDetails.Enabled = btnLastPagePNDetails.Enabled = true;
            }
        }

        private void SetFalseEnabledForLastAndNextBtn(bool type)
        {
            if (type)
            {
                btnNextPagePN.Enabled = btnLastPagePN.Enabled = false;
            }
            else
            {
                btnNextPagePNDetails.Enabled = btnLastPagePNDetails.Enabled = false;
            }
        }

        private void RestartForm(bool type)
        {
            if (type)
            {
                txtPNId.Text = SetPNId();
                cbbRId.Text = "";
            }
            else
            {
                cbbPNId.Text = "";
                cbbBId.Text = "";
                txtCost.Text = "";
                cbbStatus.Text = "";
            }
        }

        private void LoadPromissoryNoteList(int currentPage, bool type)
        {
            if (type)
            {
                dgvPromissoryNote.DataSource = pnDAO.GetPromissoryNoteListByPage(currentPage);
            }
            else
            {
                dgvPNDetails.DataSource = pndDAO.GetPNDetailsListByPage(currentPage);
            }
        }

        #region xử lý phần tạo mới phiếu mượn-trả

        private string SetPNId()
        {
            return BaseDAO.RandomString(10);
        }

        private void btnAddPN_Click(object sender, EventArgs e)
        {
            string getReaderId = cbbRId.Text.Trim();
            string getPNId = txtPNId.Text;
            string getEmpId = txtUId.Text;

            if (pnDAO.AddNewPromissoryNote(getReaderId, getEmpId, getPNId))
            {
                RestartForm(true);
                LoadPromissoryNoteList(1, true);
            }
        }

        private void btnSavePN_Click(object sender, EventArgs e)
        {
            string getReaderId = cbbRId.Text.Trim();
            string getPNId = txtPNId.Text;
            string getEmpId = txtUId.Text;

            if (pnDAO.SavePromissoryNote(getReaderId, getEmpId, getPNId))
            {
                RestartForm(true);
                LoadPromissoryNoteList(currentPageOfPN, true);
            }
            else
            {
                RestartForm(true);
            }

            btnAddPN.Enabled = true;
            btnSavePN.Enabled = btnDeletePN.Enabled = false;
        }

        private void btnDeletePN_Click(object sender, EventArgs e)
        {
            string getPNId = txtPNId.Text;

            if (pnDAO.DeletePromissoryNote(getPNId))
            {
                RestartForm(true);
                LoadPromissoryNoteList(currentPageOfPN, true);
            }
            else
            {
                RestartForm(true);
            }

            btnDeletePN.Enabled = btnSavePN.Enabled = false;
            btnAddPN.Enabled = true;
        }

        private void btnFirstPagePN_Click(object sender, EventArgs e)
        {
            currentPageOfPN = 1;

            LoadPromissoryNoteList(currentPageOfPN, true);

            SetFalseEnabledForFirstAndPrevBtn(true);
            SetTrueEnabledForLastAndNextBtn(true);
        }

        private void btnPreviousPagePN_Click(object sender, EventArgs e)
        {
            if (currentPageOfPN > 1)
            {
                LoadPromissoryNoteList(--currentPageOfPN, true);
                SetTrueEnabledForLastAndNextBtn(true);
            }

            if (currentPageOfPN == 1)
            {
                SetFalseEnabledForFirstAndPrevBtn(true);
                SetTrueEnabledForLastAndNextBtn(true);
            }
        }

        private void btnNextPagePN_Click(object sender, EventArgs e)
        {
            if (currentPageOfPN < pnDAO.GetPageCountOfPromissoryNotes())
            {
                LoadPromissoryNoteList(++currentPageOfPN, true);
                SetTrueEnabledForFirstAndPrevBtn(true);
            }

            if (currentPageOfPN == pnDAO.GetPageCountOfPromissoryNotes())
            {
                SetTrueEnabledForFirstAndPrevBtn(true);
                SetFalseEnabledForLastAndNextBtn(true);
            }
        }

        private void btnLastPagePN_Click(object sender, EventArgs e)
        {
            currentPageOfPN = pnDAO.GetPageCountOfPromissoryNotes();

            LoadPromissoryNoteList(currentPageOfPN, true);

            SetTrueEnabledForFirstAndPrevBtn(true);
            SetFalseEnabledForLastAndNextBtn(true);
        }

        private void dgvPromissoryNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddPN.Enabled = false;
            btnSavePN.Enabled = btnDeletePN.Enabled = true;

            string getPNId = dgvPromissoryNote.CurrentRow.Cells["PNId"].Value.ToString();

            var getInfo = pnDAO.GetPNByPNId(getPNId);

            cbbRId.Text = getInfo.RId;
            txtUId.Text = getInfo.UId;
            txtPNId.Text = getInfo.PNId;
        }

        #endregion


        #region xử lý thao tác ở phần chi tiết phiếu mượn-trả

        private void btnAddPNDetails_Click(object sender, EventArgs e)
        {
            string getPNId = cbbPNId.Text.Trim();
            string getBId = cbbBId.Text.Trim();
            string getBorrowedDate = dtpBorrowedDate.Value.ToString();
            string getPayDate = dtpPayDate.Value.ToString();
            string getCost = txtCost.Text.Trim();
            string getStatus = cbbStatus.Text;

            if (pndDAO.Add(getPNId, getBId, getBorrowedDate, getPayDate, getCost, getStatus))
            {
                RestartForm(false);
                LoadPromissoryNoteList(1, false);
            }
        }

        private void btnSavePNDetails_Click(object sender, EventArgs e)
        {
            string getPNId = cbbPNId.Text.Trim();
            string getBId = cbbBId.Text.Trim();
            string getBorrowedDate = dtpBorrowedDate.Value.ToString();
            string getPayDate = dtpPayDate.Value.ToString();
            string getCost = txtCost.Text.Trim();
            string getStatus = (string)cbbStatus.SelectedItem;

            if (pndDAO.Save(getPNId, getBId, getBorrowedDate, getPayDate, getCost, getStatus))
            {
                RestartForm(false);
                LoadPromissoryNoteList(currentPageOfPNDetails, false);
            }
            else
            {
                RestartForm(false);
            }

            btnAddPNDetails.Enabled = true;
            btnSavePNDetails.Enabled = btnDeletePNDetails.Enabled = false;
        }

        private void btnDeletePNDetails_Click(object sender, EventArgs e)
        {
            string getPNId = cbbPNId.Text.Trim();
            string getBId = cbbBId.Text.Trim();

            if (pndDAO.Delete(getPNId, getBId))
            {
                RestartForm(false);
                LoadPromissoryNoteList(currentPageOfPNDetails, false);
            }
            else
            {
                RestartForm(false);
            }

            btnDeletePNDetails.Enabled = btnSavePNDetails.Enabled = false;
            btnAddPNDetails.Enabled = true;
        }

        private void btnFirstPagePNDetails_Click(object sender, EventArgs e)
        {
            currentPageOfPNDetails = 1;

            LoadPromissoryNoteList(currentPageOfPNDetails, false);

            SetFalseEnabledForFirstAndPrevBtn(false);
            SetTrueEnabledForLastAndNextBtn(false);
        }

        private void btnPreviousPagePNDetails_Click(object sender, EventArgs e)
        {
            if (currentPageOfPNDetails > 1)
            {
                LoadPromissoryNoteList(--currentPageOfPNDetails, false);
                SetTrueEnabledForLastAndNextBtn(false);
            }

            if (currentPageOfPNDetails == 1)
            {
                SetFalseEnabledForFirstAndPrevBtn(false);
                SetTrueEnabledForLastAndNextBtn(false);
            }
        }

        private void btnNextPagePNDetails_Click(object sender, EventArgs e)
        {
            if (currentPageOfPNDetails < pndDAO.GetPageCountOfPNDetails())
            {
                LoadPromissoryNoteList(++currentPageOfPNDetails, false);
                SetTrueEnabledForFirstAndPrevBtn(false);
            }

            if (currentPageOfPNDetails == pndDAO.GetPageCountOfPNDetails())
            {
                SetTrueEnabledForFirstAndPrevBtn(false);
                SetFalseEnabledForLastAndNextBtn(false);
            }
        }

        private void btnLastPagePNDetails_Click(object sender, EventArgs e)
        {
            currentPageOfPNDetails = pndDAO.GetPageCountOfPNDetails();

            LoadPromissoryNoteList(currentPageOfPNDetails, false);

            SetTrueEnabledForFirstAndPrevBtn(false);
            SetFalseEnabledForLastAndNextBtn(false);
        }

        private void dtpPayDate_ValueChanged(object sender, EventArgs e)
        {
            string getPayDate = dtpPayDate.Value.ToString();
            string getBorrowedDate = dtpBorrowedDate.Value.ToString();

            double getDays = (DateTime.Parse(getPayDate) - DateTime.Parse(getBorrowedDate)).TotalDays;

            // ngày đầu tiên: 5000 VNĐ
            // từ ngày thứ 2 trở đi: 3000 VNĐ/ngày
            if (getDays > 1)
            {
                txtCost.Text = Math.Round((5000 + ((getDays - 1 ) * 3000))).ToString();
            }
            else if (getDays <= 1)
            {
                txtCost.Text = "5000";
            }
            else
            {
                return;
            }
        }

        private void dgvPNDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddPNDetails.Enabled = false;
            btnSavePNDetails.Enabled = btnDeletePNDetails.Enabled = true;

            string getPNId = dgvPNDetails.CurrentRow.Cells["PNId"].Value.ToString();
            string getBId = dgvPNDetails.CurrentRow.Cells["BId"].Value.ToString();

            var getInfo = pndDAO.GetPromissoryNoteDetailById(getPNId, getBId);

            cbbPNId.Text = getInfo.PNId;
            cbbBId.Text = getInfo.BId;
            txtCost.Text = (getInfo.Cost).ToString();
            dtpBorrowedDate.Text = (getInfo.BorrowedDate).ToString();
            dtpPayDate.Text = getInfo.PayDate.ToString("MM/dd/yyyy");
            cbbStatus.Text = getInfo.Status == 0 ? "Đang mượn" : getInfo.Status == 1 ? "Đã trả" : "Trễ hạn";
        }

        #endregion
    }
}
