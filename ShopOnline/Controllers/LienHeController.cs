using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;

namespace ShopOnline.Controllers
{
    public class LienHeController : Controller
    {
        SHOPONLINEEntities db = new SHOPONLINEEntities();
        //
        // GET: /LienHe/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //
        [HttpPost]
         public ActionResult Index(FormCollection collection, GopY gy)
        {
            // gang gia tri nguoi nhap 
            var hoten = collection["HoTen"];
            var email = collection["Email"];
            var tieude = collection["TieuDe"];
            var noidung = collection["NoiDung"];

            // gang du lieu

            gy.HoTen = hoten;
            gy.Email = email;
            gy.TieuDe = tieude;
            gy.NoiDung = noidung;
            db.Gopies.Add(gy);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

	}
}