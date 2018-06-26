using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanDongHo.Models.Context;

namespace WebsiteBanDongHo.Models.Service
{
    interface HomeService
    {
        List<SANPHAM> GetNewProducts(int number);
        List<SANPHAM> GetSaveProducts(int number);
    }
}
