using ServiceEmailApi;
using Microsoft.EntityFrameworkCore;
using ServiceEmailApi.Models;

namespace ServiceEmailApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //default setting required by entity framework core
        {

        }

        public DbSet<EmailLogger> EmailLoggers {get; set;}

    }
}
