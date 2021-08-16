using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T3H_K34DL1_WebMVC5.Models.EF;

namespace T3H_K34DL1_WebMVC5.Models.DAO
{
    public class KhachHangModel
    {
        private Entities db = new Entities();
        public int GetCount()
        {
            return db.KhachHangs.Count();
        }
    }
}