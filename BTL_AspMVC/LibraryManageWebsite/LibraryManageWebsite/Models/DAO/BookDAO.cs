using LibraryManageWebsite.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibraryManageWebsite.Models.DAO
{
    public class BookDAO : BaseDAO, IBookDAO
    {
        // kiểm tra sự trùng lặp của sách
        public bool IsExited(string bookName, string author, string ownerId)
        {
            var getBook = db.Books.Where(t => t.Name == bookName && t.Author == author && t.OwnerId == ownerId).FirstOrDefault();

            if (getBook != null)
            {
                return false;
            }

            return true;
        }

        // thêm sách mới
        public async Task<bool> Add(Book entity)
        {
            try
            {
                db.Books.Add(entity);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        // xóa sách
        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        // lấy toàn bộ sách
        public Task<List<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        // lấy thông tin sách theo id
        public async Task<Book> GetById(string id)
        {
            return await db.Books.FindAsync(id);
        }

        // lấy id của những cuốn sách có số lượng > 0
        public async Task<Book> GetBookId(string bookName, string bookAuthor, string ownerId)
        {
            return await db.Books.Where(
                t => t.Name == bookName &&
                t.Author == bookAuthor &&
                t.OwnerId == ownerId &&
                t.Status == 1
                ).FirstOrDefaultAsync();
        }

        // lấy tất cả id sách kể cả đã hết
        public async Task<Book> GetAllBookId(string bookName, string bookAuthor, string ownerId)
        {
            return await db.Books.Where(
                t => t.Name == bookName &&
                t.Author == bookAuthor &&
                t.OwnerId == ownerId
                ).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> GetBookList(string ownerId)
        {
            return await db.Books.Where(t => t.OwnerId == ownerId && t.Status == 1).ToListAsync();
        }

        // lấy danh sách theo tên
        public async Task<List<Book>> GetByKeyword(string keyword, string ownerId)
        {
            return await db.Books.Where(t => t.Name.Contains(keyword) && t.OwnerId == ownerId).OrderBy(t => t.Name).ToListAsync();
        }

        // phân trang cho danh sách
        public async Task<IPagedList<Book>> GetByPaged(int page, int pageSize, string keyword, string ownerId)
        {
            var getListByKeyword = await GetByKeyword(keyword, ownerId);

            return getListByKeyword.ToPagedList(page, pageSize);
        }

        // cập nhật thông tin sau khi sửa sách
        public async Task<bool> Update(Book entity)
        {
            var getBook = await GetById(entity.Id);

            if (getBook != null)
            {
                getBook.Name = entity.Name;
                getBook.Author = entity.Author;
                getBook.Publisher = entity.Publisher;
                getBook.Price = entity.Price;
                getBook.Quantity = entity.Quantity;
                getBook.Year = entity.Year;
                getBook.Status = entity.Status;

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }

        // cập nhật số lượng và lượt mượn sách sau khi thêm or sửa phiếu mượn-trả
        public async Task<bool> UpdateQuantityAndViews(string bookId, byte type)
        {
            var getBook = await GetById(bookId);

            if (getBook != null)
            {
                if (type == 0) // nếu mượn sách
                {
                    getBook.Quantity -= 1;
                    getBook.Views += 1;
                }
                else if (type == 1) // nếu trả sách
                {
                    getBook.Quantity += 1;
                }

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }

        // cập nhật trạng thái khi sách đã hết
        public async Task<bool> UpdateStatus(string bookId)
        {
            var getBook = await GetById(bookId);

            if (getBook != null)
            {
                if (getBook.Quantity > 0)
                {
                    getBook.Status = 1;
                }
                else if (getBook.Quantity == 0)
                {
                    getBook.Status = 0;
                }

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}