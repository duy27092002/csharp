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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class tb_users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_users()
        {
            this.tb_cart = new HashSet<tb_cart>();
            this.tb_export_invoice = new HashSet<tb_export_invoice>();
            this.tb_inport_invoice = new HashSet<tb_inport_invoice>();
            this.tb_order = new HashSet<tb_order>();
            this.tb_wishlist = new HashSet<tb_wishlist>();

            avatar = "~/Content/images/avatars/add.jpg";
        }
    
        public int userID { get; set; }
        public string name { get; set; }
        public Nullable<bool> gender { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string avatar { get; set; }
        public Nullable<bool> isAdmin { get; set; }
        public Nullable<bool> isCustomer { get; set; }
        public Nullable<bool> isStaff { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_cart> tb_cart { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_export_invoice> tb_export_invoice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_inport_invoice> tb_inport_invoice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_order> tb_order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_wishlist> tb_wishlist { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
