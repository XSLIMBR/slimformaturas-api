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
    public class PhoneController : ApiController {
         readonly IPhoneService _phoneService;

        public PhoneController(
            IPhoneService phoneService,
            NotificationHandler notifications) : base (notifications) {
            _phoneService = phoneService;
        }

        [CustomAuthorize.ClaimsAuthorize("Phone", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<string>> Post(Phone phone) {
            _ = await _phoneService.Insert(phone);
            return Response(phone.PhoneId);
        }

        [CustomAuthorize.ClaimsAuthorize("Phone", "Editar")]
        [HttpPut]
        public async Task<ActionResult<string>> Put(Phone phone) {
            _ = await _phoneService.Update(phone);
            return Response(phone.PhoneId);
        }

        [CustomAuthorize.ClaimsAuthorize("Phone", "Excluir")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id) {
            await _phoneService.Delete(id);
            return Response();
        }

        // GET api/Graduate
        /// <summary>
        /// Get all graduates
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        /// 
        [CustomAuthorize.ClaimsAuthorize("Phone", "Consultar")]
        [HttpGet]
        public async Task<ActionResult> Get() {
            return Response(await _phoneService.Get());
        }

        [CustomAuthorize.ClaimsAuthorize("Phone", "Consultar")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGraduate(string id) {
            return Response(await _phoneService.GetWhere(c => c.GraduateId == id));
        }
    }
}