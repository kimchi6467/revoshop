using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    [Serializable]
    public class GioHangItem
    {
        public SANPHAM SANPHAM { set; get; }
        public int SoLuong { set; get; }
        public int Size { set; get; }
    }
}