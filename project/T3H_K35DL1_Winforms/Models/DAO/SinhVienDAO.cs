using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3H_K35DL1_Winforms.Models.EF;

namespace T3H_K35DL1_Winforms.Models.DAO
{
    public class SinhVienDAO : BaseDAO
    {
        public List<SinhVien> GetAll()
        {
            return db_.SinhViens.ToList();
        }
    }
}
