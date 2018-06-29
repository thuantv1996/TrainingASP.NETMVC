using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDongHo.Models.Context;
using WebsiteBanDongHo.Models.Service;

namespace WebsiteBanDongHo.Models.Implement
{
    public class DetailImplement : DetailService
    {
        public SANPHAM GetProductByID(int id)
        {
            using (var db = new BANDONGHOEntities())
            {
                return db.SANPHAMs.Where(n => n.MASP == id).FirstOrDefault();
            }
        }
    }
}