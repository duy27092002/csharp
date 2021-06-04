using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using T3H_K35DL1_Winforms.Models.EF;

namespace T3H_K35DL1_Winforms.Models.DAO
{
    public class KhoaDAO : BaseDAO
    {
        public List<Khoa> GetAll()
        {
            return db_.Khoas.ToList();
        }

        // tìm kiếm theo keyword
        public List<Khoa> GetByKeyword(string keyword)
        {
            return db_.Khoas.Where(t => t.MaKhoa == keyword || t.TenKhoa.Contains(keyword)).ToList();
        }

        // lấy theo ID
        public Khoa GetSingleByID(string maKhoa)
        {
            return db_.Khoas.Where(t => t.MaKhoa == maKhoa).FirstOrDefault();
        }

        // thêm
        public bool Add(Khoa info)
        {
            try
            {
                db_.Khoas.Add(info);
                db_.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        // Sửa thông tin
        public bool Edit(Khoa info)
        {
            try
            {
                var info0 = GetSingleByID(info.MaKhoa);
                if (info0 != null)
                {
                    info0.TenKhoa = info.TenKhoa;
                    info0.DiaChi = info.DiaChi;
                    info0.SoDienThoai = info.SoDienThoai;

                    db_.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        // xóa theo mã
        public bool Delete(string maKhoa)
        {
            try
            {
                var info0 = GetSingleByID(maKhoa);
                if (info0 != null)
                {
                    db_.Khoas.Remove(info0);

                    db_.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
    }
}
