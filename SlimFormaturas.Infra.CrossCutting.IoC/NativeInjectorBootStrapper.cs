using Microsoft.AspNetCore.Http;
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
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IGraduateService, GraduateService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<ITypeGenericService, TypeGenericService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICollegeService, CollegeService>();
            services.AddScoped<IShippingCompanyService, ShippingCompanyService>();
            services.AddScoped<IContractService, ContractService>();
            //Infra - Data
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IShippingCompanyRepository, ShippingCompanyRepository>();
            services.AddScoped<IGraduateRepository,GraduateRepository>();
            services.AddScoped<ITypeGenericRepository, TypeGenericRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICollegeRepository, CollegeRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            //Context
            services.AddDbContext<MssqlContext>();
            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<NotificationHandler>();
        }
    }
}
