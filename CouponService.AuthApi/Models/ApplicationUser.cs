using Microsoft.AspNetCore.Identity;

namespace User.AuthApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
