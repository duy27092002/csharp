using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform.Chuong3
{
    public class HD : Nguoi
    {
        protected double _tienCongLD;
        protected byte _soNgayLVTrongThang;
        protected int _heSoVuotGio;

        public double TienCongLD
        {
            get
            {
                return _tienCongLD;
            }
            set
            {
                _tienCongLD = value;
            }
        }

        public byte SoNgayLVTrongThang
        {
            get
            {
                return _soNgayLVTrongThang;
            }
            set
            {
                _soNgayLVTrongThang = value;
            }
        }

        public int HeSoVuotGio
        {
            get
            {
                return _heSoVuotGio;
            }
            set
            {
                _heSoVuotGio = value;
            }
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập số tiền công lao động: ");
            _tienCongLD = double.Parse(Console.ReadLine());
            Console.Write("Nhấp tổng số ngày làm việc trong tháng: ");
            _soNgayLVTrongThang = byte.Parse(Console.ReadLine());
            Console.Write("Nhấp hệ số vượt giờ: ");
            _heSoVuotGio = int.Parse(Console.ReadLine());
        }

        public override double TinhLuong()
        {
            //tiền công * 8 * ngày làm việc + tiền công * hệ số vượt giờ
            var luong = _tienCongLD * 8 * _soNgayLVTrongThang + _tienCongLD * _heSoVuotGio;
            return luong;
        }
    }
}
