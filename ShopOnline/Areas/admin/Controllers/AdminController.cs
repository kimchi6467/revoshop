using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;

namespace ShopOnline.Areas.admin.Controllers
{
    
    public class AdminController : Controller

    {
        SHOPONLINEEntities db = new SHOPONLINEEntities();
        //
        // GET: /admin/Admin/
        
        public ActionResult Index()
        {
           
            return View();
        }
        // trang dang nhap 
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {

            // Gán các giá trị người dùng nhập liệu cho các biến 
            var tendn = collection["username"];
            var matkhau = collection["password"];

            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }

            else
            {
                NHANVIEN ad = db.NHANVIENs.SingleOrDefault(n => n.Taikhoan == tendn && n.Matkhau == matkhau);
                //Gán giá trị cho đối tượng được tạo mới (ad)                  
                if (ad != null)
                {
                    Session["user"] = ad;

                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
	}
}