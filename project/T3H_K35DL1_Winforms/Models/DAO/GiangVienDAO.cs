using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using T3H_K35DL1_Winforms.Models.EF;

namespace T3H_K35DL1_Winforms.Models.DAO
{
    // kế thừa BaseDAO để liên kết với DB
    public class GiangVienDAO : BaseDAO
    {
        // lấy tất cả thông tin Giảng Viên trong DB
        public List<GiangVien> GetAll()
        {
            return db_.GiangViens.ToList();
        }

        // tìm kiếm Giảng Viên theo keyword
        public List<GiangVien> GetByKeyword(string keyword)
        {
            return db_.GiangViens.Where(t => t.MaGV == keyword || t.HoTen.Contains(keyword)).ToList();
        }

        // lấy Giảng Viên theo maGV
        public GiangVien GetSingleByID(string maGV)
        {
            return db_.GiangViens.Where(t => t.MaGV == maGV).FirstOrDefault();
        }

        // thêm Giảng Viên (insert)
        public bool Add(GiangVien info)
        {
            try
            {
                // thực hiện thêm dữ liệu vào DB
                db_.GiangViens.Add(info);
                // lưu thông tin đã thêm
                db_.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        // Sửa thông tin Giảng Viên (update)
        public bool Edit(GiangVien info)
        {
            try
            {
                var info0 = GetSingleByID(info.MaGV);
                if (info0 != null)
                {
                    info0.HoTen = info.HoTen;
                    info0.GioiTinh = info.GioiTinh;
                    info0.NgaySinh = info.NgaySinh;
                    info0.QueQuan = info.QueQuan;
                    info0.DiaChi = info.DiaChi;
                    info0.EMail = info.EMail;
                    info0.SDT = info.SDT;
                    info0.MaBM = info.MaBM;
                    info0.Pic = info.Pic;

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

        // xóa theo mã Giảng Viên
        public bool Delete(string maGV)
        {
            try
            {
                var info0 = GetSingleByID(maGV);
                if (info0 != null)
                {
                    db_.GiangViens.Remove(info0);

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
