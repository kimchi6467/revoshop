using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;
using PagedList;
using PagedList.Mvc;


namespace ShopOnline.Areas.admin.Controllers
{
    public class TinTucController : Controller
    {
        private SHOPONLINEEntities db = new SHOPONLINEEntities();

        // GET: /admin/TinTuc/
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            //return View(db.SACHes.ToList());
            return View(db.TinTucs.ToList().OrderBy(n => n.MaTinTuc).ToPagedList(pageNumber, pageSize));
        }

        // GET: /admin/TinTuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tintuc = db.TinTucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // GET: /admin/TinTuc/Create
        public ActionResult Create()
        {
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai");
            return View();
        }

        // POST: /admin/TinTuc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "MaTinTuc,TenTinTuc,NoiDungChiTiet,HinhANh,NgayCapNhat,MaTheLoai,meta")] TinTuc tintuc, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn hình ảnh sản phẩm";
                return View();
            }
            //Them vao CSDL
            else
            {
                if (ModelState.IsValid)
                {
                    //Luu ten fie, luu y bo sung thu vien using System.IO;
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/Hinhsanpham"), fileName);
                    //Kiem tra hình anh ton tai chua?
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        //Luu hinh anh vao duong dan
                        fileUpload.SaveAs(path);
                    }
                    tintuc.HinhANh = fileName;
                    db.TinTucs.Add(tintuc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", tintuc.MaTheLoai);
                return View(tintuc);
            }
        }
    

        // GET: /admin/TinTuc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tintuc = db.TinTucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", tintuc.MaTheLoai);
            return View(tintuc);
        }

        // POST: /admin/TinTuc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MaTinTuc,TenTinTuc,NoiDungChiTiet,HinhANh,NgayCapNhat,MaTheLoai,meta")] TinTuc tintuc, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", tintuc.MaTheLoai);
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn hình ảnh tin tức";
                return View();
            }
            //Them vao CSDL
            else
            {
                if (ModelState.IsValid)
                {
                    //Luu ten fie, luu y bo sung thu vien using System.IO;
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/Hinhsanpham"), fileName);
                    //Kiem tra hình anh ton tai chua?
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        //Luu hinh anh vao duong dan
                        fileUpload.SaveAs(path);
                    }
                    tintuc.HinhANh = fileName;
                    db.Entry(tintuc).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", tintuc.MaTheLoai);
                return View(tintuc);
            }
        }
    

        // GET: /admin/TinTuc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tintuc = db.TinTucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: /admin/TinTuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinTuc tintuc = db.TinTucs.Find(id);
            db.TinTucs.Remove(tintuc);
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
