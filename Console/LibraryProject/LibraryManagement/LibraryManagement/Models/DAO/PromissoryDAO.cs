using LibraryManagement.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Models.DAO
{
    class PromissoryDAO : BaseDAO 
    {
        #region thao tác xử lý cho phần tạo phiếu mượn-trả

        // lấy danh sách mã đọc giả để hiển thị ra combobox
        public List<Reader> GetRIdList()
        {
            return db.Readers.Where(t => t.RStatus == 1).ToList();
        }

        private bool CheckNullOfReaderId(string readerId)
        {
            if (readerId.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private Reader GetSingleByReaderId(string readerId)
        {
            return db.Readers.Where(t => t.RId == readerId && t.RStatus == 1).FirstOrDefault();
        }

        public bool AddNewPromissoryNote(string readerId, string empId, string promissoryNoteId)
        {
            if (CheckNullOfReaderId(readerId))
            {
                if (GetSingleByReaderId(readerId) != null)
                {
                    PromissoryNote data = new PromissoryNote()
                    {
                        PNId = promissoryNoteId,
                        RId = readerId,
                        UId = empId
                    };

                    try
                    {
                        db.PromissoryNotes.Add(data);
                        db.SaveChanges();

                        MessageBox.Show("Tạo lập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã đọc giả này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }

        public int GetPageCountOfPromissoryNotes()
        {
            int getCountOfRecord = db.PromissoryNotes.Count();
            int getPageCount = (getCountOfRecord % 2) == 0 ? (getCountOfRecord / 2) : (getCountOfRecord / 2) + 1;
            return getPageCount;
        }

        public List<PromissoryNote> GetPromissoryNoteListByPage(int pageNubmer)
        {
            // trả về 2 khách hàng mỗi trang
            return db.PromissoryNotes.OrderByDescending(t => t.PNId).Skip((pageNubmer - 1) * 2).Take(2).ToList();
        }

        public PromissoryNote GetPNByPNId(string pNId)
        {
            return db.PromissoryNotes.Where(t => t.PNId == pNId).FirstOrDefault();
        }

        public bool SavePromissoryNote(string readerId, string empId, string promissoryNoteId)
        {
            if (CheckNullOfReaderId(readerId))
            {
                if (GetSingleByReaderId(readerId) != null)
                {
                    var getPN = GetPNByPNId(promissoryNoteId);

                    getPN.RId = readerId;
                    getPN.UId = empId;
                    getPN.PNId = promissoryNoteId;

                    try
                    {
                        db.SaveChanges();

                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã đọc giả này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }

        public bool DeletePromissoryNote(string promissoryNoteId)
        {
            var getPN = GetPNByPNId(promissoryNoteId);

            db.PromissoryNotes.Remove(getPN);

            try
            {
                db.SaveChanges();

                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion
    }
}
