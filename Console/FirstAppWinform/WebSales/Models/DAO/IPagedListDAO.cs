using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebSales.Models.DAO
{
    public interface IPagedListDAO<T>
    {
        Task<IPagedList<T>> GetByPaged(int page, int pageSize, string keyword);
    }
}