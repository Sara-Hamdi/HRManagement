using HRManagement.Domain.Aggregates.DepartmentAggregate;
using HRManagement.Domain.Aggregates.EmployeeAggregate;
using Microsoft.Extensions.DependencyInjection;

namespace HRManagement.Domain
{
    public static class DomainDependencies
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddTransient<EmployeeManager>();
            services.AddTransient<DepartmentManager>();

            return services;

        }
    }
}
