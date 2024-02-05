using CouponServices.Models;
using Microsoft.EntityFrameworkCore;

namespace CouponServices.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //default setting required by entity framework core
        {

        }

        public DbSet<Coupon> Coupons {get; set;}
    }
}
