using HRManagement.Domain.Aggregates.EmployeesAggregates;
using HRManagement.Domain.Services;
using HRManagement.Infrastructure.Repositories;
using HRManagement.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HRManagement.Infrastructure
{
    public static class InfraStructureDependecies
    {
        public static IServiceCollection AddInfraStructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IReportService, ReportService>();
            return services;

        }

    }
}
