using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;

namespace ShopOnline.Controllers
{
    public class TinTucController : Controller
    {
        SHOPONLINEEntities db = new SHOPONLINEEntities();
        // GET: /Product/
        public ActionResult Index(string meta)
        {
            var v = from t in db.TheLoais
                    where t.meta == meta
                    select t;
            return View(v.FirstOrDefault());
        }


        public ActionResult Details(int id)
        {
            ViewBag.meta = "tin-tuc";
            var sp = from s in db.TinTucs
                     where s.MaTinTuc == id
                     select s;
            return View(sp.Single());
        }
        // hien thi cac bai viet moi
       
    }
}