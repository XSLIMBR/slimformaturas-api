using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Dto;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using SlimFormaturas.Domain.Dto.University;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ApiController
    {
        readonly IUniversityService _universityService;
        readonly IMapper _mapper;
        public UniversityController
        (
            IUniversityService universityService,
            NotificationHandler notifications,
            IMapper mapper

        ) : base(notifications)
        {
            _universityService = universityService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UniversityForCreationDto universityDto)
        {
            var university = _mapper.Map<University>(universityDto);
            return Response(await _universityService.Insert(university)); 
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UniversityForCreationDto universityDto)
        {
            var university = _mapper.Map<University>(universityDto);
            return Response(await _universityService.Update(university));
        }

        [HttpGet]
        public async Task<ActionResult<UniversityDto>> Get()
        {
            var university = _mapper.Map<IList<UniversityDto>>(await _universityService.Get());
            return Response(university);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UniversityDto>> Get(string id)
        {
            var university = _mapper.Map<UniversityDto>(await _universityService.Get(id));
            return Response(university);
        }
    }
}
