using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T3H_K34DL1_WebMVC5.Models.DAO
{
    public class HomeDAO : BaseDAO
    {
        public int GetTongSoDonXuat(DateTime startDate, DateTime endDate)
        {
            int value = 0;

            value = db_.HoaDonXuats.Where(t => t.NgayXuat >= startDate && t.NgayXuat <= endDate).Count();

            return value;
        }

        public int GetTongSoDonNhap(DateTime startDate, DateTime endDate)
        {
            int value = 0;

            value = db_.HoaDonNhaps.Where(t => t.NgayNhap >= startDate && t.NgayNhap <= endDate).Count();

            return value;
        }

        public decimal GetDoanhThu (DateTime startDate, DateTime endDate)
        {
            decimal value = 0;

            var models = db_.HoaDonXuats.Where(t => t.NgayXuat >= startDate && t.NgayXuat <= endDate).ToArray();

            if (models.Length > 0)
            {
                value = models.Select(t => (decimal)t.TongTien)
                        .Sum();
            }

            return value;
        }

        public decimal GetTongTienNhapHang(DateTime startDate, DateTime endDate)
        {
            decimal value = 0;

            var models = db_.HoaDonNhaps.Where(t => t.NgayNhap >= startDate && t.NgayNhap <= endDate).ToArray();

            if (models.Length > 0)
            {
                value = models.Select(t => (decimal)t.TongTien)
                        .Sum();
            }

            return value;
        }

        public decimal GetLoiNhuan(DateTime startDate, DateTime endDate)
        {
            return GetDoanhThu(startDate, endDate) - GetTongTienNhapHang(startDate, endDate);
        }
    }
}