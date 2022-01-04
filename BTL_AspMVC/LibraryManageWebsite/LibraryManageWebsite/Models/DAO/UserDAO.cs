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

        // xóa nhân viên
        public async Task<bool> Delete(string id)
        {
            var getUser = await GetById(id);

            if (getUser != null)
            {
                db.Users.Remove(getUser);

                await db.SaveChangesAsync();

                return true;
            }

            return false;
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
        public async Task<List<User>> GetByKeyword(string keyword)
        {
            return await db.Users.Where(t => t.Name.Contains(keyword)).OrderBy(t => t.Name).ToListAsync();
        }

        // phân trang danh sách nhân viên
        public async Task<IPagedList<User>> GetByPaged(int page, int pageSize, string keyword)
        {
            var getUserListByKeyword = await GetByKeyword(keyword);

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
                getUser.Username = entity.Username;
                getUser.Password = entity.Password;
                getUser.UserType = entity.UserType;
                getUser.Status = entity.Status;

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}