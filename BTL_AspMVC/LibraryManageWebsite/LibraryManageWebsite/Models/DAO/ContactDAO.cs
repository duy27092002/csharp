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
    public class ContactDAO : BaseDAO, IContactDAO
    {
        // kiểm tra số điện thoại là duy nhất
        public bool CheckPhone(string phone)
        {
            var getPhone = db.Contacts.Where(t => t.AdminPhone == phone && t.Status == 1).FirstOrDefault();

            if (getPhone != null)
            {
                return false;
            }

            return true;
        }

        // kiểm tra email là duy nhất
        public bool CheckEmail(string email)
        {
            var getEmail = db.Contacts.Where(t => t.AdminEmail == email && t.Status == 1).FirstOrDefault();

            if (getEmail != null)
            {
                return false;
            }

            return true;
        }

        // thêm mới liên hệ
        public async Task<bool> Add(Contact entity)
        {
            try
            {
                db.Contacts.Add(entity);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        // xóa liên hệ
        public async Task<bool> Delete(int id)
        {
            var getContact = await GetById(id);

            if (getContact != null)
            {
                db.Contacts.Remove(getContact);

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }

        // lấy toàn bộ danh sách liên hệ
        public Task<List<Contact>> GetAll()
        {
            throw new NotImplementedException();
        }

        // lấy thông tin liên hệ theo id
        public async Task<Contact> GetById(int id)
        {
            return await db.Contacts.FindAsync(id);
        }

        // lấy danh sách liên hệ theo từ khóa
        public async Task<List<Contact>> GetByKeyword(string keyword, string ownerId)
        {
            return await db.Contacts.Where(t => t.AdminName.Contains(keyword) && t.OwnerId == ownerId).OrderBy(t => t.AdminName).ToListAsync();
        }

        // phân trang cho danh sách liên hệ
        public async Task<IPagedList<Contact>> GetByPaged(int page, int pageSize, string keyword, string ownerId)
        {
            var getListByKeyword = await GetByKeyword(keyword, ownerId);

            return getListByKeyword.ToPagedList(page, pageSize);
        }

        // lấy thông tin theo id (trường hợp bổ sung)
        public async Task<Contact> GetById(int? id)
        {
            return await db.Contacts.FindAsync(id);
        }

        // cập nhật thông tin liên hệ khi sửa
        public async Task<bool> Update(Contact entity)
        {
            var getContact = await GetById(entity.Id);

            if (getContact != null)
            {
                getContact.AdminName = entity.AdminName;
                getContact.AdminPhone = entity.AdminPhone;
                getContact.AdminEmail = entity.AdminEmail;
                getContact.Status = entity.Status;

                await db.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}