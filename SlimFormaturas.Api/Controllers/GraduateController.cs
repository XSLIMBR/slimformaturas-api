using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SlimFormaturas.Domain.Validators;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Infra.CrossCutting.Identity.Authorization;

namespace SlimFormaturas.Api.Controllers {
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GraduateController : ApiController {
         readonly IGraduateService _graduateService;

        public GraduateController(
            IGraduateService graduateService,
            NotificationHandler notifications) : base (notifications) {
            _graduateService = graduateService;
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<string>> Post(Graduate graduate) {
            //graduate.UserId =  await _graduateService.CreateUser(graduate.Cpf, graduate.Email);
            //await _graduateService.Post<GraduateValidator>(graduate);
            await _graduateService.Insert(graduate);
            return Response(graduate.GraduateId);
        }

        [CustomAuthorize.ClaimsAuthorize("Graduate", "Editar")]
        [HttpPut]
        public async Task<ActionResult<string>> Put(Graduate graduate) {
            await _graduateService.Update(graduate);
            return Response(graduate.GraduateId);
        }

        [CustomAuthorize.ClaimsAuthorize("Graduate", "Excluir")]
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