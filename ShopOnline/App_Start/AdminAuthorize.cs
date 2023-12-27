using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopOnline.App_Start
{
    public class AdminAuthorize: AuthorizeAttribute
    {
        public int ID { set; get; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // check session
            NHANVIEN nv = (NHANVIEN)HttpContext.Current.Session["user"];
           if(nv != null)
            {
                #region        //check quyen
                SHOPONLINEEntities db = new SHOPONLINEEntities();

                var count = db.PhanQuyens.Count(m => m.MaNV == nv.MaNV & m.ID == ID);
                if (count != 0)
                {
                    // bao khong co quyen
                    return;
                }
                else
                {
                    var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(
                        new
                        {
                            Controller = "BaoLoi",
                            action = "KhongCoQuyen",
                            area = "Admin",
                            returnUrl = returnUrl.ToString()
                        }));
                }
                #endregion

                return;
            }
           else
            {
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(
                    new { Controller = "admin",
                        action = "Login",
                        area = "Admin",
                        returnUrl = returnUrl.ToString()
                    }));
            }

        }
    }
}