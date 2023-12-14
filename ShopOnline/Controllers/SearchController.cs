using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;
using PagedList;
using System;

namespace ShopOnline.Controllers
{
    public class SearchController : Controller
    {
       SHOPONLINEEntities db = new SHOPONLINEEntities();
        // GET: Search
        [HttpPost]
        public ActionResult search(FormCollection f, int? page)
        {
            String sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<SANPHAM> lstkqtk = db.SANPHAMs.Where(n => n.TenSANPHAM.Contains(sTuKhoa)).ToList();


            // Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            if (lstkqtk.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy kết quả nào";
                return View(db.SANPHAMs.OrderBy(n => n.TenSANPHAM).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy\n" + lstkqtk.Count + "\nkết quả";
            return View(lstkqtk.OrderBy(n => n.TenSANPHAM).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult search(int? page, String sTuKhoa = "")
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<SANPHAM> lstkqtk = db.SANPHAMs.Where(n => (!String.IsNullOrEmpty(sTuKhoa) && n.TenSANPHAM.Contains(sTuKhoa)) && !( false)).ToList();
            // Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            if (lstkqtk.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy kết quả nào";
                return View(lstkqtk.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy" + lstkqtk.Count + "Kết quả";
            return View(lstkqtk.OrderBy(n => n.TenSANPHAM).ToPagedList(pageNumber, pageSize));
        }
    }
}