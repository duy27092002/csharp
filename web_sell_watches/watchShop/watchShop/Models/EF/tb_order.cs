//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace watchShop.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_order
    {
        public int orderID { get; set; }
        public Nullable<int> watchID { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<int> amount { get; set; }
        public Nullable<int> price { get; set; }
        public string pic { get; set; }
        public Nullable<System.DateTime> time { get; set; }
        public Nullable<bool> status { get; set; }
    
        public virtual tb_products tb_products { get; set; }
        public virtual tb_users tb_users { get; set; }
    }
}
