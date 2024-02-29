using ShoppingCartApi.Models.DTO;

namespace ShoppingCartApi.Service.Iservice
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
