using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMVC5.Models.EF
{
    public class MailInfo
    {
        //public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Note { get; set; }

    }
}