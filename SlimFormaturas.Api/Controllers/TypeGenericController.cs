using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Dto.TypeGeneric;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Infra.CrossCutting.Identity.Authorization;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using SlimFormaturas.Domain.Dto.TypeGeneric.Response;

namespace SlimFormaturas.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeGenericController : ApiController {
        readonly ITypeGenericService _typeGenericService;
        readonly IMapper _mapper;

        public TypeGenericController(
            ITypeGenericService typeGenericService,
            IMapper mapper,
            NotificationHandler notifications) : base (notifications) {
            _typeGenericService = typeGenericService;
            _mapper = mapper;
        }

        //[CustomAuthorize.ClaimsAuthorize("Type", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<TypeGenericResponse>> Post ([FromBody] TypeGenericForCreationDto typeGenericForCreationDto) {
            var typeGeneric = _mapper.Map<TypeGeneric>(typeGenericForCreationDto);
            return Response(await _typeGenericService.Insert(typeGeneric));
        }

        //[CustomAuthorize.ClaimsAuthorize("Type", "Editar")]
        [HttpPut]
        public async Task<ActionResult<TypeGenericResponse>> Put([FromBody] TypeGenericDto typeGenericDto) {
            return Response(await _typeGenericService.Update(typeGenericDto));
        }

        // GET api/Graduate
        /// <summary>
        /// Get all graduates
        /// </summary>
        /// <remarks>This 
        /// API will get the values.</remarks>
        /// 
        //[CustomAuthorize.ClaimsAuthorize("Type", "Consultar")]
        [HttpGet]
        public async Task<ActionResult<TypeGenericDto>> Get() {
            var typeGeneric = _mapper.Map<IList<TypeGenericDto>>(await _typeGenericService.Get());
            return Response(typeGeneric);
        }

    }
}
