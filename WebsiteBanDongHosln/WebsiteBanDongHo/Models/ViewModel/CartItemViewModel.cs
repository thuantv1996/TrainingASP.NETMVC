using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDongHo.Models.Context;

namespace WebsiteBanDongHo.Models.ViewModel
{
    [Serializable]
    public class CartItemViewModel
    {
        public SANPHAM product { get; set; }
        public int Quantity { get; set; }
    }
}