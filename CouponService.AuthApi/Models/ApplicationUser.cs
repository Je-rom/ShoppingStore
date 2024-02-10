using Microsoft.AspNetCore.Identity;

namespace CouponService.AuthApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
