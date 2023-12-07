using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;
using PagedList;
using PagedList.Mvc;

namespace ShopOnline.Areas.admin.Controllers
{
    public class DanhMucTinTucController : Controller
    {
        private SHOPONLINEEntities db = new SHOPONLINEEntities();

        // GET: /admin/DanhMucTinTuc/
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            //return View(db.SACHes.ToList());
            return View(db.TheLoais.ToList().OrderBy(n => n.MaTheLoai).ToPagedList(pageNumber, pageSize));
        }

        // GET: /admin/DanhMucTinTuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoai theloai = db.TheLoais.Find(id);
            if (theloai == null)
            {
                return HttpNotFound();
            }
            return View(theloai);
        }

        // GET: /admin/DanhMucTinTuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /admin/DanhMucTinTuc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaTheLoai,TenTheLoai,meta")] TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                db.TheLoais.Add(theloai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theloai);
        }

        // GET: /admin/DanhMucTinTuc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoai theloai = db.TheLoais.Find(id);
            if (theloai == null)
            {
                return HttpNotFound();
            }
            return View(theloai);
        }

        // POST: /admin/DanhMucTinTuc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaTheLoai,TenTheLoai,meta")] TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theloai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theloai);
        }

        // GET: /admin/DanhMucTinTuc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoai theloai = db.TheLoais.Find(id);
            if (theloai == null)
            {
                return HttpNotFound();
            }
            return View(theloai);
        }

        // POST: /admin/DanhMucTinTuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TheLoai theloai = db.TheLoais.Find(id);
            db.TheLoais.Remove(theloai);
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
