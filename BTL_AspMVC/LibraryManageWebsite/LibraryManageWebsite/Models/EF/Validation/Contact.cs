using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManageWebsite.Models.EF
{
    [MetadataType(typeof(MetaContact))]
    public partial class Contact
    {
    }

    public class MetaContact
    {
        [Required(ErrorMessage = "Không được để trống tên")]
        [MaxLength(50, ErrorMessage = "Tên tối đa là 50 ký tự")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Không được để trống email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50, ErrorMessage = "Email tối đa là 50 ký tự")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Sai định dạng email")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Không được để trống số điện thoại")]
        [MaxLength(20, ErrorMessage = "Số điện thoại tối đa là 20 số")]
        [RegularExpression(@"^\d{0,20}$", ErrorMessage = "Sai định dạng số điện thoại")]
        public string AdminPhone { get; set; }

        [Required(ErrorMessage = "Không được để trống mã xác minh")]
        public string OwnerId { get; set; }
    }
}