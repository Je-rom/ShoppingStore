using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.AuthApi.Models.DTO;
using User.AuthApi.Service.IService;

namespace CouponService.AuthApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {

        private readonly IAuthService _authService;
        protected ResponseDto _response;

        public AuthApiController(IAuthService authService)
        {
            _authService = authService; 
            _response = new();
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Regsiter()
        {
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
