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

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<string>> Post(TypeGeneric typeGeneric) {
            _ = await _typeGenericService.Insert(typeGeneric);
            return Response(typeGeneric.TypeGenericId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Editar")]
        [HttpPut]
        public async Task<ActionResult<string>> Put(TypeGeneric typeGeneric) {
            _ = await _typeGenericService.Update(typeGeneric);
            return Response(typeGeneric.TypeGenericId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Excluir")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id) {
            await _typeGenericService.Delete(id);
            return Response();
        }

        // GET api/Graduate
        /// <summary>
        /// Get all graduates
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        /// 
        [HttpGet]
        public async Task<ActionResult> Get() {
            return Response(await _typeGenericService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id) {
            return Response(await _typeGenericService.Get(id));
        }

    }
}
