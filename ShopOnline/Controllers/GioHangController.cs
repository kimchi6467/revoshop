using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;
using System.Configuration;
using System.Web.Script.Serialization;
using Common;

namespace ShopOnline.Controllers
{
    public class GioHangController : Controller
    {

        //
        // GET: /GioHang/
        //Tao doi tuong db chua dữ liệu từ model dbBansach đã tạo. 
        SHOPONLINEEntities db = new SHOPONLINEEntities();

        private const string GioHangSession = "GioHangSession";
       
        //Lay gio hang
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang == null)
            {
                //Neu gio hang chua ton tai thi khoi tao listGiohang
                lstGiohang = new List<Giohang>();
                Session["Giohang"] = lstGiohang;    
            }
            return lstGiohang;
        }
        //Them hang vao gio
        public ActionResult ThemGiohang(int iMaSANPHAM, int iSoLuong, string strURL)
        {
            //Lay ra Session gio hang
            List<Giohang> lstGiohang = Laygiohang();
            //Kiem tra sách này tồn tại trong Session["Giohang"] chưa?
            Giohang sanpham = lstGiohang.Find(n => n.iMaSANPHAM == iMaSANPHAM);
            if (sanpham == null )
            {
                sanpham = new Giohang(iMaSANPHAM);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);

            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }


        //Xay dung trang Gio hang
        public ActionResult GioHang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(lstGiohang);
        }
        //Tong so luong
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            
            List<Giohang> lstGiohang = Session["GioHang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTongSoLuong = lstGiohang.Sum(n => n.iSoluong);
               
            }
            return iTongSoLuong ;
        }
        //Tinh tong tien
        private double TongTien()
        {
            double iTongTien = 0;
            List<Giohang> lstGiohang = Session["GioHang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTongTien = lstGiohang.Sum(n => n.dThanhtien);
            }
            return iTongTien;
        }
        //Tao Partial view de hien thi thong tin gio hang
        public ActionResult GiohangPartial()
        {          
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return PartialView();
        }

        // gio hang icon
        //public ActionResult GioHangicon()
        //{
        //    List<Giohang> lstGiohang = Laygiohang();
        //    if (lstGiohang.Count == 0)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    ViewBag.Tongsoluong = TongSoLuong();
        //    ViewBag.Tongtien = TongTien();
        //    return PartialView(lstGiohang);
        //}

        
        

        //Cap nhat Giỏ hàng
        public ActionResult CapnhatGiohang(int iMaSP, FormCollection f)
        {

            //Lay gio hang tu Session
            List<Giohang> lstGiohang = Laygiohang();
            //Kiem tra sach da co trong Session["Giohang"]
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.iMaSANPHAM == iMaSP);
            //Neu ton tai thi cho sua Soluong
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("Giohang");
        }
        //Xoa Giohang
        public ActionResult XoaGiohang(int iMaSP)
        {
            //Lay gio hang tu Session
            List<Giohang> lstGiohang = Laygiohang();
            //Kiem tra sach da co trong Session["Giohang"]
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.iMaSANPHAM == iMaSP);
            //Neu ton tai thi cho sua Soluong
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.iMaSANPHAM == iMaSP);
                return RedirectToAction("GioHang");

            }
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        //Xoa tat ca thong tin trong Gio hang
        public ActionResult XoaTatcaGiohang()
        {
            //Lay gio hang tu Session
            List<Giohang> lstGiohang = Laygiohang();
            lstGiohang.Clear();
            return RedirectToAction("Index", "Home");
        }

        //Hien thi View DatHang de cap nhat cac thong tin cho Don hang
        [HttpGet]
        public ActionResult DatHang()
        {
            //Kiem tra dang nhap
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "Members");
            }
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //Lay gio hang tu Session
            List<Giohang> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();

            return View(lstGiohang);
        }
        //Xay dung chuc nang Dathang
        [HttpPost]
        public ActionResult DatHang(FormCollection collection)
        {
            //Them Don hang
            DONDATHANG ddh = new DONDATHANG();
            KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
            List<Giohang> gh = Laygiohang();
            ddh.MaKH = kh.MaKH;
            //ddh.Ngaydat = DateTime.Now;
            //var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["Ngaygiao"]);
            //ddh.Ngaygiao = DateTime.Parse(ngaygiao);
            ddh.Tinhtranggiaohang = false;
            ddh.Dathanhtoan = false;
            db.DONDATHANGs.Add(ddh);
            db.SaveChanges();
            //Them chi tiet don hang            
            foreach (var item in gh)
            {
                CHITIETDONDATHANG ctdh = new CHITIETDONDATHANG();
                ctdh.MaDonHang = ddh.MaDonHang;
                ctdh.MaSANPHAM = item.iMaSANPHAM;
                ctdh.Soluong = item.iSoluong;
              

                ctdh.Dongia = (decimal)item.dDongia;
                db.CHITIETDONDATHANGs.Add(ctdh);

                
            }
  

                db.SaveChanges();
            Session["Giohang"] = null;
            return RedirectToAction("Xacnhandonhang", "GioHang");

        }

        //----------Cap nhap gio hang--------------------
        public JsonResult Update(string GioHang)
        {

            var jsonGioHang = new JavaScriptSerializer().Deserialize<List<GioHangItem>>(GioHang);
            //var SessionGioHang = (List<GioHangItem>)Session[GioHangSession];
            List<Giohang> lstGiohang = Laygiohang();



            foreach (var item in lstGiohang)
            {
                foreach (var jitem in jsonGioHang)
                {
                    if (lstGiohang != null)
                    {
                        item.iSoluong = jitem.SoLuong;
                        
                    }
                }
            }
            Session[GioHangSession] = lstGiohang;
            return Json(new
            {
                status = true
            });
        }

        //----------xoa tat ca--------------------

        public JsonResult DeleteAll()
        {
            Session["Giohang"] = null;
            return Json(new
            {
                status = true
            });
        }

        //-----------------Thanh toan----------------------
        [HttpGet]
        public ActionResult Payment()
        {
            List<Giohang> lstGiohang = Laygiohang();
            var list = new List<Giohang>();
            if (lstGiohang != null)
            {
                list = (List<Giohang>)lstGiohang;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string HoTen, string DienthoaiKH, string DiachiKH, string Email)
        {
            var donhang = new DONHANG();
            donhang.Ngaydat = DateTime.Now;
            donhang.DiaChiKH = DiachiKH;
            donhang.SodtKH = DienthoaiKH;
            donhang.HoTenKH = HoTen;
            donhang.EmailKH = Email;

            try
            {
                var maDH = new DonHangDao().Insert(donhang);
                List<Giohang> lstGiohang = Laygiohang();
                var ChiTietDao = new ChiTietDonHangDao();
                decimal total = 0;
                foreach (var item in lstGiohang)
                {
                    var ChiTietDonHang = new CHITIETDONDATHANG();
                    ChiTietDonHang.MaSANPHAM = item.iMaSANPHAM;
                    //ChiTietDonHang.MaCTDH = maDH;
                    //ChiTietDonHang.Dongia = item.dDongia;
                    ChiTietDonHang.Soluong = item.iSoluong;
                    ChiTietDao.Insert(ChiTietDonHang);

                    //total += (item.dDongia.GetValueOrDefault(0) * item.iSoluong);
                    //total = @String.Format("{0:0,0}", ViewBag.Tongtien);

                }

                string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/neworder.html"));

                content = content.Replace("{{CustomerName}}", HoTen);
                content = content.Replace("{{Phone}}", DienthoaiKH);
                content = content.Replace("{{Email}}", Email);
                content = content.Replace("{{Address}}", DiachiKH);
                //content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(Email, "Đơn hàng mới từ OnlineShop", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);

            }
            catch (Exception ex)
            {
                //ghi log
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult UnSuccess()
        {
            return View();
        }

        public ActionResult Xacnhandonhang()
        {
            return View();
        }

    }
}