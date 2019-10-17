using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SlimFormaturas.Domain.Validators;
using SlimFormaturas.Domain.Notifications;
using static SlimFormaturas.Infra.CrossCutting.Identity.Authorization.CustomAuthorize;

namespace SlimFormaturas.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GraduateController : ApiController {
        private readonly IGraduateService _graduateService;

        public GraduateController(
            IGraduateService graduateService,
            NotificationHandler notifications) : base (notifications)
        {
            _graduateService = graduateService;
        }

        [ClaimsAuthorize("Graduate", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<Graduate>> Post(Graduate graduate) {
            await _graduateService.Post<GraduateValidator>(graduate);
            return Response(graduate);
        }

        [ClaimsAuthorize("Graduate", "Editar")]
        [HttpPut]
        public async Task<ActionResult<Graduate>> Put(Graduate graduate) {
            await _graduateService.Put<GraduateValidator>(graduate);
            return Response(graduate);
        }

        [ClaimsAuthorize("Graduate", "Excluir")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id) {
            await _graduateService.Delete(id);
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
            return Response(await _graduateService.Get());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id) {
            return Response(await _graduateService.Get(id));
        }
    }
}