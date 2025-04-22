using HRManagement.Domain.Aggregates.Departments;
using HRManagement.Domain.Aggregates.EmployeesAggregates;
using HRManagement.Domain.Aggregates.Projects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable(nameof(Address));
            modelBuilder.Entity<Employee>().ToTable(nameof(Employee));
            modelBuilder.Entity<Project>().ToTable(nameof(Project));
            modelBuilder.Entity<Department>().ToTable(nameof(Department));
            modelBuilder.Entity<ProjectEmployee>().ToTable(nameof(ProjectEmployee));
            modelBuilder.Entity<Position>().ToTable(nameof(Position));
        }


    }
}
