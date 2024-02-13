using CouponWeb.Models;
using CouponWeb.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CouponWeb.Controllers
{
    public class AuthController : Controller
    {

        private readonly IAuthService _authservice;
        public AuthController(IAuthService authService)
        {
                _authservice = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
