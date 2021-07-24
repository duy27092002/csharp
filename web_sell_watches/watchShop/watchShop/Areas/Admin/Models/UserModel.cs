using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace watchShop.Areas.Admin.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Tên là bắt buộc!")]
        public string name { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc!")]
        public string birthday { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc!")]
        public string email { get; set; }

        [Required(ErrorMessage = "SĐT là bắt buộc!")]
        public string phonenumber { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc!")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc!")]
        public string password { get; set; }
    }
}