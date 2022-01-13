using LibraryManageWebsite.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManageWebsite.Models.DAO
{
    public class BaseDAO
    {
        protected DB_LibraryManagerEntities db;

        public BaseDAO()
        {
            db = new DB_LibraryManagerEntities();
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}