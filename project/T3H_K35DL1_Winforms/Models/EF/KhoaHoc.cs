//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace T3H_K35DL1_Winforms.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhoaHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoaHoc()
        {
            this.SinhViens = new HashSet<SinhVien>();
        }
    
        public int MaKH { get; set; }
        public string MaMH { get; set; }
        public string MaGV { get; set; }
        public Nullable<int> KiHoc { get; set; }
    
        public virtual GiangVien GiangVien { get; set; }
        public virtual HocKi HocKi { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual MonHoc MonHoc1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
