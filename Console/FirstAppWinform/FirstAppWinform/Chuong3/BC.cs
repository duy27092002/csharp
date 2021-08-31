using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform.Chuong3
{
    public class BC : Nguoi
    {
        protected double _heSoLuong;
        protected double _phuCap;

        public double HeSoLuong
        {
            get
            {
                return _heSoLuong;
            }
            set
            {
                _heSoLuong = value;
            }
        }
        public double PhuCap
        {
            get
            {
                return _phuCap;
            }
            set
            {
                _phuCap = value;
            }
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập hệ số lương: ");
            _heSoLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhập phụ cấp: ");
            _phuCap = double.Parse(Console.ReadLine());
            Console.Write("Nhập lương: ");
            Luong = double.Parse(Console.ReadLine());
        }

        public override double TinhLuong()
        {
            return Luong * _heSoLuong + _phuCap;
        }
    }
}
