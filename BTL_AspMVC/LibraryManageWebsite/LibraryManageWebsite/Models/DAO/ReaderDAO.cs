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
        // kiểm tra số điện thoại là duy nhất
        public bool CheckPhone(string phone, string ownerId)
        {
            var getPhone = db.Readers.Where(t => t.Phone == phone && t.OwnerId == ownerId && t.Status == 1).FirstOrDefault();

            if (getPhone != null)
            {
                return false;
            }

            return true;
        }

        // kiểm tra email là duy nhất
        public bool CheckEmail(string email, string ownerId)
        {
            var getEmail = db.Readers.Where(t => t.Email == email && t.OwnerId == ownerId && t.Status == 1).FirstOrDefault();

            if (getEmail != null)
            {
                return false;
            }

            return true;
        }

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
        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
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

        public async Task<List<Reader>> GetReaderList(string ownerId)
        {
            return await db.Readers.Where(t => t.OwnerId == ownerId && t.Status == 1).ToListAsync();
        }

        // phân trang cho danh sách đọc giả
        public async Task<IPagedList<Reader>> GetByPaged(int page, int pageSize, string keyword, string ownerId)
        {
            var getListByKeyword = await GetByKeyword(keyword, ownerId);

            return getListByKeyword.ToPagedList(page, pageSize);
        }

        // lấy mã đọc giả theo số điện thoại
        public async Task<Reader> GetReaderId(string phone, string ownerId)
        {
            return await db.Readers.Where(t => t.Phone == phone && t.OwnerId == ownerId && t.Status == 1).FirstOrDefaultAsync();
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