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
    public class ReaderDAO : BaseDAO, IReaderDAO
    {
        // thêm đọc giả mới
        public async Task<bool> Add(Reader entity)
        {
            try
            {
                db.Readers.Add(entity);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        // xóa đọc giả
        public async Task<bool> Delete(string id)
        {
            var getReader = await GetById(id);

            if (getReader != null)
            {
                db.Readers.Remove(getReader);

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }

        // lấy toàn bộ danh sách đọc giả
        public Task<List<Reader>> GetAll()
        {
            throw new NotImplementedException();
        }

        // lấy thông tin đọc giả theo id
        public async Task<Reader> GetById(string id)
        {
            return await db.Readers.FindAsync(id);
        }

        // lấy danh sách đọc giả được tìm thoe tên
        public async Task<List<Reader>> GetByKeyword(string keyword, string ownerId)
        {
            return await db.Readers.Where(t => t.Name.Contains(keyword) && t.OwnerId == ownerId).OrderBy(t => t.Name).ToListAsync();
        }

        // phân trang cho danh sách đọc giả
        public async Task<IPagedList<Reader>> GetByPaged(int page, int pageSize, string keyword, string ownerId)
        {
            var getListByKeyword = await GetByKeyword(keyword, ownerId);

            return getListByKeyword.ToPagedList(page, pageSize);
        }

        // cập nhật thông tin đọc giả sau khi sửa
        public async Task<bool> Update(Reader entity)
        {
            var getReader = await GetById(entity.Id);

            if (getReader != null)
            {
                getReader.Name = entity.Name;
                getReader.Gender = entity.Gender;
                getReader.Birthday = entity.Birthday;
                getReader.Email = entity.Email;
                getReader.Phone = entity.Phone;
                getReader.Address = entity.Address;
                getReader.Status = entity.Status;

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}