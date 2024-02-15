using CouponWeb.Models;
using CouponWeb.Service.IService;
using CouponWeb.Utility;

namespace CouponWeb.Service
{
    public class AuthService : IAuthService
    {

        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.POST,
                Data = registrationRequestDto,
                Url = staticDetails.AuthAPIBase + "/api/auth/AssignRole"
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.POST,
                Data = loginRequestDto,
                Url = staticDetails.AuthAPIBase + "/api/auth/login"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.POST,
                Data = registrationRequestDto,
                Url = staticDetails.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }
    }
}
