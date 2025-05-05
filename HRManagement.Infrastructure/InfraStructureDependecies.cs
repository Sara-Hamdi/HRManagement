using HRManagement.Domain.Aggregates.EmployeesAggregates;
using HRManagement.Domain.Aggregates.Identity;
using HRManagement.Domain.ExternalServices;
using HRManagement.ExternalServices.ReportService;
using HRManagement.Infrastructure.Context;
using HRManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HRManagement.Infrastructure
{
    public static class InfraStructureDependecies
    {
        public static IServiceCollection AddInfraStructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IReportService, ReportService>();
            //identity service
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Password.RequiredLength = 10;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            return services;

        }

    }
}
