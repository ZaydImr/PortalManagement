using Microsoft.EntityFrameworkCore;
using Portal.Services.DataAPI.Model;

namespace Portal.Services.DataAPI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<JobTitle> JobTitle { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public DbSet<EmployeeBankAccount> EmployeeBankAccount { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        public DbSet<PerformanceReview> PerformanceReview { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specify the default database schema
            modelBuilder.HasDefaultSchema("data");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(new Department { DepartmentID = 1, Name = "IT / Support" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentID = 2, Name = "Technician" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentID = 3, Name = "Manager" });
        }

    }
}
