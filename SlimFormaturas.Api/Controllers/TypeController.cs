using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Infra.CrossCutting.Identity.Authorization;
using System.Threading.Tasks;

namespace SlimFormaturas.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ApiController {
         readonly ITypeGenericService _typeGenericService;

        public TypeController(
            ITypeGenericService typeGenericService, 
            NotificationHandler notifications) : base (notifications) {
            _typeGenericService = typeGenericService;
        }

        [CustomAuthorize.ClaimsAuthorize("Type", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<string>> Post(TypeGeneric typeGeneric) {
            _ = await _typeGenericService.Insert(typeGeneric);
            return Response(typeGeneric.TypeGenericId);
        }

        [CustomAuthorize.ClaimsAuthorize("Type", "Editar")]
        [HttpPut]
        public async Task<ActionResult<string>> Put(TypeGeneric typeGeneric) {
            _ = await _typeGenericService.Update(typeGeneric);
            return Response(typeGeneric.TypeGenericId);
        }

        [CustomAuthorize.ClaimsAuthorize("Type", "Excluir")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id) {
            await _typeGenericService.Delete(id);
            return Response();
        }

        // GET api/Graduate
        /// <summary>
        /// Get all graduates
        /// </summary>
        /// <remarks>This 
        /// API will get the values.</remarks>
        /// 
        [CustomAuthorize.ClaimsAuthorize("Type", "Consultar")]
        [HttpGet]
        public async Task<ActionResult> Get() {
            return Response(await _typeGenericService.Get());
        }

        [CustomAuthorize.ClaimsAuthorize("Type", "Consultar")]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id) {
            return Response(await _typeGenericService.Get(id));
        }

    }
}
