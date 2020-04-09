using AutoMapper;
using SlimFormaturas.Domain.Dto;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Service.Mapper {
    public class DomainToViewModelMappingProfile : Profile{
        public DomainToViewModelMappingProfile () {
            CreateMap<University, UniversityDto>();
            CreateMap<Graduate, GraduateDto>();
        }
    }
}
