using CouponWeb.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CouponWeb.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
