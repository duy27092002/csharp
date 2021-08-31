using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform.Chuong3
{
    public class HinhVuong : HinhChuNhat
    {
        // cách 1
        //public HinhVuong (double canh) : base(canh, canh) { }

        // cách 2
        public HinhVuong(double canh)
        {
            ChieuDai = ChieuRong = canh;
        }
}
}
