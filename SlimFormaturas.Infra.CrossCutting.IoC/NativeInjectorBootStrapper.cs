using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Infra.CrossCutting.Identity.Context;
using SlimFormaturas.Infra.Data.Context;
using SlimFormaturas.Infra.Data.Repository;
using SlimFormaturas.Service.Services;

namespace SlimFormaturas.Infra.CrossCutting.IoC {
    public class NativeInjectorBootStrapper {
        public static void RegisterServices(IServiceCollection services) {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Services
            services.AddScoped(typeof(IService<>), typeof(BaseService<>));
            services.AddScoped<IGraduateService, GraduateService>();
            services.AddScoped<ITypeGenericService, TypeGenericService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IPhoneService, PhoneService>();
            //Infra - Data
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IGraduateRepository,GraduateRepository>();
            services.AddScoped<ITypeGenericRepository, TypeGenericRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            //Context
            services.AddDbContext<MssqlContext>();
            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<NotificationHandler>();

        }
    }
}
