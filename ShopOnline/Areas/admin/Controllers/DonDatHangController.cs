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
    public class DonDatHangController : Controller
    {
        private SHOPONLINEEntities db = new SHOPONLINEEntities();

        // GET: /admin/DonDatHang/
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            //return View(db.SACHes.ToList());
            return View(db.DONDATHANGs.ToList().OrderBy(n => n.MaDonHang).ToPagedList(pageNumber, pageSize));
        }

        // GET: /admin/DonDatHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dondathang = db.DONDATHANGs.Find(id);
            if (dondathang == null)
            {
                return HttpNotFound();
            }
            return View(dondathang);
        }

        // GET: /admin/DonDatHang/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen");
            return View();
        }

        // POST: /admin/DonDatHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaDonHang,Dathanhtoan,Tinhtranggiaohang,Ngaydat,Ngaygiao,MaKH")] DONDATHANG dondathang)
        {
            if (ModelState.IsValid)
            {
                db.DONDATHANGs.Add(dondathang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", dondathang.MaKH);
            return View(dondathang);
        }

        // GET: /admin/DonDatHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dondathang = db.DONDATHANGs.Find(id);
            if (dondathang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", dondathang.MaKH);
            return View(dondathang);
        }

        // POST: /admin/DonDatHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaDonHang,Dathanhtoan,Tinhtranggiaohang,Ngaydat,Ngaygiao,MaKH")] DONDATHANG dondathang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dondathang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "HoTen", dondathang.MaKH);
            return View(dondathang);
        }

        // GET: /admin/DonDatHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dondathang = db.DONDATHANGs.Find(id);
            if (dondathang == null)
            {
                return HttpNotFound();
            }
            return View(dondathang);
        }

        // POST: /admin/DonDatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONDATHANG dondathang = db.DONDATHANGs.Find(id);
            db.DONDATHANGs.Remove(dondathang);
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

        // chi tiết đơn hàng
        public ActionResult ChiTiet(int? page)
        {
            {
                int pageNumber = (page ?? 1);
                int pageSize = 10;
                //return View(db.SACHes.ToList());
                return View(db.DONHANGs.ToList().OrderBy(n => n.MaDH).ToPagedList(pageNumber, pageSize));
            }
        }
    }
}
