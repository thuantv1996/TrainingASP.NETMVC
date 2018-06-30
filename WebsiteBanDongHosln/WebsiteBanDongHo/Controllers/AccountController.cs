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

        public ActionResult Register()
        {
            RegisterViewModel register = new RegisterViewModel();
            ViewBag.MessageRegister = "";
            return View(register);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel register)
        {
            ViewBag.MessageRegister = "";
            RegisterImplement registerService = new RegisterImplement();
            if (ModelState.IsValid)
            {
                if (registerService.isExistAccount(register.Username))
                {
                    register.Username = "";
                    ViewBag.MessageRegister += "Tài khoản đã tồn tại !";
                    return View(register);
                }
                else
                {
                    if (registerService.Register(register))
                    {
                        ViewBag.MessageRegister += "Đăng ký thành công !";
                    }
                    else
                    {
                        ViewBag.MessageRegister += "Đăng ký thất bại !";
                    }                
                }
            }
            return View(register);
        }
    }
}