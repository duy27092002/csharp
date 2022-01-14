using LibraryManageWebsite.Models.EF;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            throw new NotImplementedException();
        }

        public async Task<List<PromissoryNote>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PromissoryNote> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PromissoryNote>> GetByKeyword(string keyword, string ownerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IPagedList<PromissoryNote>> GetByPaged(int page, int pageSize, string keyword, string ownerId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(PromissoryNote entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Reader>> GetReaderList(string ownerId)
        {
            return await db.Readers.Where(t => t.OwnerId == ownerId && t.Status == 1).ToListAsync();
        }

        public async Task<List<Book>> GetBookList(string ownerId)
        {
            return await db.Books.Where(t => t.OwnerId == ownerId && t.Status == 1).ToListAsync();
        }

        public async Task<Reader> GetReaderId(string phone, string ownerId)
        {
            return await db.Readers.Where(t => t.Phone == phone && t.OwnerId == ownerId && t.Status == 1).FirstOrDefaultAsync();
        }

        public async Task<Book> GetBookId(string bookName, string bookAuthor, string ownerId)
        {
            return await db.Books.Where(
                t => t.Name == bookName &&
                t.Author == bookAuthor &&
                t.OwnerId == ownerId &&
                t.Status == 1
                ).FirstOrDefaultAsync();
        }
    }
}