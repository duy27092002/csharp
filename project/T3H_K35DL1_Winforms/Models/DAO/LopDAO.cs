using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using T3H_K35DL1_Winforms.Models.EF;

namespace T3H_K35DL1_Winforms.Models.DAO
{
    public class LopDAO : BaseDAO
    {
        public List<Lop> GetAll()
        {
            return db_.Lops.ToList();
        }

        public List<Lop> GetByMaChuyenNganh(string machuyenNganh)
        {
            return db_.Lops.Where(t => t.MaCN == machuyenNganh).ToList();
        }

        // tìm kiếm theo keyword
        public List<Lop> GetByKeyword(string keyword)
        {
            return db_.Lops.Where(t => t.MaLop == keyword || t.TenLop.Contains(keyword)).ToList();
        }

        // lấy theo ID
        public Lop GetSingleByID(string maLop)
        {
            return db_.Lops.Where(t => t.MaLop == maLop).FirstOrDefault();
        }

        // thêm Sinh Viên
        public bool Add(Lop info)
        {
            try
            {
                db_.Lops.Add(info);
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
        public bool Edit(Lop info)
        {
            try
            {
                var info0 = GetSingleByID(info.MaLop);
                if (info0 != null)
                {
                    info0.TenLop = info.TenLop;
                    info0.MaGV = info.MaGV;
                    info0.MaCN = info.MaCN;
                    info0.NienKhoa = info.NienKhoa;

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

        // xóa theo mã Sinh Viên
        public bool Delete(string maLop)
        {
            try
            {
                var info0 = GetSingleByID(maLop);
                if (info0 != null)
                {
                    db_.Lops.Remove(info0);

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
