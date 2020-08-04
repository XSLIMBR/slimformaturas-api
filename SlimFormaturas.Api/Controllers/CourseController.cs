using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Dto.Course;
using SlimFormaturas.Domain.Dto.Course.Response;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlimFormaturas.Api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ApiController {
        readonly ICourseService _courseService;
        readonly IMapper _mapper;
        public CourseController (
             ICourseService courseService,
             NotificationHandler notifications,
              IMapper mapper
            ) : base(notifications) {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpPost("InsertNew")]
        public async Task<ActionResult<CourseResponse>> Post([FromBody]CourseForCreationDto courseDto) {
            return Response(await _courseService.Insert(courseDto));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<CourseResponse>> Put([FromBody]CourseDto CourseDto) {
            return Response(await _courseService.Update(CourseDto));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<CourseDto>> Get() {
            var course = _mapper.Map<IList<CourseDto>>(await _courseService.Get());
            return Response(course);
        }

        [HttpGet("GetAllById/{id}")]
        public async Task<ActionResult<CourseDto>> Get(string id) {
            var course = _mapper.Map<CourseDto>(await _courseService.GetAllById(id));
            return Response(course);
        }
    }
}
