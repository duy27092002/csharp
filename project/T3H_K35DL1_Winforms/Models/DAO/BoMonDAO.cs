using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using T3H_K35DL1_Winforms.Models.EF;

namespace T3H_K35DL1_Winforms.Models.DAO
{
    public class BoMonDAO : BaseDAO
    {
        public List<BoMon> GetAll()
        {
            return db_.BoMons.ToList();
        }

        public List<BoMon> GetByMaKhoa(string maKhoa)
        {
            return db_.BoMons.Where(t => t.MaKhoa == maKhoa).ToList();
        }

        // tìm kiếm theo keyword
        public List<BoMon> GetByKeyword(string keyword)
        {
            return db_.BoMons.Where(t => t.MaBM == keyword || t.TenBM.Contains(keyword)).ToList();
        }

        // lấy theo ID
        public BoMon GetSingleByID(string maBM)
        {
            return db_.BoMons.Where(t => t.MaBM == maBM).FirstOrDefault();
        }

        // thêm bộ môn
        public bool Add(BoMon info)
        {
            try
            {
                db_.BoMons.Add(info);
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
        public bool Edit(BoMon info)
        {
            try
            {
                var info0 = GetSingleByID(info.MaBM);
                if (info0 != null)
                {
                    info0.TenBM = info.TenBM;
                    info0.MaKhoa = info.MaKhoa;

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

        // xóa theo mã bộ môn
        public bool Delete(string maBM)
        {
            try
            {
                var info0 = GetSingleByID(maBM);
                if (info0 != null)
                {
                    db_.BoMons.Remove(info0);

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
