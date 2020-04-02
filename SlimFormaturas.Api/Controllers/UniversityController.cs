using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ApiController
    {
        readonly IUniversityService _universityService;

        public UniversityController
        (
            IUniversityService universityService,
            NotificationHandler notifications
        ) : base(notifications)
        {
            _universityService = universityService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(University university)
        {
            university = await _universityService.Insert(university);
            return Response(university);
        }

        [HttpPut]
        public async Task<ActionResult> Put(University university) 
        {
            university = await _universityService.Update(university);
            return Response(university);
        }
    }
}
