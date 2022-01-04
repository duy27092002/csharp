using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManageWebsite.Models.EF
{
    [MetadataType(typeof(MetaRegulation))]
    public partial class Regulation
    {
    }

    public class MetaRegulation
    {
        [AllowHtml]
        [Required(ErrorMessage = "Không được để trống nội dung")]
        public string RegulationsContent { get; set; }

        [Required(ErrorMessage = "Không được để trống mã xác minh")]
        public string OwnerId { get; set; }
    }
}