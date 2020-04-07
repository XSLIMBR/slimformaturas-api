using SlimFormaturas.Domain.Entities;
using AutoMapper;
using SlimFormaturas.Api.Dto;

namespace SlimFormaturas.Api.Mapper
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
