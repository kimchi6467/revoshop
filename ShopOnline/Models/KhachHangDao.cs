using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class KhachHangDao
    {
        SHOPONLINEEntities db = null;
        public KhachHangDao()
        {
            db = new SHOPONLINEEntities();
        }
        public long Insert(KHACHHANG khachhang)
        {
            db.KHACHHANGs.Add(khachhang);
            db.SaveChanges();
            return khachhang.MaKH;
        }
    }
}