using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Infra.Data.Mapping;
using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace SlimFormaturas.Infra.Data.Context {
    public class MssqlContext : DbContext {
         readonly IWebHostEnvironment _environment;

        public MssqlContext(IWebHostEnvironment environment) {
            _environment = environment;
        }

        public DbSet<Graduate> Graduate { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TypeGeneric> TypeGeneric { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<ShippingCompany> ShippingCompany { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<University> University { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new GraduateMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new PhoneMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ShippingCompanyMap());
            modelBuilder.ApplyConfiguration(new TypeGenericMap());
            modelBuilder.ApplyConfiguration(new CourseMap());
            modelBuilder.ApplyConfiguration(new SellerMap());
            modelBuilder.ApplyConfiguration(new UniversityMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_environment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_environment.EnvironmentName}.json", true)
                .Build();
            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default){
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateRegister") != null)){
                if(entry.State == EntityState.Added){
                    entry.Property("DateRegister").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified) {
                    entry.Property("DateRegister").IsModified = false;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
