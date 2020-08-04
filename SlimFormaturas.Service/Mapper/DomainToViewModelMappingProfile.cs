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

namespace SlimFormaturas.Service.Mapper {
    public class DomainToViewModelMappingProfile : Profile{
        public DomainToViewModelMappingProfile () {
            CreateMap<ShippingCompany, ShippingCompanyDto>();
            CreateMap<ShippingCompany, ShippingCompanyForCreationDto>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeForCreationDto>();

            CreateMap<College, CollegeDto>();
            CreateMap<College, CollegeForCreationDto>();
            CreateMap<College, CollegeResponse>();

            #region Formando
            CreateMap<Graduate, GraduateDto>();
            CreateMap<Graduate, GraduateForCreationDto>();
            CreateMap<Graduate, GraduateSearchResponse>()
                .ForMember(c => c.PhoneNumber, opt => opt.MapFrom(s => s.Phone.FirstOrDefault().PhoneNumber))
                .ForMember(n => n.ShortName, opt => opt.MapFrom(a => a.GetShortName()));
            #endregion

            CreateMap<Seller, SellerForCreationDto>();
            CreateMap<Seller, SellerDto>();

            CreateMap<Address, AddressForCreationDto>();
            CreateMap<Address, AddressDto>();

            CreateMap<Phone, PhoneForCreationDto>();
            CreateMap<Phone, PhoneDto>();

            CreateMap<TypeGeneric, TypeGenericDto>();
            CreateMap<TypeGeneric, TypeGenericForCreationDto>();

            CreateMap<Course, CourseDto>();
            CreateMap<Course, CourseForCreationDto>();

            CreateMap<Contract, ContractDto>();
            CreateMap<Contract, ContractForCreationDto>();
            CreateMap<Contract, ContractResponse>();

        }
    }
}
