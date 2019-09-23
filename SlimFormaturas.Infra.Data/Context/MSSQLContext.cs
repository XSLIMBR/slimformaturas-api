using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Infra.Data.Mapping;

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
    }
}
