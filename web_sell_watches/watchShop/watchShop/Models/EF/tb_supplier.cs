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
    
    public partial class tb_supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_supplier()
        {
            this.tb_inport_invoice = new HashSet<tb_inport_invoice>();
        }
    
        public int supplierID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string EMail { get; set; }
        public string phonenumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_inport_invoice> tb_inport_invoice { get; set; }
    }
}