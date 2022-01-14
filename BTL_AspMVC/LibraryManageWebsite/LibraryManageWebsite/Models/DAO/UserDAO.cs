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
    public class UserDAO : BaseDAO, IUserDAO
    {

        // kiểm tra tên đăng nhập là duy nhất
        public bool CheckUsername(string username)
        {
            var getUsername = db.Users.Where(t => t.Username == username && t.Status == 1).FirstOrDefault();

            if (getUsername != null)
            {
                return false;
            }

            return true;
        }

        // kiểm tra số điện thoại là duy nhất
        public bool CheckPhone(string phone)
        {
            var getPhone = db.Users.Where(t => t.Phone == phone && t.Status == 1).FirstOrDefault();

            if (getPhone != null)
            {
                return false;
            }

            return true;
        }

        // kiểm tra email là duy nhất
        public bool CheckEmail(string email)
        {
            var getEmail = db.Users.Where(t => t.Email == email && t.Status == 1).FirstOrDefault();

            if (getEmail != null)
            {
                return false;
            }

            return true;
        }

        // thêm nhân viên mới
        public async Task<bool> Add(User entity)
        {
            try
            {
                db.Users.Add(entity);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        // xóa nhân viên (không dùng method này)
        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        // lấy danh sách nhân viên
        public async Task<List<User>> GetAll()
        {
            return await db.Users.ToListAsync();
        }

        // lấy thông tin nhân viên theo id
        public async Task<User> GetById(string id)
        {
            return await db.Users.FindAsync(id);
        }

        // lấy danh sách nhân viên theo tên
        public async Task<List<User>> GetByKeyword(string keyword, string ownerId)
        {
            return await db.Users.Where(
                t => t.Name.Contains(keyword) &&
                t.OwnerId == ownerId && 
                t.UserType != 3
                ).OrderBy(t => t.Name)
                .ToListAsync();
        }

        // phân trang danh sách nhân viên
        public async Task<IPagedList<User>> GetByPaged(int page, int pageSize, string keyword, string ownerId)
        {
            var getUserListByKeyword = await GetByKeyword(keyword, ownerId);

            return getUserListByKeyword.ToPagedList(page, pageSize);
        }

        // cập nhật thông tin nhân viên sau khi sửa
        public async Task<bool> Update(User entity)
        {
            var getUser = await GetById(entity.Id);

            if (getUser != null)
            {
                getUser.Name = entity.Name;
                getUser.Gender = entity.Gender;
                getUser.Birthday = entity.Birthday;
                getUser.Email = entity.Email;
                getUser.Phone = entity.Phone;
                getUser.Address = entity.Address;
                getUser.Password = entity.Password;
                getUser.UserType = entity.UserType;
                getUser.Status = entity.Status;

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }

        // tìm kiếm admin theo từ khóa và mã khách hàng
        public async Task<List<User>> GetAdminListByKeyword(string keyword, string ownerId)
        {
            return await db.Users.Where(
                t => t.Name.Contains(keyword) &&
                t.OwnerId == ownerId &&
                t.UserType == 0
                ).OrderBy(t => t.Name)
                .ToListAsync();
        }

        // phân trang danh sách nhân viên
        public async Task<IPagedList<User>> GetAdminListByPaged(int page, int pageSize, string keyword, string ownerId)
        {
            var getAdminListByKeyword = await GetAdminListByKeyword(keyword, ownerId);

            return getAdminListByKeyword.ToPagedList(page, pageSize);
        }
    }
}