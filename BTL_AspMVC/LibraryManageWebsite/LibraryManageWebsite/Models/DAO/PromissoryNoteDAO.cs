using LibraryManageWebsite.Models.EF;
using Newtonsoft.Json;
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
    public class PromissoryNoteDAO : BaseDAO, IPromissoryNoteDAO
    {
        public async Task<bool> Add(PromissoryNote entity)
        {
            try
            {
                db.PromissoryNotes.Add(entity);

                await db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(string id)
        {
            var getPN = await GetById(id);

            if (getPN != null)
            {
                db.PromissoryNotes.Remove(getPN);

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public Task<List<PromissoryNote>> GetAll()
        {
            throw new NotImplementedException();
        }

        // lấy danh sách phiếu theo ownerId và trạng thái phiếu
        public async Task<List<PromissoryNote>> GetAllByStatus(string ownerId, int status)
        {
            return await db.PromissoryNotes.Where(t => t.OwnerId == ownerId && t.Status == status).ToListAsync();
        }


        public async Task<PromissoryNote> GetById(string id)
        {
            return await db.PromissoryNotes.FindAsync(id);
        }

        // lấy danh sách phiếu chưa được trả (status != 1) theo tên sách
        public async Task<List<PromissoryNote>> GetByKeyword(string keyword, string ownerId)
        {
            return await db.PromissoryNotes.Where(
                t => t.Reader.Name.Contains(keyword) && 
                t.OwnerId == ownerId && 
                t.Status != 1
                ).OrderBy(t => t.Reader.Name).ToListAsync();
        }

        // phân trang cho danh sách chứa những phiếu chưa được trả
        public async Task<IPagedList<PromissoryNote>> GetByPaged(int page, int pageSize, string keyword, string ownerId)
        {
            var getListByKeyword = await GetByKeyword(keyword, ownerId);

            return getListByKeyword.ToPagedList(page, pageSize);
        }

        public async Task<bool> Update(PromissoryNote entity)
        {
            var getPN = await GetById(entity.Id);

            if (getPN != null)
            {
                getPN.ReaderId = entity.ReaderId;
                getPN.BookId = entity.BookId;
                getPN.ExpiryDate = entity.ExpiryDate;
                getPN.Cost = entity.Cost;
                getPN.Status = entity.Status;

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }

        // chuyển trạng thái khi trả sách
        public async Task<bool> UpdateStatus(string id)
        {
            var getPN = await GetById(id);

            if (getPN != null)
            {
                getPN.Status = 1;

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }

        // lấy danh sách phiếu đã được trả (status == 1) theo tên sách
        public async Task<List<PromissoryNote>> GetByKeywordByReturnedBookList(string keyword, string ownerId)
        {
            return await db.PromissoryNotes.Where(
                t => t.Reader.Name.Contains(keyword) &&
                t.OwnerId == ownerId &&
                t.Status == 1
                ).OrderBy(t => t.Reader.Name).ToListAsync();
        }

        // phân trang cho danh sách chứa những phiếu đã được trả
        public async Task<IPagedList<PromissoryNote>> GetByPagedForReturnedBookList(int page, int pageSize, string keyword, string ownerId)
        {
            var getListByKeyword = await GetByKeywordByReturnedBookList(keyword, ownerId);

            return getListByKeyword.ToPagedList(page, pageSize);
        }
    }
}