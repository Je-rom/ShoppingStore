using ShoppingCartApi.Models.Dto;

namespace ShoppingCartApi.Service.Iservice
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
