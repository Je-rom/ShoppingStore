using CouponWeb.Models;
using CouponWeb.Service.IService;
using CouponWeb.Utility;

namespace CouponWeb.Service
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;

        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.POST,
                Data = cartDto,
                Url = staticDetails.ShoppingCartAPIBase + "/api/cart/ApplyCoupon"
            });
        }

        public Task<ResponseDto?> EmailCart(CartDto cartDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetCartByUserIdAsnyc(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.GET,
                Url = staticDetails.ShoppingCartAPIBase + "/api/cart/GetCart/" + userId
            });
        }

        public async Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.POST,
                Data = cartDetailsId,
                Url = staticDetails.ShoppingCartAPIBase + "/api/cart/RemoveCart"
            });
        }

        public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.POST,
                Data = cartDto,
                Url = staticDetails.ShoppingCartAPIBase + "/api/cart/CartUpsert"
            });
        }
    }
}
