using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Dto;
using AutoMapper;

namespace SlimFormaturas.Service.Mapper
{
    public class MappingUniversity : Profile
    {
        public MappingUniversity()
        {
            CreateMap<University, UniversityDto>();
            CreateMap<UniversityDto, University>();
        }
    }
}
