using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ApiController {
        private readonly ITypeGenericService _typeGenericService;

        public TypeController(ITypeGenericService typeGenericService,NotificationHandler notifications) : base (notifications) {
            _typeGenericService = typeGenericService;
        }

        // GET: api/Type
        [HttpGet]
        public async Task<ActionResult> Address() {
            return Response(await _typeGenericService.GetWhere(c => c.localization == locate.Address));
        }

    }
}
