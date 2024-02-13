using CouponWeb.Service.IService;
using CouponWeb.Utility;
using Newtonsoft.Json.Linq;

namespace CouponWeb.Service
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }



        public void ClearToken()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(staticDetails.TokenCookie);
        }

        public string? GetToken()
        {
            string? token = null;

            bool? hasToken = _contextAccessor.HttpContext?.Request.Cookies.TryGetValue(staticDetails.TokenCookie, out token);

            return hasToken is true ? token : null;
        }

        public void SetToken(string token)
        {
            _contextAccessor.HttpContext?.Response.Cookies.Append(staticDetails.TokenCookie, token);
         
        }
    }
}
