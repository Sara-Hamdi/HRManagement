using HRManagement.Domain.Aggregates.EmployeesAggregates;
using HRManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HRManagement.Infrastructure
{
    public static class InfraStructureDependecies
    {
        public static IServiceCollection AddInfraStructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            return services;

        }

    }
}
