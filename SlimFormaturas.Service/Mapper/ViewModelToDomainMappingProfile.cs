using AutoMapper;
using SlimFormaturas.Domain.Dto;
using SlimFormaturas.Domain.Dto.Address;
using SlimFormaturas.Domain.Dto.Graduate;
using SlimFormaturas.Domain.Dto.Phone;
using SlimFormaturas.Domain.Dto.TypeGeneric;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Service.Mapper {
    public class ViewModelToDomainMappingProfile : Profile {
        public ViewModelToDomainMappingProfile () {
            CreateMap<UniversityDto, University>();

            #region Formando
            CreateMap<GraduateDto, Graduate>();
            CreateMap<GraduateForCreationDto, Graduate>();
            #endregion

            CreateMap<AddressForCreationDto, Address>();
            CreateMap<AddressDto, Address>();

            CreateMap<PhoneForCreationDto, Phone>();
            CreateMap<PhoneDto, Phone>();

            CreateMap<TypeGenericDto, TypeGeneric>();
            CreateMap<TypeGenericForCreationDto, TypeGeneric>();
        }
    }
}
