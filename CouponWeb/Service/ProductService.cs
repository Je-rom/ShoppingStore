using CouponWeb.Models;
using CouponWeb.Service.IService;
using CouponWeb.Utility;


namespace ProductWeb.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }


        public async Task<ResponseDto?> CreateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.POST,
                Data = productDto,
                Url = staticDetails.ProductAPIBase + "/api/product"
            });
        }

        public async Task<ResponseDto?> DeleteProductsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.DELETE,
                Url = staticDetails.ProductAPIBase + "/api/product/"+ id

            });
        }

        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.GET,
                Url = staticDetails.ProductAPIBase + "/api/product"
                
            });
        }

      /*  public async Task<ResponseDto?> GetProductAsync(string productCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.GET,
                Url = staticDetails.ProductAPIBase + "/api/product/GetByCode/"+ productCode
            });
        }*/

        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.GET,
                Url = staticDetails.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDto?> UpdateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.PUT,
                Data = productDto,
                Url = staticDetails.ProductAPIBase + "/api/product"
            });
        }
    }
}
