using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;
using ShopOnline.App_Start;
using PagedList;
using System.Net;
using System.Data.Entity;

namespace ShopOnline.Areas.admin.Controllers
{
    public class NhanVienController : Controller
    {
        private SHOPONLINEEntities db = new SHOPONLINEEntities();

        //public bool KiemTraChucNang(int ID)
        //{
        //    SHOPONLINEEntities db = new SHOPONLINEEntities();
        //    NHANVIEN nv = (NHANVIEN)Session["user"];
        //    var count = db.PhanQuyens.Count(m => m.MaNV == nv.MaNV & m.ID == ID);
        //    if (count == 0)
        //    {
        //        // bao khong co quyen
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        // GET: admin/NhanVien

        // trang danh sach
        [AdminAuthorize(ID = 1)]
        public ActionResult DanhSach(int? page)
        {
            //if(KiemTraChucNang(1) == false)
            //{
            //    return Redirect("/admin/BaoLoi/KhongCoQuyen");
            //}
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            //return View(db.SACHes.ToList());
            return View(db.NHANVIENs.ToList().OrderBy(n => n.MaNV).ToPagedList(pageNumber, pageSize));


        }

        // Them moi
        [AdminAuthorize(ID = 2)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /admin/KhachHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoTen,Taikhoan,Matkhau,Email,DiachiNV,DienthoaiNV,Ngaysinh")] NHANVIEN nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }

            return View(nhanvien);
        }

        // chi tiet
        [AdminAuthorize(ID = 3)]
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nhanvien = db.NHANVIENs.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }
        // xoa
        [AdminAuthorize(ID = 4)]
        public ActionResult Xoa(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nhanvien = db.NHANVIENs.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // POST: /admin/KhachHang/Delete/5
        [HttpPost, ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHANVIEN nhanvien = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nhanvien);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }


        // chinh sua
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nhanvien = db.NHANVIENs.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // POST: /admin/KhachHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoTen,Taikhoan,Matkhau,Email,DiachiNV,DienthoaiNV,Ngaysinh")] NHANVIEN nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View(nhanvien);
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
