using Microsoft.EntityFrameworkCore;
using Portal.Services.HRAPI.Model;

namespace Portal.Services.HRAPI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<HumanResource> HumanResource { get; set; }

    }
}
