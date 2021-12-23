using LibraryManagement.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Models.DAO
{
    class PromissoryNoteDetailsDAO : BaseDAO
    {
        #region Thao tác xử lý thêm chi tiết phiểu

        public int GetPageCountOfPNDetails()
        {
            int getCountOfRecord = db.PromissoryNoteDetails.Count();
            int getPageCount = (getCountOfRecord % 2) == 0 ? (getCountOfRecord / 2) : (getCountOfRecord / 2) + 1;
            return getPageCount;
        }

        public List<PromissoryNoteDetail> GetPNDetailsListByPage(int pageNubmer)
        {
            // trả về 2 khách hàng mỗi trang
            return db.PromissoryNoteDetails.OrderByDescending(t => t.PNId).Skip((pageNubmer - 1) * 2).Take(2).ToList();
        }

        public List<PromissoryNote> GetPNIdList()
        {
            return db.PromissoryNotes.ToList();
        }

        public List<Book> GetBIdList()
        {
            return db.Books.ToList();
        }

        private bool CheckInput(string pNId, string bId, string borrowedDate, string payDate, string status)
        {
            if (pNId.Length == 0 || bId.Length == 0 || status.Length == 0 || status == null)
            {
                MessageBox.Show("Không được để trống dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if ((DateTime.Parse(borrowedDate) - DateTime.Parse(payDate)).TotalDays > 0)
                {
                    MessageBox.Show("Ngày trả đã là thời gian trong quá khứ. Vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private Book GetBookByBId(string bId)
        {
            return db.Books.Where(t => t.BId == bId).FirstOrDefault();
        }

        private PromissoryNote GetPNByPNId(string pNId)
        {
            return db.PromissoryNotes.Where(t => t.PNId == pNId).FirstOrDefault();
        } 

        public bool Add(string pNId, string bId, string borrowedDate, string payDate, string cost, string status)
        {
            if (CheckInput(pNId, bId, borrowedDate, payDate, status))
            {
                string getStatus = status == "Đang mượn" ? "0" :
                    status == "Đã trả" ? "1" :
                    status == "Trễ hạn" ? "2" : null;

                if (GetPNByPNId(pNId) == null)
                {
                    MessageBox.Show("Không tìm thấy mã phiếu này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (GetBookByBId(bId) == null)
                {
                    MessageBox.Show("Không tìm thấy mã sách này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    PromissoryNoteDetail data = new PromissoryNoteDetail()
                    {
                        PNId = pNId,
                        BId = bId,
                        BorrowedDate = DateTime.Parse(borrowedDate),
                        PayDate = DateTime.Parse(payDate),
                        Cost = double.Parse(cost),
                        Status = byte.Parse(getStatus)
                    };

                    try
                    {
                        db.PromissoryNoteDetails.Add(data);
                        db.SaveChanges();

                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return false;
        }

        public PromissoryNoteDetail GetPromissoryNoteDetailById(string pNId, string bId)
        {
            return db.PromissoryNoteDetails.Where(t => t.PNId == pNId && t.BId == bId).FirstOrDefault();
        }

        public bool Save(string pNId, string bId, string borrowedDate, string payDate, string cost, string status)
        {
            if (CheckInput(pNId, bId, borrowedDate, payDate, status))
            {
                string getStatus = status == "Đang mượn" ? "0" :
                    status == "Đã trả" ? "1" :
                    status == "Trễ hạn" ? "2" : null;

                if (GetPNByPNId(pNId) == null)
                {
                    MessageBox.Show("Không tìm thấy mã phiếu này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (GetBookByBId(bId) == null)
                {
                    MessageBox.Show("Không tìm thấy mã sách này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    var getInfo = GetPromissoryNoteDetailById(pNId, bId);

                    getInfo.PNId = pNId;
                    getInfo.BId = bId;
                    getInfo.PayDate = DateTime.Parse(payDate);
                    getInfo.Cost = double.Parse(cost);
                    getInfo.Status = byte.Parse(getStatus);

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
            }

            return false;
        }

        public bool Delete(string pNId, string bId)
        {
            var getPND = GetPromissoryNoteDetailById(pNId, bId);

            db.PromissoryNoteDetails.Remove(getPND);

            try
            {
                db.SaveChanges();

                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion
    }
}
