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
        public async Task<bool> Delete(string id)
        {
            var getBook = await GetById(id);

            if (getBook != null)
            {
                db.Books.Remove(getBook);

                await db.SaveChangesAsync();

                return true;
            }

            return false;
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
    }
}