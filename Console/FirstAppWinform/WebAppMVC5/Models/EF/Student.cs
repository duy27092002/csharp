using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMVC5.Models.EF
{
    public class Student
    {
        [Required(ErrorMessage = "ID không được để trống")]
        [StringLength(10,ErrorMessage = "ID là một chuỗi 10 ký tự")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [MaxLength(50, ErrorMessage = "Tên không được quá 50 ký tự")]

        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Compare(nameof(Email), ErrorMessage = "Email không trùng khớp")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [MaxLength(15, ErrorMessage = "Số điện thoại không được quá 15 ký tự")]
        [RegularExpression("(84|0[3|5|7|8|9])+([0-9]{8})", ErrorMessage = "Số điện thoại không đúng định dạng")]
        public string PhoneNumber { get; set; }
        public string IDCard { get; set; }
    }
}