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
    class UserDAO : BaseDAO
    {
        public static string userId = null;

        // thực hiện phía client
        private bool CheckInputOfLoginForm(string username, string password, string phone)
        {
            Regex checkPhone = new Regex(@"^0[9|3]\d{8}$");

            if (username.Length == 0 || password.Length == 0 || phone.Length == 0)
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
            }

            return true;
        }

        private bool CheckInputOfSignUpForm(string name, string phone, string username, string pwd)
        {
            Regex checkPhone = new Regex(@"^0[9|3]\d{8}$");

            if (name.Length == 0 || phone.Length == 0 || username.Length == 0 || pwd.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (!checkPhone.IsMatch(phone))
                {
                    MessageBox.Show("Sai định dạng số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        public User GetSingle(string id)
        {
            return db.Users.Where(t => t.UId == id).FirstOrDefault();
        }

        public bool CheckLogin(string username, string password, string phone)
        {
            if (CheckInputOfLoginForm(username, password, phone))
            {
                var getUser = db.Users.Where(
                    t => t.UUsername == username &&
                    t.UPassword == password &&
                    t.UPhone == phone).FirstOrDefault();

                if (getUser == null)
                {
                    MessageBox.Show("Sai thông tin đăng nhập! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (GetSingle(getUser.UId).UStatus == 1)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Bạn không được phép truy cập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return false;
        }

        public string GetUserIdAfterLogin(string username, string password, string phone)
        {
            string userId = db.Users.Where(
                t => t.UUsername == username &&
                t.UPassword == password &&
                t.UPhone == phone
                ).FirstOrDefault().UId;

            return userId;
        }

        public bool SignUp(string name, string phone, string address, string username, string pwd)
        {
            if (CheckInputOfSignUpForm(name, phone, username, pwd))
            {
                User user = new User
                {
                    UId = BaseDAO.RandomString(10),
                    UName = name,
                    UPhone = phone,
                    UAddress = address,
                    UUsername = username,
                    UPassword = pwd,
                    UType = 1,
                    UStatus = 1
                };

                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool UpdateAccount(string name, string phone, string address, string username, string pwd)
        {
            if (CheckInputOfSignUpForm(name, phone, username, pwd))
            {
                var getUserById = GetSingle(userId);

                getUserById.UName = name;
                getUserById.UPhone = phone;
                getUserById.UAddress = address;
                getUserById.UUsername = username;
                getUserById.UPassword = pwd;

                try
                {
                    db.SaveChanges();

                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //Quản lý nhân viên dành cho Admin
        private bool CheckInput(string name, string phone, string username, string pwd, string type, string status)
        {
            Regex checkPhone = new Regex(@"^0[9|3]\d{8}$");

            if (name.Length == 0 || phone.Length == 0 || status.Length == 0 || status == null ||
                username.Length == 0 || pwd.Length == 0 || type.Length == 0 || type == null)
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
            }

            return true;
        }

        public bool Add(string userId, string name, string phone, string address, string username, string pwd, string type, string status)
        {
            if (CheckInput(name, phone, username, pwd, type, status))
            {
                string getStatus = status == "Đang làm việc" ? "1" : status == "Đã nghỉ việc" ? "0" : null;
                string getUserType = type == "Admin" ? "0" : type == "Nhân viên" ? "1" : null;

                User data = new User()
                {
                    UId = userId,
                    UName = name,
                    UPhone = phone,
                    UAddress = address,
                    UUsername = username,
                    UPassword = pwd,
                    UStatus = byte.Parse(getStatus),
                    UType = byte.Parse(getUserType)
                };

                try
                {
                    db.Users.Add(data);
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
            int getCountOfRecord = db.Users.Count();
            int getPageCount = (getCountOfRecord % 2) == 0 ? (getCountOfRecord / 2) : (getCountOfRecord / 2) + 1;
            return getPageCount;
        }

        public List<User> GetListByPage(int pageNubmer)
        {
            // trả về 2 khách hàng mỗi trang
            return db.Users.OrderByDescending(t => t.UId).Skip((pageNubmer - 1) * 2).Take(2).ToList();
        }

        public bool Save(string userId, string name, string phone, string address, string username, string pwd, string type, string status)
        {
            if (CheckInput(name, phone, username, pwd, type, status))
            {
                string getStatus = status == "Đang làm việc" ? "1" : status == "Đã nghỉ việc" ? "0" : null;
                string getUserType = type == "Admin" ? "0" : type == "Nhân viên" ? "1" : null;

                var getUserById = GetSingle(userId);

                getUserById.UName = name;
                getUserById.UPhone = phone;
                getUserById.UAddress = address;
                getUserById.UUsername = username;
                getUserById.UPassword = pwd;
                getUserById.UType = byte.Parse(getUserType);
                getUserById.UStatus = byte.Parse(getStatus);

                try
                {
                    db.SaveChanges();

                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool Delete(string UserId)
        {
            var getUserById = GetSingle(UserId);

            try
            {
                db.Users.Remove(getUserById);
                db.SaveChanges();

                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
