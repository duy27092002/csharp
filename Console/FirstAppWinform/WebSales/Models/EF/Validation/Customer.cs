using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSales.Models.EF
{
    [MetadataType(typeof(MetaCustomer))]
    public partial class Customer
    {
    }

    public class MetaCustomer
    {
        [Required(ErrorMessage = "Không được để trống mật khẩu!")]
        [MinLength(8, ErrorMessage = "Mật khẩu phải ít nhất 8 ký tự")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Không được để trống tên!")]
        [MaxLength(50, ErrorMessage = "Tên không được quá 50 ký tự!")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Không được để trống email!")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Sai định dạng email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Không được để trống avatar!")]
        public string Photo { get; set; }
    }
}