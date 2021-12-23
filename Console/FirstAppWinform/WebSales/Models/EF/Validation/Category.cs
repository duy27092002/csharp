using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSales.Models.EF
{
    [MetadataType(typeof(MetaCategory))]
    public partial class Category
    {

    }

    public class MetaCategory
    {
        [Required(ErrorMessage = "Không được để trống!")]
        [MaxLength(50, ErrorMessage = "Tên không được quá 50 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [MaxLength(50, ErrorMessage = "Tên không được quá 50 ký tự")]
        public string NameVN { get; set; }
    }
}