using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform.Chuong3
{
    public class HinhChuNhat : Hinh
    {
        protected double _chieuDai;
        protected double _chieuRong;
        public double ChieuDai
        {
            get
            {
                return _chieuDai;
            }
            set
            {
                _chieuDai = value;
            }
        }
        public double ChieuRong
        {
            get
            {
                return _chieuRong;
            }
            set
            {
                _chieuRong = value;
            }
        }

        public HinhChuNhat()
        {
            _chieuDai = _chieuRong = 0;
        }
        public HinhChuNhat(double cDai, double cRong)
        {
            _chieuDai = cDai;
            _chieuRong = cRong;
        }
        public override double DienTich()
        {
            return _chieuDai * _chieuRong;
        }
    }
}
