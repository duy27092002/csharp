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
    public class OwnerDAO : BaseDAO, IOwnerDAO
    {
        // thêm người mua website mới
        public async Task<bool> Add(Owner entity)
        {
            try
            {
                db.Owners.Add(entity);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        // xóa người mua website
        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Owner>> GetAll()
        {
            throw new NotImplementedException();
        }

        // lấy thông tin người mua
        public async Task<Owner> GetById(string id)
        {
            return await db.Owners.FindAsync(id);
        }

        // lấy danh sách người mua theo tên
        public async Task<List<Owner>> GetByKeyword(string keyword)
        {
            return await db.Owners.Where(t => t.Name.Contains(keyword)).OrderBy(t => t.Name).ToListAsync();
        }

        // không dùng method này
        public Task<List<Owner>> GetByKeyword(string keyword, string ownerId)
        {
            throw new NotImplementedException();
        }

        // phân trang cho danh sách
        public async Task<IPagedList<Owner>> GetByPaged(int page, int pageSize, string keyword)
        {
            var getListByKeyword = await GetByKeyword(keyword);

            return getListByKeyword.ToPagedList(page, pageSize);
        }

        // không dùng method này
        public Task<IPagedList<Owner>> GetByPaged(int page, int pageSize, string keyword, string ownerId)
        {
            throw new NotImplementedException();
        }

        // cập nhật thông tin sau khi sửa
        public async Task<bool> Update(Owner entity)
        {
            var getOwner = await GetById(entity.Id);

            if (getOwner != null)
            {
                getOwner.Name = entity.Name;
                getOwner.Email = entity.Email;
                getOwner.Phone = entity.Phone;
                getOwner.Username = entity.Username;
                getOwner.Password = entity.Password;
                getOwner.Status = entity.Status;

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}