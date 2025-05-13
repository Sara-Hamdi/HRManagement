using FluentValidation;
using FluentValidation.AspNetCore;
using HRManagement.Application.Employees;
using HRManagement.Application.Employees.Interfaces;
using HRManagement.Application.Employees.Queries;
using HRManagement.Application.Reports;
using HRManagement.Application.Reports.Interfaces;
using HRManagement.Application.Users;
using HRManagement.Application.Users.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace HRManagement.Application
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {

            services.AddTransient<IEmployeeAppService, EmployeeAppService>();
            services.AddTransient<IEmployeeQuery, EmployeeQuery>();
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddTransient<IReportAppService, ReportAppService>();
            services.AddTransient<IUserAppService, UserAppService>();


            return services;

        }

    }
}
