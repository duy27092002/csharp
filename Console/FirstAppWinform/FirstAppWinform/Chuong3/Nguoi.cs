using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform.Chuong3
{
    public class Nguoi
    {
        protected string _ten;
        protected int _maSo;
        protected double _luong;

        public string Ten
        {
            get
            {
                return _ten;
            }
            set
            {
                _ten = value;
            }
        }
        public int MaSo
        {
            get
            {
                return _maSo;
            }
            set
            {
                _maSo = value;
            }
        }
        public double Luong
        {
            get
            {
                return _luong;
            }
            set
            {
                _luong = value;
            }
        }

        public virtual void Nhap()
        {
            Console.Write("Nhập tên: ");
            _ten = Console.ReadLine();
            Console.Write("Nhập mã số: ");
            _maSo = Convert.ToInt32(Console.ReadLine());
        }

        public virtual double TinhLuong()
        {
            return TinhLuong();
        }

        public void Xuat()
        {
            Console.WriteLine("Tên: {0}", _ten);
            Console.WriteLine("Mã số: {0}", _maSo);
            Console.WriteLine("Lương: {0}", TinhLuong());
        }
    }
}
