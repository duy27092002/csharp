using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebSales.Models.EF;

namespace WebSales.Models.DAO
{
    public interface ICustomerDAO : IBaseDAO<Customer, int>, IPagedListDAO<Customer>
    {
        //Task<Customer> GetSingleByID(string id);
    }
}