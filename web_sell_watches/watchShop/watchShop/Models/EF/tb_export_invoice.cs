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
    
    public partial class tb_export_invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_export_invoice()
        {
            this.tb_details_export = new HashSet<tb_details_export>();
        }
    
        public int exportInvoiceID { get; set; }
        public Nullable<int> staffID { get; set; }
        public Nullable<int> customerID { get; set; }
        public Nullable<System.DateTime> time { get; set; }
        public Nullable<int> totalPrice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_details_export> tb_details_export { get; set; }
        public virtual tb_users tb_users { get; set; }
    }
}