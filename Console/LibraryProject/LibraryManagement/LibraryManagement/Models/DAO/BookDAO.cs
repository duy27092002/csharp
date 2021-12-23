using LibraryManagement.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Models.DAO
{
    class BookDAO : BaseDAO 
    {
        private bool CheckInput(string BName, string BAuthor, string BPublisher, string BPrice, string BQuantity, string time, string year)
        {
            Regex checkNumber = new Regex(@"^[+]?\d+$");

            if (BName.Length == 0 || BAuthor.Length == 0 || BPublisher.Length == 0 || BPrice.Length == 0 || 
                BQuantity.Length == 0 || time.Length == 0 || year.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (!checkNumber.IsMatch(BPrice) || !checkNumber.IsMatch(BQuantity) || !checkNumber.IsMatch(year))
                {
                    MessageBox.Show("Sai định dạng giá hoặc số lượng hoặc năm phát hành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } 
            }

            return true;
        }

        public bool Add(string BId, string BName, string BAuthor, string BPublisher, string BPrice, string BQuantity, string time, string year)
        {
            if (CheckInput(BName, BAuthor, BPublisher, BPrice, BQuantity, time, year))
            {
                Book data = new Book()
                {
                    BId = BId,
                    BName = BName,
                    BAuthor = BAuthor,
                    BPublisher = BPublisher,
                    BPrice = int.Parse(BPrice),
                    BQuantity = int.Parse(BQuantity),
                    BInportTime = DateTime.Parse(time),
                    BYear = int.Parse(year)
                };

                try
                {
                    db.Books.Add(data);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }

        public int GetPageCount()
        {
            int getCountOfRecord = db.Books.Count();
            int getPageCount = (getCountOfRecord % 2) == 0 ? (getCountOfRecord / 2) : (getCountOfRecord / 2) + 1;
            return getPageCount;
        }

        public List<Book> GetListByPage(int pageNubmer)
        {
            // trả về 2 khách hàng mỗi trang
            return db.Books.OrderByDescending(t => t.BId).Skip((pageNubmer - 1) * 2).Take(2).ToList();
        }

        public Book GetSingleById(string id)
        {
            return db.Books.Where(t => t.BId == id).FirstOrDefault();
        }

        public bool Save(string BId, string BName, string BAuthor, string BPublisher, string BPrice, string BQuantity, string time, string year)
        {
            if (CheckInput(BName, BAuthor, BPublisher, BPrice, BQuantity, time, year))
            {
                var getBookById = GetSingleById(BId);

                getBookById.BName = BName;
                getBookById.BAuthor = BAuthor;
                getBookById.BPublisher = BPublisher;
                getBookById.BPrice = int.Parse(BPrice);
                getBookById.BQuantity = int.Parse(BQuantity);
                getBookById.BInportTime = DateTime.Parse(time);
                getBookById.BYear = int.Parse(year);

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

            return false;
        }

        public bool Delete(string BId)
        {
            var getBookById = GetSingleById(BId);

            try
            {
                db.Books.Remove(getBookById);
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
    }
}
