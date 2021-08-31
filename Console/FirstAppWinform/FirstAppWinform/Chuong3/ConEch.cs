using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform.Chuong3
{
    public class ConEch : IDongVatDuoiNuoc, IDongVatTrenCan
    {
        public void Boi()
        {
            Console.WriteLine("Con Ếch đang bơi");
        }

        public void Di()
        {
            Console.WriteLine("Con Ếch đang đi");
        }

        public void Lan()
        {
            Console.WriteLine("Con Ếch đang lặn");
        }

        public void Nhay()
        {
            Console.WriteLine("Con Ếch đang nhảy");
        }
    }
}
