using CouponWeb.Models;

namespace CouponWeb.Service.IService
{
    public interface ICartService
    {
        Task<ResponseDto> GetCartByUserIdAsync(string UserId);
    }
}
