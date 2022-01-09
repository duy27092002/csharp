using LibraryManageWebsite.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibraryManageWebsite.Models.DAO
{
    public class UserManualDAO : BaseDAO
    {
        // kiểm tra xem có hướng dẫn trong db chưa?
        public bool IsExited()
        {
            var getRecord = db.UserManuals.Count();

            if (getRecord > 0)
            {
                return true;
            }

            return false;
        }

        // tạo hướng dẫn mới
        public async Task<bool> Add(UserManual entity)
        {
            try
            {
                db.UserManuals.Add(entity);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        // hiển thị hướng dẫn
        public async Task<List<UserManual>> GetContent()
        {
            return await db.UserManuals.ToListAsync();
        }

        // lấy chi tiết hướng dẫn sur dụng theo id
        public async Task<UserManual> GetById(int id)
        {
            return await db.UserManuals.FindAsync(id);
        }

        // cập nhật hướng dẫn sau khi sửa
        public async Task<bool> Update(UserManual entity)
        {
            var getUserManual = await GetById(entity.Id);

            if (getUserManual != null)
            {
                getUserManual.UMContent = entity.UMContent;

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}