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
        // kiểm tra trạng thái kích hoạt của khách hàng trước khi login
        public bool CheckActiveStatus(string ownerId)
        {
            var getStatus = db.Owners.Where(t => t.Id == ownerId && t.Status == 1).FirstOrDefault();

            if (getStatus != null)
            {
                return true;
            }

            return false;
        }

        // kiểm tra số điện thoại là duy nhất
        public bool CheckPhone(string phone)
        {
            var getPhone = db.Owners.Where(t => t.Phone == phone && t.Status == 1).FirstOrDefault();

            if (getPhone != null)
            {
                return false;
            }

            return true;
        }

        // kiểm tra email là duy nhất
        public bool CheckEmail(string email)
        {
            var getEmail = db.Owners.Where(t => t.Email == email && t.Status == 1).FirstOrDefault();

            if (getEmail != null)
            {
                return false;
            }

            return true;
        }

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

        // lấy thông tin khách hàng còn kích hoạt
        public Owner GetOwner(string ownerId)
        {
            return db.Owners.Where(t => t.Id == ownerId && t.Status == 1).FirstOrDefault();
        }

        // lấy thông tin khách hàng có trong db (kể cả đã hủy kích hoạt)
        public async Task<Owner> GetOwnerId(string ownerId)
        {
            return await db.Owners.Where(t => t.Id == ownerId).FirstOrDefaultAsync();
        }

        // cập nhật trạng thái kích hoạt
        public async Task<bool> UpdateStatus(string ownerId)
        {
            var getOwner = await GetById(ownerId);

            if (getOwner != null)
            {
                if (getOwner.Status == 0)
                {
                    getOwner.Status = 1;
                }
                else if (getOwner.Status == 1)
                {
                    getOwner.Status = 0;
                }

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}