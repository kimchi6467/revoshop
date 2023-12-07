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
    public class QuanLyThongTinController : Controller
    {
        private SHOPONLINEEntities db = new SHOPONLINEEntities();

        // GET: /admin/QuanLyThongTin/
        public ActionResult Index()
        {
            return View(db.LienHes.ToList());
        }

        // GET: /admin/QuanLyThongTin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LienHe lienhe = db.LienHes.Find(id);
            if (lienhe == null)
            {
                return HttpNotFound();
            }
            return View(lienhe);
        }

        // GET: /admin/QuanLyThongTin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /admin/QuanLyThongTin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Sodienthoai,Email,DiaChi")] LienHe lienhe)
        {
            if (ModelState.IsValid)
            {
                db.LienHes.Add(lienhe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lienhe);
        }

        // GET: /admin/QuanLyThongTin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LienHe lienhe = db.LienHes.Find(id);
            if (lienhe == null)
            {
                return HttpNotFound();
            }
            return View(lienhe);
        }

        // POST: /admin/QuanLyThongTin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Sodienthoai,Email,DiaChi")] LienHe lienhe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lienhe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");

            }
            return RedirectToAction("Index", "Admin");

        }

        // GET: /admin/QuanLyThongTin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LienHe lienhe = db.LienHes.Find(id);
            if (lienhe == null)
            {
                return HttpNotFound();
            }
            return View(lienhe);
        }

        // POST: /admin/QuanLyThongTin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LienHe lienhe = db.LienHes.Find(id);
            db.LienHes.Remove(lienhe);
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
