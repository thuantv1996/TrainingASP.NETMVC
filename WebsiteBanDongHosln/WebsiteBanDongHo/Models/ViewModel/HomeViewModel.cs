using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDongHo.Models.Context;
namespace WebsiteBanDongHo.Models.ViewModel
{
    public class HomeViewModel
    {
        public List<SANPHAM> NewProducts { get; set; }
        public List<SANPHAM> SaveProducts { get; set; }

    }
}