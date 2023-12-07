using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using ShopOnline.Models;
using System.Data;
using System.Data.Entity;

namespace ShopOnline.Controllers
{
    public class HomeController : Controller
    {
        SHOPONLINEEntities db = new SHOPONLINEEntities();
        public ActionResult Index(string meta)
        {
            var v = from t in db.menus
                    where t.meta == meta
                    select t;
            return View(v.FirstOrDefault());
        }
        // lay thanh menu top
        public ActionResult Menus()
        {
            var menus = from Menu in db.menus
                select Menu;
            return PartialView(menus);
        }
        // lay danh muc san pham
        public ActionResult DanhMuc()
        {
            ViewBag.meta = "san-pham";
            var danhmuc = from _danhmuc in db.DANHMUCs select _danhmuc;
            return PartialView(danhmuc);
        }

        
        private List<SANPHAM> Laysanphammoi(int count)
        {
            //Sắp xếp sách theo ngày cập nhật, sau đó lấy top @count 
            return db.SANPHAMs.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult SanPhamMoi()
        {
            ViewBag.meta = "san-pham";
            var sanphammoi = Laysanphammoi(15);
            return PartialView(sanphammoi);

        }

        // lay so luong san pham dien thoai
        private List<SANPHAM> SanPhamDT(int count)
        {
            return db.SANPHAMs.Where(b => b.MaDM == 1).Take(count).ToList();

        }
        public ActionResult SanPhamGiayNam()
        {
            ViewBag.meta = "san-pham";
            var spmoi = SanPhamDT(10);
            return PartialView(spmoi);
        }
        // LAY SAN PHAM THIET BI MAY TINH
        private List<SANPHAM> SanPhamMT(int count)
        {
            return db.SANPHAMs.Where(b=>b.MaDM ==2).Take(count).ToList();

        }
        public ActionResult SanphamGiayNu()
        {
            ViewBag.meta = "san-pham";
            var spmaytinh = SanPhamMT(10);
            return PartialView(spmaytinh);
        }
        public ActionResult SanPhamHot()
        {
            var sanphamhot = from p in db.SANPHAMs
                where p.MaDM == 7
                select p;
            return PartialView(sanphamhot);
        }
    
     
        public ActionResult SanPhamTheoChuDe(int id, string metatitle)
        {
            ViewBag.meta = "san-pham";
            var sp = from s in db.SANPHAMs
                where s.MaDM == id
                select s;
            return PartialView(sp.ToList());
        }
      
        public ActionResult Tintuctheochude(int id, string metatitle)
        {
            ViewBag.meta = "tin-tuc";
            var tt = from _tt in db.TinTucs
                     where _tt.MaTheLoai == id
                     select _tt;
            return PartialView(tt.ToList());
        }
    
        // hien thi bai vietmoi
        private List<TinTuc> Laybaivietmoi(int count)
        {
            //Sắp xếp sách theo ngày cập nhật, sau đó lấy top @count 
            return db.TinTucs.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        public ActionResult Baivietmoi()
        {
            ViewBag.meta = "tin-tuc";
            var bvmoi = Laybaivietmoi(5);
            return PartialView(bvmoi);

        }
        // hien thi danh muc bai viet
        public ActionResult danhmuctintuc()

        {
            ViewBag.meta = "tin-tuc";
            var danhmuctintuc = from _danhmuctintuc in db.TheLoais
                                select _danhmuctintuc;
            return PartialView(danhmuctintuc);
        }
     
        // bai viet moi hien thi trang chu
        private List<TinTuc> Laytintucmoihome(int count)
        {
           
            return db.TinTucs.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        public ActionResult LAYTINTUNMOIHOME()
        {
            ViewBag.meta = "tin-tuc";
            var ttmoihome = Laytintucmoihome(3);
            return PartialView(ttmoihome);

        }
        // chi tiet gioi thieu
        public ActionResult ChiTietGioiThieu()
        {
            var ctgt = from _ctgt in db.QLTrangGioiThieux
                       select _ctgt;
            return PartialView(ctgt);
        }
    }

}