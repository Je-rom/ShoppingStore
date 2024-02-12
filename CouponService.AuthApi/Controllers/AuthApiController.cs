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
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDto) 
        {
            var errorMessage = await _authService.Register(registrationRequestDto);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if(loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}
