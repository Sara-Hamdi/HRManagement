using FluentValidation;
using FluentValidation.AspNetCore;
using HRManagement.Application.Contracts.Employees.Interfaces;
using HRManagement.Application.Contracts.Roles.Interfaces;
using HRManagement.Application.Departments.Interfaces;
using HRManagement.Application.Features.Departments;
using HRManagement.Application.Features.Employees;
using HRManagement.Application.Features.Reports;
using HRManagement.Application.Features.Reports.Interfaces;
using HRManagement.Application.Features.Roles;
using HRManagement.Application.Features.Users;
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
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddTransient<IReportAppService, ReportAppService>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IDepartmentAppService, DepartmentAppService>();
            services.AddTransient<IRoleAppService, RoleAppService>();


            return services;

        }

    }
}
