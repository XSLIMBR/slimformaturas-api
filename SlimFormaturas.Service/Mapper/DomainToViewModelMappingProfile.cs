using AutoMapper;
using SlimFormaturas.Domain.Dto;
using SlimFormaturas.Domain.Dto.Address;
using SlimFormaturas.Domain.Dto.Course;
using SlimFormaturas.Domain.Dto.Employee;
using SlimFormaturas.Domain.Dto.Graduate;
using SlimFormaturas.Domain.Dto.Phone;
using SlimFormaturas.Domain.Dto.Seller;
using SlimFormaturas.Domain.Dto.ShippingCompany;
using SlimFormaturas.Domain.Dto.TypeGeneric;
using SlimFormaturas.Domain.Dto.College;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Dto.Contract;
using System.Linq;
using SlimFormaturas.Domain.Dto.College.Response;
using SlimFormaturas.Domain.Dto.Contract.Response;
using SlimFormaturas.Domain.Dto.Graduate.Response;
using SlimFormaturas.Domain.Dto.ShippingCompany.Response;
using SlimFormaturas.Domain.Dto.Employee.Response;
using SlimFormaturas.Domain.Dto.Seller.Response;
using SlimFormaturas.Domain.Dto.Address.Response;
using SlimFormaturas.Domain.Dto.Phone.Response;
using SlimFormaturas.Domain.Dto.TypeGeneric.Response;
using SlimFormaturas.Domain.Dto.Course.Response;

namespace SlimFormaturas.Service.Mapper {
    public class DomainToViewModelMappingProfile : Profile{
        public DomainToViewModelMappingProfile () {
            CreateMap<ShippingCompany, ShippingCompanyDto>();
            CreateMap<ShippingCompany, ShippingCompanyForCreationDto>();
            CreateMap<ShippingCompany, ShippingCompanyResponse>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeForCreationDto>();
            CreateMap<Employee, EmployeeResponse>();

            CreateMap<College, CollegeDto>();
            CreateMap<College, CollegeForCreationDto>();
            CreateMap<College, CollegeResponse>();

            #region Formando
            CreateMap<Graduate, GraduateDto>();
            CreateMap<Graduate, GraduateForCreationDto>();
            CreateMap<Graduate, GraduateSearchResponse>()
                .ForMember(c => c.PhoneNumber, opt => opt.MapFrom(s => s.Phone.FirstOrDefault().PhoneNumber))
                .ForMember(n => n.ShortName, opt => opt.MapFrom(a => a.GetShortName()));
            CreateMap<Graduate, GraduateResponse>();
            #endregion

            CreateMap<Seller, SellerForCreationDto>();
            CreateMap<Seller, SellerDto>();
            CreateMap<Seller, SellerResponse>();

            CreateMap<Address, AddressForCreationDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Address, AddressResponse>();

            CreateMap<Phone, PhoneForCreationDto>();
            CreateMap<Phone, PhoneDto>();
            CreateMap<Phone, PhoneResponse>();

            CreateMap<TypeGeneric, TypeGenericDto>();
            CreateMap<TypeGeneric, TypeGenericForCreationDto>();
            CreateMap<TypeGeneric, TypeGenericResponse>();

            CreateMap<Course, CourseDto>();
            CreateMap<Course, CourseForCreationDto>();
            CreateMap<Course, CourseResponse>();

            CreateMap<Contract, ContractDto>();
            CreateMap<Contract, ContractForCreationDto>();
            CreateMap<Contract, ContractResponse>();
            CreateMap<Contract, ContractSearchResponse>();

        }
    }
}
