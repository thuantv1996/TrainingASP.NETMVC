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
    public class AccountController : Controller
    {
        private LoginService loginService;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Login(LoginViewModel account)
        {
            loginService = new LoginImplement();
            if (loginService.CheckAccount(account))
            {
                return "Đăng nhập thành công";
            }
            else
            {
                return "Đăng nhập thất bại";
            }
        }
    }
}