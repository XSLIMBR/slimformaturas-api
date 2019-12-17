using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
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

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<string>> Post(Address address) {
            _ = await _addressService.Insert(address);
            return Response(address.AddressId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Editar")]
        [HttpPut]
        public async Task<ActionResult<string>> Put(Address address) {
            _ = await _addressService.Update(address);
            return Response(address.AddressId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Excluir")]
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
        [HttpGet]
        public async Task<ActionResult> Get() {
            return Response(await _addressService.Get());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGraduate(string id) {
            return Response(await _addressService.GetWhere(c => c.GraduateId == id));
        }
    }
}