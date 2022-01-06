using LibraryManageWebsite.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibraryManageWebsite.Models.DAO
{
    public class RegulationDAO : BaseDAO
    {
        // thêm nội dung quy định mới
        public async Task<bool> Add(Regulation entity)
        {
            try
            {
                db.Regulations.Add(entity);

                await db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        // hiển thị quy định
        public async Task<List<Regulation>> GetContent(string ownerId)
        {
            return await db.Regulations.Where(t => t.OwnerId == ownerId).ToListAsync();
        }

        // lấy chi tiết quy định theo id
        public async Task<Regulation> GetById(int id)
        {
            return await db.Regulations.FindAsync(id);
        }

        // cập nhật quy định sau khi sửa
        public async Task<bool> Update(Regulation entity)
        {
            var getRegulation = await GetById(entity.Id);

            if (getRegulation != null)
            {
                getRegulation.RegulationsContent = entity.RegulationsContent;

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }

        // lấy chi tiết quy định theo id (trường hợp bổ sung)
        public async Task<Regulation> GetById(int? id)
        {
            return await db.Regulations.FindAsync(id);
        }
    }
}