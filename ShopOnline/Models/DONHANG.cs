//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            this.CHITIETDONDATHANGs = new HashSet<CHITIETDONDATHANG>();
        }
    
        public int MaDH { get; set; }
        public string HoTenKH { get; set; }
        public string DiaChiKH { get; set; }
        public string EmailKH { get; set; }
        public string SodtKH { get; set; }
        public Nullable<System.DateTime> Ngaydat { get; set; }
        public Nullable<System.DateTime> Ngaygiao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONDATHANG> CHITIETDONDATHANGs { get; set; }
    }
}