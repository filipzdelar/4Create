using _4Create.Data;
using Microsoft.EntityFrameworkCore;
using _4Create.Data.Interfaces;
using _4Create.Services.Interfaces;
using _4Create.Data.Repositories;
using _4Create.Services;
using _4Create.Entities.Utiles;
using AutoMapper;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;

namespace _4Create
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json") 
                .Build();

            var connectionString = configuration.GetConnectionString("FourCreateConnectionString");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            #region SystemLog
            builder.Services.AddScoped<ISystemLogRepository, SystemLogRepository>();
            builder.Services.AddScoped<ISystemLogService, SystemLogService>();
            #endregion

            #region Employee
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            #endregion

            #region Company
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            #endregion

            #region Mapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton(mapper);
            #endregion

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}