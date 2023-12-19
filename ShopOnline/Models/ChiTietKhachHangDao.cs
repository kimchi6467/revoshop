using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class ChiTietKhachHangDao
    {
        SHOPONLINEEntities db = null;
        public ChiTietKhachHangDao()
        {
            db = new SHOPONLINEEntities();
        }
        public bool Insert(CHITIETDONTHANG chitiet)
        {
            try
            {
                db.CHITIETDONTHANGs.Add(chitiet);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}