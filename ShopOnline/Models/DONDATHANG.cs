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
    
    public partial class DONDATHANG
    {
        public int MaDonHang { get; set; }
        public Nullable<bool> Dathanhtoan { get; set; }
        public Nullable<bool> Tinhtranggiaohang { get; set; }
        public Nullable<System.DateTime> Ngaydat { get; set; }
        public Nullable<System.DateTime> Ngaygiao { get; set; }
        public Nullable<int> MaKH { get; set; }
    
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
