using AutoMapper;
using SlimFormaturas.Domain.Dto;
using SlimFormaturas.Domain.Dto.Address;
using SlimFormaturas.Domain.Dto.Graduate;
using SlimFormaturas.Domain.Dto.Phone;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Service.Mapper {
    public class ViewModelToDomainMappingProfile : Profile {
        public ViewModelToDomainMappingProfile () {
            CreateMap<UniversityDto, University>();
            #region Formando
            CreateMap<GraduateDto, Graduate>();
            CreateMap<GraduateForCreationDto, Graduate>();
            #endregion
            CreateMap<AddressDto, Address>();
            CreateMap<PhoneDto, Phone>();
            CreateMap<TypeGenericDto, TypeGeneric>();
        }
    }
}
