using _4Create.Data;
using System.Configuration;

/*
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System;
using Swashbuckle.AspNetCore.Filters;
using PdfSharpCore.Pdf;
using Microsoft.AspNetCore.Mvc;
*/

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using _4Create.Controllers;
using _4Create.Data.Interfaces;
using _4Create.Services.Interfaces;
using _4Create.Data.Repositories;
using _4Create.Services;
using _4Create.Entities.Models;
using _4Create.Entities.Utiles;
using AutoMapper;

namespace _4Create
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path to your application's directory
                .AddJsonFile("appsettings.json") // Load configuration from appsettings.json
                .Build();

            var connectionString = configuration.GetConnectionString("FourCreateConnectionString");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //builder.Services.AddScoped<IRepositoryBase<Employee>, RepositoryBase<Employee>>();

            builder.Services.AddScoped<ISystemLogRepository, SystemLogRepository>();
            builder.Services.AddScoped<ISystemLogService, SystemLogService>();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton(mapper);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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