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

namespace ShopOnline.Areas.admin.Controllers
{
    public class QuanLyQuangCaoController : Controller
    {
        private SHOPONLINEEntities db = new SHOPONLINEEntities();

        // GET: /admin/QuanLyQuangCao/
        public ActionResult Index()
        {
            return View(db.QUANGCAOS.ToList());
        }

        // GET: /admin/QuanLyQuangCao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANGCAO quangcao = db.QUANGCAOS.Find(id);
            if (quangcao == null)
            {
                return HttpNotFound();
            }
            return View(quangcao);
        }

        // GET: /admin/QuanLyQuangCao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /admin/QuanLyQuangCao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,slider1,linkslider1,slider2,linkslider2,slider3,linkslider3")] QUANGCAO quangcao)
        {
            if (ModelState.IsValid)
            {
                db.QUANGCAOS.Add(quangcao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quangcao);
        }

        // GET: /admin/QuanLyQuangCao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANGCAO quangcao = db.QUANGCAOS.Find(id);
            if (quangcao == null)
            {
                return HttpNotFound();
            }
            return View(quangcao);
        }

        // POST: /admin/QuanLyQuangCao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,slider1,linkslider1,slider2,linkslider2,slider3,linkslider3")] QUANGCAO quangcao, HttpPostedFileBase fileUpload)
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
                    quangcao.slider1 = fileName;
                    quangcao.slider2 = fileName;
                    quangcao.slider3 = fileName;
                    db.Entry(quangcao).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(quangcao);
            }
        }

        // GET: /admin/QuanLyQuangCao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANGCAO quangcao = db.QUANGCAOS.Find(id);
            if (quangcao == null)
            {
                return HttpNotFound();
            }
            return View(quangcao);
        }

        // POST: /admin/QuanLyQuangCao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QUANGCAO quangcao = db.QUANGCAOS.Find(id);
            db.QUANGCAOS.Remove(quangcao);
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
