using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Dto.Course;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ApiController
    {
        readonly ICourseService _courseService;
        readonly IMapper _mapper;
        public CourseController
            (
             ICourseService courseService,
             NotificationHandler notifications,
              IMapper mapper
            ) : base(notifications)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CourseForCreationDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            _ = await _courseService.Insert(course);
            return Response(course.CourseId);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CourseDto CourseDto)
        {
            await _courseService.Update(CourseDto);
            return Response(CourseDto.CourseId);
        }

        [HttpGet]
        public async Task<ActionResult<CourseDto>> Get()
        {
            var course = _mapper.Map<IList<CourseDto>>(await _courseService.Get());
            return Response(course);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(string id)
        {
            var course = _mapper.Map<CourseDto>(await _courseService.GetAllById(id));
            return Response(course);
        }
    }
}
