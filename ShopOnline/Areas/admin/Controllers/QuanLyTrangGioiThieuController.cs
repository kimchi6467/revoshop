using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;

namespace ShopOnline.Areas.admin.Controllers
{
    public class QuanLyTrangGioiThieuController : Controller
    {
        private SHOPONLINEEntities db = new SHOPONLINEEntities();

        // GET: /admin/QuanLyTrangGioiThieu/
        public ActionResult Index()
        {
            return View(db.QLTrangGioiThieux.ToList());
        }

        // GET: /admin/QuanLyTrangGioiThieu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLTrangGioiThieu qltranggioithieu = db.QLTrangGioiThieux.Find(id);
            if (qltranggioithieu == null)
            {
                return HttpNotFound();
            }
            return View(qltranggioithieu);
        }

        // GET: /admin/QuanLyTrangGioiThieu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /admin/QuanLyTrangGioiThieu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,TieuDe,NoiDung")] QLTrangGioiThieu qltranggioithieu)
        {
            if (ModelState.IsValid)
            {
                db.QLTrangGioiThieux.Add(qltranggioithieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qltranggioithieu);
        }

        // GET: /admin/QuanLyTrangGioiThieu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLTrangGioiThieu qltranggioithieu = db.QLTrangGioiThieux.Find(id);
            if (qltranggioithieu == null)
            {
                return HttpNotFound();
            }
            return View(qltranggioithieu);
        }

        // POST: /admin/QuanLyTrangGioiThieu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit([Bind(Include="Id,TieuDe,NoiDung")] QLTrangGioiThieu qltranggioithieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qltranggioithieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");

            }
            return View(qltranggioithieu);
        }

        // GET: /admin/QuanLyTrangGioiThieu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLTrangGioiThieu qltranggioithieu = db.QLTrangGioiThieux.Find(id);
            if (qltranggioithieu == null)
            {
                return HttpNotFound();
            }
            return View(qltranggioithieu);
        }

        // POST: /admin/QuanLyTrangGioiThieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QLTrangGioiThieu qltranggioithieu = db.QLTrangGioiThieux.Find(id);
            db.QLTrangGioiThieux.Remove(qltranggioithieu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
