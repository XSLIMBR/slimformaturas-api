using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ApiController
    {
        readonly ICourseService _courseService;
        public CourseController
            (
             ICourseService courseService,
             NotificationHandler notifications
            ) : base(notifications)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Course course)
        {
            course = await _courseService.Insert(course);
            return Response(course);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Course course) 
        {
           course = await _courseService.Update(course);
            return Response(course.CourseId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _courseService.Delete(id);
            return Response();
        }
    }
}
