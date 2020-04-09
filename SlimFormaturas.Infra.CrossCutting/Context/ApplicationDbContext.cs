using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace SlimFormaturas.Infra.CrossCutting.Identity.Context {
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> {
        private readonly IWebHostEnvironment _environment;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IWebHostEnvironment env) : base(options)
        {
            _environment = env;
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
    }
}
