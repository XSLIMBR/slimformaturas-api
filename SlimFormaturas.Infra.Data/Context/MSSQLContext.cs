using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Infra.Data.Mapping;
using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SlimFormaturas.Infra.Data.Context {
    public class MssqlContext : DbContext {
        private readonly IHostingEnvironment _environment;

        public MssqlContext(IHostingEnvironment environment) {
            _environment = environment;
        }

        public DbSet<Graduate> Graduate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new GraduateMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_environment.ContentRootPath)
                .AddJsonFile("appsettings.json")
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
