using HRManagement.Domain.Aggregates.DepartmentAggregate;
using HRManagement.Domain.Aggregates.EmployeeAggregate;
using HRManagement.Domain.Aggregates.ProjectAggregate;
using HRManagement.Domain.Aggregates.UserAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Address>().ToTable(nameof(Address));
            builder.Entity<Employee>().ToTable(nameof(Employee));
            builder.Entity<Project>().ToTable(nameof(Project));
            builder.Entity<Department>().ToTable(nameof(Department));
            builder.Entity<ProjectEmployee>().ToTable(nameof(ProjectEmployee));
            builder.Entity<Position>().ToTable(nameof(Position));
        }


    }
}
