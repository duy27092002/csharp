using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManageWebsite.Models.EF
{
    [MetadataType(typeof(MetaBook))]
    public partial class Book
    {
    }

    public class MetaBook
    {
        [Required(ErrorMessage = "Không được để trống tên sách")]
        [MaxLength(255, ErrorMessage = "Tên sách tối đa là 255 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Không được để trống tên tác giả")]
        [MaxLength(255, ErrorMessage = "Tên tác giả tối đa là 255 ký tự")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Không được để trống tên nhà xuất bản")]
        [MaxLength(255, ErrorMessage = "Tên nhà xuất bản tối đa là 255 ký tự")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Không được để trống giá sách")]
        [RegularExpression(@"^(?!0\.00)[1-9]\d{0,2}(,\d{3})*(\.\d\d)?$", ErrorMessage = "Sai định dạng giá sách")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Không được để trống số lượng sách")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Không được để trống năm phát hành")]
        [RegularExpression(@"^[+]?\d+$", ErrorMessage = "Sai định dạng năm phát hành")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Không được để trống mã xác minh")]
        public string OwnerId { get; set; }
    }
}