//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManageWebsite.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string AdminName { get; set; }
        public string AdminPhone { get; set; }
        public string AdminEmail { get; set; }
        public byte Status { get; set; }
    
        public virtual Owner Owner { get; set; }
    }
}