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
    public class QuanLyTrangLienHeController : Controller
    {
        private SHOPONLINEEntities db = new SHOPONLINEEntities();

        // GET: /admin/QuanLyTrangLienHe/
        public ActionResult Index()
        {
            return View(db.QuanLyTrangLienHes.ToList());
        }

        // GET: /admin/QuanLyTrangLienHe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanLyTrangLienHe quanlytranglienhe = db.QuanLyTrangLienHes.Find(id);
            if (quanlytranglienhe == null)
            {
                return HttpNotFound();
            }
            return View(quanlytranglienhe);
        }

        // GET: /admin/QuanLyTrangLienHe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /admin/QuanLyTrangLienHe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,GioiThieu,DiaChi,Email,SodienThoai")] QuanLyTrangLienHe quanlytranglienhe)
        {
            if (ModelState.IsValid)
            {
                db.QuanLyTrangLienHes.Add(quanlytranglienhe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quanlytranglienhe);
        }

        // GET: /admin/QuanLyTrangLienHe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanLyTrangLienHe quanlytranglienhe = db.QuanLyTrangLienHes.Find(id);
            if (quanlytranglienhe == null)
            {
                return HttpNotFound();
            }
            return View(quanlytranglienhe);
        }

        // POST: /admin/QuanLyTrangLienHe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include="Id,GioiThieu,DiaChi,Email,SodienThoai")] QuanLyTrangLienHe quanlytranglienhe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quanlytranglienhe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            return View(quanlytranglienhe);
        }

        // GET: /admin/QuanLyTrangLienHe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanLyTrangLienHe quanlytranglienhe = db.QuanLyTrangLienHes.Find(id);
            if (quanlytranglienhe == null)
            {
                return HttpNotFound();
            }
            return View(quanlytranglienhe);
        }

        // POST: /admin/QuanLyTrangLienHe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuanLyTrangLienHe quanlytranglienhe = db.QuanLyTrangLienHes.Find(id);
            db.QuanLyTrangLienHes.Remove(quanlytranglienhe);
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
