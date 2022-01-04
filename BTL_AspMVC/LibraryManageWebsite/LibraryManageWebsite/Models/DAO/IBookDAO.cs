using LibraryManageWebsite.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManageWebsite.Models.DAO
{
    public interface IBookDAO : IBaseDAO<Book, string>, IPagedListDAO<Book>
    {
    }
}