﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.admin
{
    public class BaoLoiController : Controller
    {
        // GET: admin/BaoLoi
        public ActionResult KhongCoQuyen()
        {
            return View();
        }
    }
}