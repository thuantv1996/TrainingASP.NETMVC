using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDongHo.Models.Context;

namespace WebsiteBanDongHo.Models.Service
{
    interface DetailService
    {
        SANPHAM GetProductByID(int id);
    }
}