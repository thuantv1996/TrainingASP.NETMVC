using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDongHo.Models.ViewModel;
using WebsiteBanDongHo.Models.Service;
using WebsiteBanDongHo.Models.Implement;

namespace WebsiteBanDongHo.Controllers
{
    public class DetailController : Controller
    {
        //khai báo và khởi tạo ViewModel
        DetailViewModel detailViewModel = new DetailViewModel();
        DetailService detailService;
        // GET: Detail
        public ActionResult Index(int id)
        {
            //khởi tạo service
            detailService = new DetailImplement();
            //gán giá trị cho ViewModel
            detailViewModel.product = detailService.GetProductByID(id);
            //gửi ViewModel ra View
            return View(detailViewModel);
        }
    }
}