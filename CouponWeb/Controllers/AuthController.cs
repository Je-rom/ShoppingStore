using CouponWeb.Models;
using CouponWeb.Service.IService;
using CouponWeb.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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


        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponseDto responseDto = await _authservice.LoginAsync(obj);
            if(responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomerError", responseDto.Message);
                return View(obj);
            }
            
        }

        [HttpGet]
        public IActionResult Register()
        {

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text= staticDetails.RoleAdmin, Value=staticDetails.RoleAdmin},
                new SelectListItem{Text= staticDetails.RoleCustomer, Value=staticDetails.RoleCustomer},

            };
            ViewBag.RoleList = roleList;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto obj)
        {

            ResponseDto result = await _authservice.RegisterAsync(obj);
            ResponseDto assingRole;

            if(result != null && result.IsSuccess)
            {
                if(string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = staticDetails.RoleCustomer;
                }
                assingRole = await _authservice.AssignRoleAsync(obj); 
                if(assingRole != null && assingRole.IsSuccess) 
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
                }
            }
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text= staticDetails.RoleAdmin, Value="ADMIN"},
                new SelectListItem{Text= staticDetails.RoleCustomer, Value="CUSTOMER"},

            };
            ViewBag.RoleList = roleList;
            return View(obj);
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
