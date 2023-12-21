using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;

namespace ShopOnline.Controllers
{
    public class ControlPanelController : Controller
    {
        SHOPONLINEEntities db = new SHOPONLINEEntities();

        //
        // GET: /ControlPanel/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LienHe()
        {
            var LienHe = from _LienHe in db.LienHes
                         select _LienHe;
            return PartialView(LienHe);
        }
       
        public ActionResult Lienhefooter()
        {
            var lienhefoorter = from _lienhefooter in db.LienHes
                                select _lienhefooter;
            return PartialView(lienhefoorter);

        }
        public ActionResult QuangCao()
        {
            var Quangcao = from _quangcao in db.QUANGCAOs
                           select _quangcao;
            return PartialView(Quangcao);
        }
        public ActionResult QuanLyTrangLienHe()
        {
            var quanlytrang = from _quablytrang in db.QuanLyTrangLienHes
                              select _quablytrang;
            return PartialView(quanlytrang);
        }
	}
}