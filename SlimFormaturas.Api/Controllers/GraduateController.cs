using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SlimFormaturas.Infra.CrossCutting.Identity.Authorization;
using SlimFormaturas.Domain.Dto;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GraduateController : ApiController {
         readonly IGraduateService _graduateService;

        public GraduateController(
            IGraduateService graduateService,
            NotificationHandler notifications) : base (notifications) {
            _graduateService = graduateService;
        }

        /// <summary>
        /// Inserir um novo formando na base
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <returns>O id do novo formando inserido</returns>
        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<string>> Post(GraduateDto graduate) {
            Graduate graduate1 = new Graduate("", graduate.Name, graduate.Cpf, graduate.Rg, graduate.Sex, graduate.BirthDate, graduate.DadName, graduate.MotherName, graduate.Email, graduate.Photo, graduate.Bank, graduate.Agency, graduate.CheckingAccount);
            _ = await _graduateService.Insert(graduate1);
            return Response(graduate1.GraduateId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Editar")]
        [HttpPut]
        public async Task<ActionResult<string>> Put(Graduate graduate) {
            _ = await _graduateService.Update(graduate);
            return Response(graduate.GraduateId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Excluir")]
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
       // [CustomAuthorize.ClaimsAuthorizeAttribute("Graduate", "Consultar")]
        [HttpGet]
        public async Task<ActionResult> Get() {
            return Response(await _graduateService.Get());
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Consultar")]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id) {
            return Response(await _graduateService.Get(id));
        }
    }
}