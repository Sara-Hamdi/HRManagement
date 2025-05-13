using HRManagement.Application.Users.Interfaces;
using HRManagement.Domain.Aggregates.EmployeeAggregate;
using HRManagement.Domain.Aggregates.UserAggregate;
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
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            //identity service
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequiredLength = 10;
                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            return services;

        }

    }
}
