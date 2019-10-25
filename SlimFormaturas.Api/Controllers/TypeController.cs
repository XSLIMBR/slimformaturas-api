using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ApiController {
         readonly ITypeGenericService _typeGenericService;

        public TypeController(ITypeGenericService typeGenericService,NotificationHandler notifications) : base (notifications) {
            _typeGenericService = typeGenericService;
        }

        // GET: api/Type
        [HttpGet("Address")]
        public async Task<ActionResult> AddressGet() {
            return Response(await _typeGenericService.GetWhere(c => c.Localization == Locate.Address));
        }

        [HttpPost("Address")]
        public async Task<ActionResult<TypeGeneric>> AddressPost(TypeGeneric typeGeneric) {
            typeGeneric.Localization = Locate.Address;
            await _typeGenericService.Post(typeGeneric);
            return typeGeneric;
        }

    }
}
