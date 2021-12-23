using LibraryManagement.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Models.DAO
{
    class ReaderDAO : BaseDAO
    {
        private bool CheckInput(string name, string phone, string idCardNumber, string status)
        {
            Regex checkPhone = new Regex(@"^0[9|3]\d{8}$");

            Regex checkIdCardNumber = new Regex(@"^\d{12}$");

            if (name.Length == 0 || phone.Length == 0 || status.Length == 0 || status == null)
            {
                MessageBox.Show("Không được để trống dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (!checkPhone.IsMatch(phone))
                {
                    MessageBox.Show("Sai định dạng số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (!checkIdCardNumber.IsMatch(idCardNumber))
                {
                    MessageBox.Show("Sai định dạng số CCCD/CMND!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        public bool Add(string readerId, string name, string phone, string address, string idCardNumber, string status)
        {
            if (CheckInput(name, phone, idCardNumber, status))
            {
                string getStatus = status == "Còn dịch vụ" ? "1" : status == "Đã hết dịch vụ" ? "0" : null;

                Reader data = new Reader()
                {
                    RId = readerId,
                    RName = name,
                    RPhone = phone,
                    RIdCardNumber = idCardNumber,
                    RAddress = address,
                    RStatus = byte.Parse(getStatus)
                };

                try
                {
                    db.Readers.Add(data);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }

        public int GetPageCount()
        {
            int getCountOfRecord = db.Readers.Count();
            int getPageCount = (getCountOfRecord % 2) == 0 ? (getCountOfRecord / 2) : (getCountOfRecord / 2) + 1;
            return getPageCount;
        }

        public List<Reader> GetListByPage(int pageNubmer)
        {
            // trả về 2 khách hàng mỗi trang
            return db.Readers.OrderByDescending(t => t.RId).Skip((pageNubmer - 1) * 2).Take(2).ToList();
        }

        public Reader GetSingleById(string id)
        {
            return db.Readers.Where(t => t.RId == id).FirstOrDefault();
        }

        public bool Save(string readerId, string name, string phone, string address, string idCardNumber, string status)
        {
            if (CheckInput(name, phone, idCardNumber, status))
            {
                string getStatus = status == "Còn dịch vụ" ? "1" : status == "Đã hết dịch vụ" ? "0" : null;

                var getReaderById = GetSingleById(readerId);

                getReaderById.RName = name;
                getReaderById.RPhone = phone;
                getReaderById.RAddress = address;
                getReaderById.RIdCardNumber = idCardNumber;
                getReaderById.RStatus = byte.Parse(getStatus);

                try
                {
                    db.SaveChanges();

                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }

        public bool Delete(string readerId)
        {
            var getReaderById = GetSingleById(readerId);

            try
            {
                db.Readers.Remove(getReaderById);
                db.SaveChanges();

                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
