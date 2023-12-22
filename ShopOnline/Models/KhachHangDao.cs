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
        public long Insert(DONHANG donhang)
        {
            db.DONHANGs.Add(donhang);
            db.SaveChanges();
            return donhang.MaDH;
        }
    }
}