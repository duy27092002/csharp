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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_QLBanDongHoEntities1 : DbContext
    {
        public DB_QLBanDongHoEntities1()
            : base("name=DB_QLBanDongHoEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tb_cart> tb_cart { get; set; }
        public virtual DbSet<tb_category> tb_category { get; set; }
        public virtual DbSet<tb_details_export> tb_details_export { get; set; }
        public virtual DbSet<tb_details_inport> tb_details_inport { get; set; }
        public virtual DbSet<tb_export_invoice> tb_export_invoice { get; set; }
        public virtual DbSet<tb_inport_invoice> tb_inport_invoice { get; set; }
        public virtual DbSet<tb_order> tb_order { get; set; }
        public virtual DbSet<tb_producer> tb_producer { get; set; }
        public virtual DbSet<tb_products> tb_products { get; set; }
        public virtual DbSet<tb_slider> tb_slider { get; set; }
        public virtual DbSet<tb_supplier> tb_supplier { get; set; }
        public virtual DbSet<tb_users> tb_users { get; set; }
        public virtual DbSet<tb_wishlist> tb_wishlist { get; set; }
    }
}
