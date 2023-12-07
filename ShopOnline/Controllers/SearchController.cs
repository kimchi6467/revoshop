using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;
using PagedList;

namespace ShopOnline.Controllers
{
    public class SearchController : Controller
    {
       SHOPONLINEEntities db = new SHOPONLINEEntities();
        // GET: Search
        [HttpPost]
        public ActionResult getSearch(FormCollection f, int? page)
        {
            string sTukhoa = f["txtTimkiem"].ToString();
            List<SANPHAM> lstKQTK = db.SANPHAMs.Where(m => m.TenSANPHAM.Contains(sTukhoa)).ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 9;

            if (lstKQTK.Count == 0)
            {
                ViewBag.Thongbao = "Không tìm thấy sản phẩm nào";
                return View(db.SANPHAMs.OrderBy(m => m.TenSANPHAM).ToPagedList(pageNumber, pageSize));
            }
            return View(lstKQTK.OrderBy(m => m.TenSANPHAM).ToPagedList(pageNumber, pageSize));
        }
    }
}