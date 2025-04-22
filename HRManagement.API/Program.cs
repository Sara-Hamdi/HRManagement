using HRManagement.Application;
using HRManagement.Domain;
using HRManagement.Infrastructure;
using HRManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddApplicationDependencies();
            builder.Services.AddControllers();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
