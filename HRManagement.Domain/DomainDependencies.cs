using HRManagement.Domain.Aggregates.EmployeesAggregates;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Domain
{
    public static class DomainDependencies
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddTransient<EmployeeManager>();
            return services;

        }
    }
}
