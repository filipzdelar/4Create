using _4Create.Entities.Models;
using _4Create.Entities.Models.Middle;
using Microsoft.EntityFrameworkCore;

namespace _4Create.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }

        //public DbSet<EmployeeCompany> EmployeeCompanies { get; set; }
        
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeCompany>()
                .HasKey(ec => new { ec.EmployeeId, ec.CompanyId });

            modelBuilder.Entity<EmployeeCompany>()
                .HasOne(ec => ec.Employee)
                .WithMany(e => e.EmployeeCompanies)
                .HasForeignKey(ec => ec.EmployeeId);

            modelBuilder.Entity<EmployeeCompany>()
                .HasOne(ec => ec.Company)
                .WithMany(c => c.EmployeeCompanies)
                .HasForeignKey(ec => ec.CompanyId);
          */  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasMany(employee => employee.Companies)
                .WithMany(companies => companies.Employees)
            .   UsingEntity(j => j.ToTable("EmployeeCompany"));
            //modelBuilder.Entity<Company>();
            //modelBuilder.Entity<Employee>().ToTable("Tests");
            //modelBuilder.Entity<Company>().ToTable("Attempts");

        
        }
    }
}
