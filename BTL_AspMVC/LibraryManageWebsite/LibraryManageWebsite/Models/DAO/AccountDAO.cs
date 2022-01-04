using LibraryManageWebsite.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace LibraryManageWebsite.Models.DAO
{
    public class AccountDAO : BaseDAO
    {
        // lấy thông tin nhân viên sau khi đăng nhập thành công
        // cung cấp id cho session
        public User GetUser(User entity)
        {
            var getUser = db.Users.Where(
                t => t.Username == entity.Username &&
                t.Password == entity.Password &&
                t.Email == entity.Email &&
                t.OwnerId == entity.OwnerId
                );

            return getUser.FirstOrDefault();
        }

        // kiểm tra đăng nhập của nhân viên, admin thuộc đơn vị chủ quản, chủ sở hữu nào đó
        public bool CheckLogin(User entity)
        {
            var getUser = db.Users.Where(
                t => t.Username == entity.Username &&
                t.Email == entity.Email &&
                t.Password == entity.Password &&
                t.OwnerId == entity.OwnerId &&
                t.Status == 1).FirstOrDefault();

            if (getUser != null)
            {
                return true;
            }

            return false;
        }

        // kiểm tra đăng nhập của developer
        public bool IsDeveloper(User entity)
        {
            var getDeveloper = db.Users.Where(
                t => t.Username == entity.Username &&
                t.Email == entity.Email &&
                t.Password == entity.Password &&
                t.Status == 1).FirstOrDefault();

            if (getDeveloper != null)
            {
                return true;
            }

            return false;
        }

        // lấy thông tin của developer
        public User GetInfoOfDev(User entity)
        {
            var getDeveloper = db.Users.Where(
                t => t.Username == entity.Username &&
                t.Password == entity.Password &&
                t.Email == entity.Email
                );

            return getDeveloper.FirstOrDefault();
        }

        // kiểm tra mã xác minh
        public bool CheckOwnerId(string ownerId)
        {
            var getOwnerId = db.Owners.Where(t => t.Id == ownerId && t.Status == 1);

            if (getOwnerId != null)
            {
                return true;
            }

            return false;
        }

        // đăng ký nhân viên mới
        public bool AddNewUser(User entity)
        {
            try
            {
                db.Users.Add(entity);

                db.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

    }
}