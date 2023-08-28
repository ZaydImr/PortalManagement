using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Services.AuthAPI.Model;

namespace Portal.Services.AuthAPI.Data;

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

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "ROLE_SUPER_ADMIN", NormalizedName = "ROLE_SUPER_ADMIN" });
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "ROLE_ADMIN", NormalizedName = "ROLE_ADMIN" });
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "ROLE_RH", NormalizedName = "ROLE_RH" });
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "ROLE_MANAGER", NormalizedName = "ROLE_EMPLOYEE" });
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "ROLE_EMPLOYEE", NormalizedName = "ROLE_EMPLOYEE" });
    }

}
