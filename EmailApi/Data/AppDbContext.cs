using EmailApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmailLogger> EmailLoggers { get; set; }

    }
}
