using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Dto;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using AutoMapper;

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
        public async Task<IActionResult> Post(UniversityDto universityDto)
        {
            var university = _mapper.Map<University>(universityDto);
            return Response(await _universityService.Insert(university)); 
        }

        [HttpPut]
        public async Task<IActionResult> Put(UniversityDto universityDto)
        {
            var university = _mapper.Map<University>(universityDto);
            return Response(await _universityService.Insert(university));
        }
    }
}
