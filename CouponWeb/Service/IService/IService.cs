using CouponWeb.Models;

namespace CouponWeb.Service.IService
{
    public interface IService
    {
       Task<ResponseDto?> SendAsync(ResponseDto responseDto);
    }
}
