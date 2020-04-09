using AutoMapper;
using SlimFormaturas.Domain.Dto;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Service.Mapper {
    public class ViewModelToDomainMappingProfile : Profile {
        public ViewModelToDomainMappingProfile () {
            CreateMap<UniversityDto, University>();
            CreateMap<GraduateDto, Graduate>();
        }
    }
}
