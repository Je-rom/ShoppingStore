using Microsoft.EntityFrameworkCore;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //default setting required by entity framework core
        {

        }

        public DbSet<CartHeader> CartHeaders { get; set;}
        public DbSet<CartDetails> CartDetails { get; set;}

    /*    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }*/
    }
}
