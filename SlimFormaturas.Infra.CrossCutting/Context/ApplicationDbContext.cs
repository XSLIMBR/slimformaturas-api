using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SlimFormaturas.Infra.CrossCutting.Identity.Context {
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> {
        private readonly IHostingEnvironment _environment;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options, 
            IHostingEnvironment env) : base(options)
        {
            _environment = env;
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
