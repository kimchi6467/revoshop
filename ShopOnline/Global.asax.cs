using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShopOnline
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        // xac thuc truy cap 
        protected void Session_Start()
        {
            if (Session["username"] == null)
            {
                // neu gia tri la null thi tra den trang admin
                HttpContext.Current.Response.Redirect("~/", false);

            }
            else
            {
                // gia tri tra ve trang quan tri sau k                   
                new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" }, { "controller", "Admin" } });
            }
        }
    }
}
