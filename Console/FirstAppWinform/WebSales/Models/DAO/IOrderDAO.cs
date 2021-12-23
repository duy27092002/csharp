using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSales.Models.EF;

namespace WebSales.Models.DAO
{
    public interface IOrderDAO : IBaseDAO<Order, int>, IPagedListDAO<Order>
    {
    }
}