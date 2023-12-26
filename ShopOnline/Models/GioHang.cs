using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  ShopOnline.Models;

namespace ShopOnline.Models
{
    public class Giohang
    {
        //Tao doi tuong data chua dữ liệu từ model dbBansach đã tạo. 
        SHOPONLINEEntities db = new SHOPONLINEEntities();
        public int iMaSANPHAM { set; get; }
        public string sTenSANPHAM { set; get; }
        public string sHinhAnh { set; get; }
        public Double dDongia { set; get; }
        public int iSoluong { set; get; }

        public int iSIZE { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }

        }
        //Khoi tao gio hàng theo Masach duoc truyen vao voi Soluong mac dinh la 1
        public Giohang(int MaSANPHAM)
        {
            iMaSANPHAM = MaSANPHAM;
            SANPHAM sanpham = db.SANPHAMs.Single(n => n.MaSANPHAM == iMaSANPHAM);
            sTenSANPHAM = sanpham.TenSANPHAM;
            sHinhAnh = sanpham.HinhAnh;
            dDongia = double.Parse(sanpham.Giaban.ToString());
            iSoluong = 1;
            
        }
    }
}