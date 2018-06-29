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
    public class CartController : Controller
    {
        private const string CartSession = "CartSession"; //chuỗi string này là tên hay còn gọi là key của SESSION
        CartItemViewModel cartItemViewModel = new CartItemViewModel();
        CartService cartService;
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession]; //Lấy đối tượng session, mỗi session có key riêng do ta định trước nên ta phải truyền vào chính xác.
            var list = new List<CartItemViewModel>();
            if (cart != null)
            {
                list = (List<CartItemViewModel>)cart;
            }
            return View(list);
        }

        //Action thêm sản phẩm và số lượng vào Session[CartSession]
        public ActionResult AddItem(int productId, int quantity)
        {
            cartService = new CartImplement();
            var product = cartService.GetProductByID(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItemViewModel>)cart;
                if (list.Exists(x => x.product.MASP == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.product.MASP == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItemViewModel();
                    item.product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItemViewModel();
                item.product = product;
                item.Quantity = quantity;
                var list = new List<CartItemViewModel>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        //Action cập nhập số lượng sản phẩm trong Session[CartSession]
        public string Update(int id, int quantity)
        {
            var sessionCart = (List<CartItemViewModel>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                if(item.product.MASP == id)
                {
                    item.Quantity = quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return "Ok";
        }

        //Action xóa sản phẩm trong Session[CartSession]
        public string Delete(int id)
        {
            var sessionCart = (List<CartItemViewModel>)Session[CartSession];
            sessionCart.RemoveAll(n => n.product.MASP == id);
            return "Ok";
        }
    }
}