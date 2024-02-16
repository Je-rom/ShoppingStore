using CouponWeb.Models;

namespace CouponWeb.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetProductAsync(string productId);
        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductsAsync(ProductDto productDto);
        Task<ResponseDto?> UpdateProductsAsync(ProductDto productDto);
        Task<ResponseDto?> DeleteProductsAsync(int id);
    }
}
