using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ApiController {
         readonly ITypeGenericService _typeGenericService;

        public TypeController(
            ITypeGenericService typeGenericService, 
            NotificationHandler notifications) : base (notifications) {
            _typeGenericService = typeGenericService;
        }

        // GET: api/Type
        //[HttpGet("Address")]
        [HttpGet]
        public async Task<ActionResult> Get() {
            return Response(await _typeGenericService.Get());
        }

        //[HttpPost("Address")]
        [HttpPost]
        public async Task<ActionResult<TypeGeneric>> Post(TypeGeneric typeGeneric) {
            //typeGeneric.Localization = Locate.Address;
            await _typeGenericService.Insert(typeGeneric);
            return Response(typeGeneric.TypeGenericId);
        }

    }
}
