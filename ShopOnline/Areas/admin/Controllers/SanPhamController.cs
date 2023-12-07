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
    public class SanPhamController : Controller
    {
        SHOPONLINEEntities db = new SHOPONLINEEntities();
        // GET: /admincp/SanPham/
        // phân trang 
        //public ActionResult Index(int ? page)
        //{
        //    //Tao bien quy dinh so san pham tren moi trang
        //    int pageSize = 5;
        //    //Tao bien so trang
        //    int pageNum = (page ?? 1);
        //    var sanphams = db.SANPHAMs.Include(s => s.DANHMUC).Include(s => s.NHASANXUAT);
        //    return View(sanphams.ToPagedList(pageNum,pageSize));
        //}

        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            //return View(db.SACHes.ToList());
            return View(db.SANPHAMs.ToList().OrderBy(n => n.MaSANPHAM).ToPagedList(pageNumber, pageSize));
        }

        // GET: /admincp/SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sanpham = db.SANPHAMs.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: /admincp/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DANHMUCs, "MaDM", "TenDANHMUC");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs, "MaNSX", "TenNSX");
            return View();
        }

        // POST: /admincp/SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSANPHAM,TenSANPHAM,meta,Giaban,GioiThieu,Mota,HinhAnh,HinhAnh1,HinhAnh2,Ngaycapnhat,Soluongton,MaDM,MaNSX")]SANPHAM sanpham, HttpPostedFileBase fileUpload)
        {

            //Dua du lieu vao dropdownload
            ViewBag.MaDM = new SelectList(db.DANHMUCs, "MaDM", "TenDANHMUC", sanpham.MaDM);
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs, "MaNSX", "TenNSX", sanpham.MaNSX);
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
                    sanpham.HinhAnh = fileName;
                    sanpham.HinhAnh1 = fileName;
                    sanpham.HinhAnh2 = fileName;
                    //Luu vao CSDL   
                    db.SANPHAMs.Add(sanpham);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.MaDM = new SelectList(db.DANHMUCs, "MaDM", "TenDANHMUC", sanpham.MaDM);
                ViewBag.MaNSX = new SelectList(db.NHASANXUATs, "MaNSX", "TenNSX", sanpham.MaNSX);
                return View(sanpham);
            }

        }

        // GET: /admincp/SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sanpham = db.SANPHAMs.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DANHMUCs, "MaDM", "TenDANHMUC", sanpham.MaDM);
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs, "MaNSX", "TenNSX", sanpham.MaNSX);
            return View(sanpham);
        }

        // POST: /admincp/SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(SANPHAM sanpham, HttpPostedFileBase fileUpload)
        {
            //Dua du lieu vao dropdownload
            ViewBag.MaDM = new SelectList(db.DANHMUCs, "MaDM", "TenDANHMUC", sanpham.MaDM);
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs, "MaNSX", "TenNSX", sanpham.MaNSX);
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
                    sanpham.HinhAnh = fileName;
                    //Luu vao CSDL   
                    db.Entry(sanpham).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            //if (ModelState.IsValid)
            //{
            //    db.Entry(sanpham).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");

            //}
            //ViewBag.MaDM = new SelectList(db.DANHMUCs, "MaDM", "TenDANHMUC", sanpham.MaDM);
            //ViewBag.MaNSX = new SelectList(db.NHASANXUATs, "MaNSX", "TenNSX", sanpham.MaNSX);
            //return View(sanpham);
        }


        // GET: /admincp/SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sanpham = db.SANPHAMs.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: /admincp/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANPHAM sanpham = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sanpham);
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
