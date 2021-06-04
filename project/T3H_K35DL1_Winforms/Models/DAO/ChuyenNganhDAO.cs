using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using T3H_K35DL1_Winforms.Models.EF;

namespace T3H_K35DL1_Winforms.Models.DAO
{
    public class ChuyenNganhDAO : BaseDAO
    {
        public List<ChuyenNganh> GetAll()
        {
            return db_.ChuyenNganhs.ToList();
        }

        public List<ChuyenNganh> GetByMaKhoa(string maKhoa)
        {
            return db_.ChuyenNganhs.Where(t => t.MaKhoa == maKhoa).ToList();
        }

        // tìm kiếm theo keyword
        public List<ChuyenNganh> GetByKeyword(string keyword)
        {
            return db_.ChuyenNganhs.Where(t => t.MaCN == keyword || t.TenCN.Contains(keyword)).ToList();
        }

        // lấy theo ID
        public ChuyenNganh GetSingleByID(string maChuyenNganh)
        {
            return db_.ChuyenNganhs.Where(t => t.MaCN == maChuyenNganh).FirstOrDefault();
        }

        // thêm
        public bool Add(ChuyenNganh info)
        {
            try
            {
                db_.ChuyenNganhs.Add(info);
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
        public bool Edit(ChuyenNganh info)
        {
            try
            {
                var info0 = GetSingleByID(info.MaCN);
                if (info0 != null)
                {
                    info0.TenCN = info.TenCN;
                    info0.MaCN = info.MaCN;

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
        public bool Delete(string maChuyenNganh)
        {
            try
            {
                var info0 = GetSingleByID(maChuyenNganh);
                if (info0 != null)
                {
                    db_.ChuyenNganhs.Remove(info0);

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
