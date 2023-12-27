using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;
using ShopOnline.App_Start;
namespace ShopOnline.Areas.admin.Controllers
{
    public class NhanVienController : Controller
    {

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
        [AdminAuthorize(ID = 1)]
        public ActionResult DanhSach()
        {
            //if(KiemTraChucNang(1) == false)
            //{
            //    return Redirect("/admin/BaoLoi/KhongCoQuyen");
            //}
           
            return View();
        }
        [AdminAuthorize(ID = 2)]
        public ActionResult ThemMoi()
        {
            //if (KiemTraChucNang(2) == false)
            //{
            //    return Redirect("/admin/BaoLoi/KhongCoQuyen");
            //}

            return View();
        }
        [AdminAuthorize(ID = 3)]
        public ActionResult CapNhap()
        {
            //if (KiemTraChucNang(3) == false)
            //{
            //    return Redirect("/admin/BaoLoi/KhongCoQuyen");
            //}

            return View();
        }
        [AdminAuthorize(ID = 4)]
        public ActionResult Xoa()
        {
            //if (KiemTraChucNang(4) == false)
            //{
            //    return Redirect("/admin/BaoLoi/KhongCoQuyen");
            //}

            return View();
        }
    }
}