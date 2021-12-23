using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSales.Models.EF;

namespace WebSales.Models.DAO
{
    public interface ICategoryDAO : IBaseDAO<Category, int>, IPagedListDAO<Category>
    {
    }
}