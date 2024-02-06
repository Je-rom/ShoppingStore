using CouponWeb.Models;
using CouponWeb.Service.IService;

namespace CouponWeb.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
                
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            HttpClient client = _httpClientFactory.CreateClient("CouponApi");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");

            //token

            message.RequestUri = new Uri(requestDto.Url);
            if(requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/Json");
            }

        }

        public Task<ResponseDto?> SendAsync(ResponseDto responseDto)
        {
            throw new NotImplementedException();
        }
    }
}
