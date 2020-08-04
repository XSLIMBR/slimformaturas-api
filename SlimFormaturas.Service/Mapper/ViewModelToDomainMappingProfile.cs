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
using SlimFormaturas.Domain.Dto.Graduate.Response;

namespace SlimFormaturas.Service.Mapper {
    public class ViewModelToDomainMappingProfile : Profile {
        public ViewModelToDomainMappingProfile () {
            CreateMap<ShippingCompanyDto, ShippingCompany>();
            CreateMap<ShippingCompanyForCreationDto, ShippingCompany>();

            CreateMap<EmployeeDto, Employee>();
            CreateMap<EmployeeForCreationDto, Employee>();

            CreateMap<CollegeDto, College>();
            CreateMap<CollegeForCreationDto, College>();

            #region Formando
            CreateMap<GraduateDto, Graduate>();
            CreateMap<GraduateForCreationDto, Graduate>();
            CreateMap<GraduateSearchResponse, Graduate>();
            #endregion

            CreateMap<AddressForCreationDto, Address>();
            CreateMap<AddressDto, Address>();

            CreateMap<SellerForCreationDto, Seller>();
            CreateMap<SellerDto, Seller>();

            CreateMap<PhoneForCreationDto, Phone>();
            CreateMap<PhoneDto, Phone>();

            CreateMap<TypeGenericDto, TypeGeneric>();
            CreateMap<TypeGenericForCreationDto, TypeGeneric>();

            CreateMap<CourseDto, Course>();
            CreateMap<CourseForCreationDto, Course>();

            CreateMap<ContractDto, Contract>();
            CreateMap<ContractForCreationDto, Contract>();
        }
    }
}
