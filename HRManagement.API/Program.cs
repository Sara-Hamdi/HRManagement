using HRManagement.API.CustomMiddlewares;
using HRManagement.API.Localization;
using HRManagement.Application;
using HRManagement.Domain;
using HRManagement.Infrastructure;
using HRManagement.Infrastructure.Context;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace HRManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
            });
            builder.Services.AddInfraStructureDependencies();
            builder.Services.AddApplicationDependencies(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddLocalization();
            builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("ar"),
                };
                options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0], uiCulture: supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            builder.Services.AddDomainDependencies();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            var supportedCultures = new[] { "en", "ar" };
            var localizationOptions = new RequestLocalizationOptions()
                .AddSupportedCultures(supportedCultures)
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

        }
    }
}
