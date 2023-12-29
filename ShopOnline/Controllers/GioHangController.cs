using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;
using System.Configuration;
using System.Web.Script.Serialization;
using Common;
using PayPal.Api;

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
        public ActionResult ThemGiohang(int iMaSANPHAM, string strURL)
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
                ctdh.MaSize = item.iSIZE;
              

                ctdh.Dongia = (decimal)item.dDongia;
                db.CHITIETDONDATHANGs.Add(ctdh);

                
            }
            
  

                db.SaveChanges();
            Session["Giohang"] = null;
            return RedirectToAction("Xacnhandonhang", "GioHang");

        }
        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            //getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/GioHang/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("UnSuccess");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("UnSuccess");
            }
            DONDATHANG ddh = new DONDATHANG();
            KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
            List<Giohang> gh = Laygiohang();
            ddh.MaKH = kh.MaKH;
            //ddh.Ngaydat = DateTime.Now;
            //var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["Ngaygiao"]);
            //ddh.Ngaygiao = DateTime.Parse(ngaygiao);
            ddh.Tinhtranggiaohang = true;
            ddh.Dathanhtoan = true;
            db.DONDATHANGs.Add(ddh);
            db.SaveChanges();
            List<Giohang> lstGiohang = Laygiohang();
            foreach (var item in lstGiohang)
            {
                var ChiTietDonHang = new CHITIETDONDATHANG();
                ChiTietDonHang.MaSANPHAM = item.iMaSANPHAM;
                //ChiTietDonHang.MaCTDH = maDH;
                //ChiTietDonHang.Dongia = item.dDongia;
                ChiTietDonHang.Soluong = item.iSoluong;


                //total += (item.dDongia.GetValueOrDefault(0) * item.iSoluong);
                //total = @String.Format("{0:0,0}", ViewBag.Tongtien);

            }



            db.SaveChanges();
            Session["Giohang"] = null;
            return RedirectToAction("Xacnhandonhangonline", "GioHang");
            //on successful payment, show success page to user.  
            //return View("Success");
        }
        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listSanPham = Session["Giohang"] as List<Giohang>;
            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            foreach (var item in listSanPham)
            {
                itemList.items.Add(new Item()
                {
                    name = item.sTenSANPHAM,
                    currency = "USD",
                    price = item.dDongia.ToString(),
                    quantity = item.iSoluong.ToString(),
                    sku = item.iMaSANPHAM.ToString()
                });

            }
            
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = listSanPham.Sum(n => n.dThanhtien).ToString()
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = listSanPham.Sum(n => n.dThanhtien).ToString(), // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            var paypalOrderId = DateTime.Now.Ticks;
            transactionList.Add(new Transaction()
            {
                description = $"Invoice #{paypalOrderId}",
                invoice_number = paypalOrderId.ToString(), //Generate an Invoice No    
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
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
                    if (lstGiohang != null )
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
                    ChiTietDonHang.MaCTDH = (int)maDH;
                    ChiTietDonHang.Dongia = (decimal?)item.dDongia;
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
        public ActionResult Xacnhandonhangonline()
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