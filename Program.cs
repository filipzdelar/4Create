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


namespace _4Create
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            /*
             * services.ConfigureCors();

            services.ConfigureIISIntegration();

            services.AddDbContext<RepositoryContext>(opts => 
            opts.UseSqlServer(Configuration["ConnectionString:ESolveDEV"]), 
            ServiceLifetime.Transient, ServiceLifetime.Transient);

             */



            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path to your application's directory
                .AddJsonFile("appsettings.json") // Load configuration from appsettings.json
                .Build();

            var connectionString = configuration.GetConnectionString("FourCreateConnectionString");

            // Build the service provider
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString))
                .BuildServiceProvider();


            builder.Services.AddControllers();
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

            //app.MapCompanyEndpoints();

            app.Run();
        }
    }
}