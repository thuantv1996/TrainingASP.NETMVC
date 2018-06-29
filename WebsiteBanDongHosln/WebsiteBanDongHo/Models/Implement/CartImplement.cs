using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDongHo.Models.Context;
using WebsiteBanDongHo.Models.Service;

namespace WebsiteBanDongHo.Models.Implement
{
    public class CartImplement : CartService
    {
        public SANPHAM GetProductByID(int id)
        {
            using (var db = new BANDONGHOEntities())
            {
                return db.SANPHAMs.Find(id);
            }
        }
    }
}