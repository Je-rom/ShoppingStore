using Newtonsoft.Json;
using ShoppingCartApi.Models.DTO;
using ShoppingCartApi.Service.Iservice;

namespace ShoppingCartApi.Service
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public CouponService(IHttpClientFactory ClientFactory)
        {
            _httpClientFactory = ClientFactory;
        }
        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupon");
            var response = await client.GetAsync($"/api/coupon/GetByCode/{couponCode}");
            var content = await response.Content.ReadAsStringAsync();
            var respons = JsonConvert.DeserializeObject<ResponseDto>(content);
            if (respons.IsSuccess && respons!=null)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(respons.Result));
            }
            else
            {
                return new CouponDto();
            }
        }
    }
}
