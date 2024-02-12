using User.AuthApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace User.AuthApi.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> //define the user
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //default setting required by entity framework core
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
