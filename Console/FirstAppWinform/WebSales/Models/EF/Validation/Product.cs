using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSales.Models.EF
{
    [MetadataType(typeof(MetaProduct))]
    public partial class Product
    {

    }

    public class MetaProduct
    {
        [Required(ErrorMessage = "Không được để trống tên sản phẩm!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hãy nhập ảnh sản phẩm!")]
        public string Image { get; set; }

    }
}