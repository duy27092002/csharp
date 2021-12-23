using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSales.Models.EF;

namespace WebSales.Models.DAO
{
    public class BaseDAO
    {
        protected T3H_K34DL1_DemoEntities _context;
        public BaseDAO()
        {
            _context = new T3H_K34DL1_DemoEntities();
        }
    }
}