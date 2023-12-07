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
    public class GopYController : Controller
    {
        private SHOPONLINEEntities db = new SHOPONLINEEntities();

        // GET: /admin/GopY/
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            //return View(db.SACHes.ToList());
            return View(db.Gopies.ToList().OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
        }

        // GET: /admin/GopY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GopY gopy = db.Gopies.Find(id);
            if (gopy == null)
            {
                return HttpNotFound();
            }
            return View(gopy);
        }

        // GET: /admin/GopY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /admin/GopY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,HoTen,Email,TieuDe,NoiDung")] GopY gopy)
        {
            if (ModelState.IsValid)
            {
                db.Gopies.Add(gopy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gopy);
        }

        // GET: /admin/GopY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GopY gopy = db.Gopies.Find(id);
            if (gopy == null)
            {
                return HttpNotFound();
            }
            return View(gopy);
        }

        // POST: /admin/GopY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,HoTen,Email,TieuDe,NoiDung")] GopY gopy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gopy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gopy);
        }

        // GET: /admin/GopY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GopY gopy = db.Gopies.Find(id);
            if (gopy == null)
            {
                return HttpNotFound();
            }
            return View(gopy);
        }

        // POST: /admin/GopY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GopY gopy = db.Gopies.Find(id);
            db.Gopies.Remove(gopy);
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
