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
    
    public partial class PromissoryNoteDetail
    {
        public string Id { get; set; }
        public string PNId { get; set; }
        public string BookId { get; set; }
        public System.DateTime BorrowedDate { get; set; }
        public System.DateTime PayDate { get; set; }
        public double Cost { get; set; }
        public byte Status { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual PromissoryNote PromissoryNote { get; set; }
    }
}