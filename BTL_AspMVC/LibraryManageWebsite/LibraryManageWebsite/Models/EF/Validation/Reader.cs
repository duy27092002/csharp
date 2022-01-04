using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManageWebsite.Models.EF
{
    [MetadataType(typeof(MetaReader))]
    public partial class Reader
    {
    }

    public class MetaReader
    {
        [Required(ErrorMessage = "Không được để trống tên")]
        [MaxLength(50, ErrorMessage = "Tên tối đa là 50 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn chưa chọn giới tính")]
        public byte Gender { get; set; }

        [Required(ErrorMessage = "Không được để trống ngày sinh")]
        public System.DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Không được để trống email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50, ErrorMessage = "Email tối đa là 50 ký tự")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Sai định dạng email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Không được để trống số điện thoại")]
        [MaxLength(20, ErrorMessage = "Số điện thoại tối đa là 20 số")]
        [RegularExpression(@"^\d{0,20}$", ErrorMessage = "Sai định dạng số điện thoại")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Không được để trống mã xác minh")]
        public string OwnerId { get; set; }
    }
}