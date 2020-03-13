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
    //[Authorize]
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
            _ = await _courseService.Insert(course);
            return Response(course);
        }
    }
}
