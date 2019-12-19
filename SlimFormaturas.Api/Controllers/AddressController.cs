using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Infra.CrossCutting.Identity.Authorization;
using System.Threading.Tasks;

namespace SlimFormaturas.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ApiController {
         readonly IAddressService _addressService;

        public AddressController(
            IAddressService addressService,
            NotificationHandler notifications) : base (notifications) {
            _addressService = addressService;
        }

        //[CustomAuthorize.ClaimsAuthorize("Address", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<string>> Post(Address address) {
            _ = await _addressService.Insert(address);
            return Response(address.AddressId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Address", "Editar")]
        [HttpPut]
        public async Task<ActionResult<string>> Put(Address address) {
            _ = await _addressService.Update(address);
            return Response(address.AddressId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Address", "Excluir")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id) {
            await _addressService.Delete(id);
            return Response();
        }

        // GET api/Graduate
        /// <summary>
        /// Get all graduates
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        /// 
        //[CustomAuthorize.ClaimsAuthorize("Address", "Consultar")]
        [HttpGet]
        public async Task<ActionResult> Get() {
            return Response(await _addressService.Get());
        }

        //[CustomAuthorize.ClaimsAuthorize("Address", "Consultar")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGraduate(string id) {
            return Response(await _addressService.GetWhere(c => c.GraduateId == id));
        }
    }
}