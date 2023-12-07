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
    public class NhaSanXuatController : Controller
    {
        private SHOPONLINEEntities db = new SHOPONLINEEntities();

        // GET: /admin/NhaSanXuat/
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            //return View(db.SACHes.ToList());
            return View(db.NHASANXUATs.ToList().OrderBy(n => n.MaNSX).ToPagedList(pageNumber, pageSize));
        }

        // GET: /admin/NhaSanXuat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHASANXUAT nhasanxuat = db.NHASANXUATs.Find(id);
            if (nhasanxuat == null)
            {
                return HttpNotFound();
            }
            return View(nhasanxuat);
        }

        // GET: /admin/NhaSanXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /admin/NhaSanXuat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaNSX,TenNSX,meta,Diachi,DienThoai")] NHASANXUAT nhasanxuat)
        {
            if (ModelState.IsValid)
            {
                db.NHASANXUATs.Add(nhasanxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhasanxuat);
        }

        // GET: /admin/NhaSanXuat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHASANXUAT nhasanxuat = db.NHASANXUATs.Find(id);
            if (nhasanxuat == null)
            {
                return HttpNotFound();
            }
            return View(nhasanxuat);
        }

        // POST: /admin/NhaSanXuat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaNSX,TenNSX,meta,Diachi,DienThoai")] NHASANXUAT nhasanxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhasanxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhasanxuat);
        }

        // GET: /admin/NhaSanXuat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHASANXUAT nhasanxuat = db.NHASANXUATs.Find(id);
            if (nhasanxuat == null)
            {
                return HttpNotFound();
            }
            return View(nhasanxuat);
        }

        // POST: /admin/NhaSanXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHASANXUAT nhasanxuat = db.NHASANXUATs.Find(id);
            db.NHASANXUATs.Remove(nhasanxuat);
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
