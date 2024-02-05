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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "10Off",
                DiscountAmount = 10,
                MinAmount = 20,
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "20Off",
                DiscountAmount = 20,
                MinAmount = 40,
            });
        }
    }
}
