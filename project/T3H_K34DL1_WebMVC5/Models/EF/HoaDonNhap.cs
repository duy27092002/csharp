//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace T3H_K34DL1_WebMVC5.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDonNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonNhap()
        {
            this.CT_HDNhap = new HashSet<CT_HDNhap>();
        }
    
        public int MaHDNhap { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<int> MaNV { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public Nullable<int> MaNCC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HDNhap> CT_HDNhap { get; set; }
        public virtual NhaCC NhaCC { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
