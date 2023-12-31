﻿using _4Create.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace _4Create.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasMany(employee => employee.Companies)
                .WithMany(companies => companies.Employees)
            .   UsingEntity(j => j.ToTable("EmployeeCompany"));
        }
    }
}
