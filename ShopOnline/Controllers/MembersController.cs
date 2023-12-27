using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;

namespace ShopOnline.Controllers
{
    public class MembersController : Controller
    {
        SHOPONLINEEntities db = new SHOPONLINEEntities();

        //
        // GET: /Members/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KHACHHANG kh)
        {
            // Gán các giá tị người dùng nhập liệu cho các biến 
            var hoten = collection["HoTen"];
            var tendn = collection["Taikhoan"];
            var matkhau = collection["Matkhau"];
            //var nhaplaimatkhau = collection["Nhaplaimatkhau"];
            var diachi = collection["DiachiKH"];
            var email = collection["Email"];
            var dienthoai = collection["DienthoaiKH"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            // gang du lieu

            kh.HoTen = hoten;
            kh.Taikhoan = tendn;
            kh.Matkhau = matkhau;
            //kh.Matkhau = nhaplaimatkhau;
            kh.Email = email;
            kh.DiachiKH = diachi;
            kh.DienthoaiKH = dienthoai;
            kh.Ngaysinh = DateTime.Parse(ngaysinh);
            db.KHACHHANGs.Add(kh);
            db.SaveChanges();
            return RedirectToAction("Giohang", "Giohang");
              
        }


        [HttpGet]
        public ActionResult QuenMK()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuenMK(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.Taikhoan == sTaiKhoan && n.Matkhau == sMatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công !";
                Session["TaiKhoan"] = kh;
                return RedirectToAction("GioHang", "GioHang");
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.Taikhoan == sTaiKhoan && n.Matkhau == sMatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công !";
                Session["TaiKhoan"] = kh;
                return RedirectToAction("GioHang", "GioHang");
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            return View();
        }
        //thoat tai khoan
        //public ActionResult Thoat()
        //{
        //    if (Session["TaiKhoan"] == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        public ActionResult Thoat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DoiMatKhau()
        {

            Session["TaiKhoan"] = null;
            {
                return View();
            }

        }



    }
}