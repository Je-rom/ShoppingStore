using CouponWeb.Models;
using CouponWeb.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CouponWeb.Controllers
{
    public class CouponController : Controller
    {

        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();

            ResponseDto? response = await _couponService.GetAllCouponsAsync();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
