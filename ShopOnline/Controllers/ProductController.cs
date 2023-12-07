using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;
using PagedList;
using PagedList.Mvc;


namespace ShopOnline.Controllers
{
    public class ProductController : Controller
    {
        SHOPONLINEEntities db = new SHOPONLINEEntities();  
        // GET: /Product/
        public ActionResult Index(int? page,string meta)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var v = from t in db.DANHMUCs
                where t.meta == meta
                select t;
             return View(v.FirstOrDefault());
        }
        public ActionResult Details(int id)
        {
            var sp = from s in db.SANPHAMs
                where s.MaSANPHAM == id
                select s;
            return View(sp.Single());
        }
        
	}
}