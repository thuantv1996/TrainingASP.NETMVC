using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDongHo.Models.Implement;
using WebsiteBanDongHo.Models.Service;
using WebsiteBanDongHo.Models.ViewModel;

namespace WebsiteBanDongHo.Controllers
{
    public class HomeController : Controller
    {
        // Số lượng sản phẩm mới lấy ra
        const int NUMBER_NEW_PRODUCTS = 4;
        // Số lượng sản phẩm rẽ lấy ra
        const int NUMBER_SAVE_PRODUCTS = 4;
        // Khai báo và khởi tạo ViewModel
        HomeViewModel ViewModel = new HomeViewModel();
        HomeService Service;
        // GET: Home
        public ActionResult Index()
        {
            // Khởi tạo service
            Service = new HomeImplement();
            // Gán giá trị ViewModel
            ViewModel.NewProducts = Service.GetNewProducts(NUMBER_NEW_PRODUCTS);
            ViewModel.SaveProducts = Service.GetSaveProducts(NUMBER_SAVE_PRODUCTS);
            // Gửi ViewModel ra View
            return View(ViewModel);
        }
    }
}