using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T3H_K34DL1_WebMVC5.Models.DAO
{
    public class BaseDAO
    {
        protected Models.EF.Entities db_;
        public BaseDAO()
        {
            db_ = new EF.Entities();
        }
    }
}