using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManageWebsite.Models.EF
{
    [MetadataType(typeof(MetaUserManual))]
    public partial class UserManual
    {
    }

    public class MetaUserManual
    {
        [AllowHtml]
        [Required(ErrorMessage = "Không được để trống nội dung")]
        public string UMContent { get; set; }
    }
}