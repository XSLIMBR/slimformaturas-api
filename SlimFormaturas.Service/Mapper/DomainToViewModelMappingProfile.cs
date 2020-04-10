using AutoMapper;
using SlimFormaturas.Domain.Dto;
using SlimFormaturas.Domain.Dto.Address;
using SlimFormaturas.Domain.Dto.Graduate;
using SlimFormaturas.Domain.Dto.Phone;
using SlimFormaturas.Domain.Dto.TypeGeneric;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Service.Mapper {
    public class DomainToViewModelMappingProfile : Profile{
        public DomainToViewModelMappingProfile () {
            CreateMap<University, UniversityDto>();
            #region Formando
            CreateMap<Graduate, GraduateDto>();
            CreateMap<Graduate, GraduateForCreationDto>();
            #endregion

            CreateMap<Address, AddressForCreationDto>();
            CreateMap<Address, AddressDto>();

            CreateMap<Phone, PhoneForCreationDto>();
            CreateMap<Phone, PhoneDto>();

            CreateMap<TypeGeneric, TypeGenericDto>();
            CreateMap<TypeGeneric, TypeGenericForCreationDto>();
        }
    }
}
