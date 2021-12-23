using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models.EF;

namespace WindowsFormsApp1.Models.DAO
{
    class BaseDAO
    {
        protected DB_NewWinFormEntities db;

        public BaseDAO()
        {
            db = new DB_NewWinFormEntities();
        }
    }
}
