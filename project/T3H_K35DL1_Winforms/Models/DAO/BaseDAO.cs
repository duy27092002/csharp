using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3H_K35DL1_Winforms.Models.DAO
{
    public class BaseDAO
    {
        protected Models.EF.QuanLiSinhVienEntities db_;
        public BaseDAO()
        {
            db_ = new EF.QuanLiSinhVienEntities();
        }
    }
}
