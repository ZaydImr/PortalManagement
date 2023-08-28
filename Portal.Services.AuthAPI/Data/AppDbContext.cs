using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Services.AuthAPI.Model;

namespace Portal.Services.AuthAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specify the default database schema
            modelBuilder.HasDefaultSchema("auth");

            base.OnModelCreating(modelBuilder);
        }

    }
}
