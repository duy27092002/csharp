using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models.EF;

namespace WindowsFormsApp1.Models.DAO
{
    class RegistrationDAO : BaseDAO
    {
        public bool AddNewUser(Registereduser data)
        {
            try
            {
                db.Registeredusers.Add(data);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
