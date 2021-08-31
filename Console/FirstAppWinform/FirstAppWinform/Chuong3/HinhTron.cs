using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform.Chuong3
{
    public class HinhTron : Hinh
    {
        private const double pi = 3.14;
        private double _r;
        public double R
        {
            get
            {
                return _r;
            }
            set
            {
                _r = value;
            }
        }

        public HinhTron(double r)
        {
            _r = r;
        }

        public override double DienTich()
        {
            return pi * Math.Pow(_r, 2);
        }
    }
}
