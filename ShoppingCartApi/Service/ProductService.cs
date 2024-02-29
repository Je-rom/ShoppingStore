using Newtonsoft.Json;
using ShoppingCartApi.Models.Dto;
using ShoppingCartApi.Models.DTO;
using ShoppingCartApi.Service.Iservice;

namespace ShoppingCartApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync($"api/product");
            var content = await response.Content.ReadAsStringAsync();
            var respons = JsonConvert.DeserializeObject<ResponseDto>(content);
            if (respons.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(respons.Result));
            }
            else
            {
                return new List<ProductDto>();
            }
        }
    }
}
