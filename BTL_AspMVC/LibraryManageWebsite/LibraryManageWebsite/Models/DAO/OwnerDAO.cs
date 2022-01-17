using LibraryManageWebsite.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
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

        // kiểm tra định dạng thời gian trước khi cập nhật thông tin
        public bool CheckFormatDate(string registrationTime, string expireTime)
        {
            Regex formatDate = new Regex(@"^([0]?[0-9]|[1][0-2])\/([0]?[0-9]|[1|2][0-9]|[3][0-1])\/([0-9]{4})$");

            if (formatDate.IsMatch(registrationTime) && formatDate.IsMatch(expireTime))
            {
                return true;
            }

            return false;
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

        // tìm kiếm admin theo mã khách hàng và từ khóa nhập liệu
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

        // load danh sách admin theo mã khách hàng
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
                getOwner.RegistrationTime = entity.RegistrationTime;
                getOwner.ExpireTime = entity.ExpireTime;
                getOwner.Status = entity.Status;

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public Owner GetOwner(string ownerId)
        {
            return db.Owners.Where(t => t.Id == ownerId && t.Status == 1).FirstOrDefault();
        }
    }
}