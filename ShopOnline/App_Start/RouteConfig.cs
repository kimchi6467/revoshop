using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Product", "{type}/{meta}",
                new { controller = "Product", action = "Index", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "san-pham" }
                },
              namespaces:  new[] { "ShopOnline.Controllers" });

            routes.MapRoute("Detail", "{type}/{meta}/{id}",
                new { controller = "Product", action = "Details", id = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "san-pham" }
                },
              namespaces:  new[] { "ShopOnline.Controllers" });



            routes.MapRoute("TinTuc", "{type}/{meta}",
                new { controller = "TinTuc", action = "Index", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "tin-tuc" }
                },
              namespaces: new[] { "ShopOnline.Controllers" });

            routes.MapRoute("Chitietbaiviet", "{type}/{meta}/{id}",
                new { controller = "TinTuc", action = "Details", id = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type", "tin-tuc" }
                },
              namespaces: new[] { "ShopOnline.Controllers" });

            routes.MapRoute(
             name: "lienhe",
             url: "lien-he/",
             defaults: new { controller = "LienHe", action = "Index" },
             namespaces: new[] { "ShopOnline.Controllers" });

            routes.MapRoute(
             name: "gioithieu",
             url: "gioi-thieu/",
             defaults: new { controller = "GioiThieu", action = "Index" },
             namespaces: new[] { "ShopOnline.Controllers" });

            routes.MapRoute(
             name: "Search",
             url: "search/",
             defaults: new { controller = "Search", action = "Search" },
             namespaces: new[] { "ShopOnline.Controllers" });

            routes.MapRoute(
          name: "GioHang",
          url: "gio-hang",
          defaults: new { controller = "GioHang", action = "GioHang", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
          name: "payment",
          url: "thanh-toan",
          defaults: new { controller = "GioHang", action = "Payment", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
          name: "payment Success",
          url: "hoan-thanh",
          defaults: new { controller = "GioHang", action = "Success", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
          name: "payment UnSuccess",
          url: "loi-thanh-toan",
          defaults: new { controller = "GioHang", action = "UnSuccess", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
