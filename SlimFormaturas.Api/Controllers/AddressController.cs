using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Infra.CrossCutting.Identity.Authorization;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using SlimFormaturas.Domain.Dto.Address;
using SlimFormaturas.Domain.Dto.Address.Response;

namespace SlimFormaturas.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ApiController {
        readonly IAddressService _addressService;
        readonly IMapper _mapper;

        public AddressController(
            IAddressService addressService,
            IMapper mapper,
            NotificationHandler notifications) : base (notifications) {
            _addressService = addressService;
            _mapper = mapper;
        }

        //[CustomAuthorize.ClaimsAuthorize("Address", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<AddressResponse>> Post([FromBody]AddressForCreationWithEntityDto addressForCreation) {
            var address = _mapper.Map<Address>(addressForCreation);
            return Response(await _addressService.Insert(address));
        }

        //[CustomAuthorize.ClaimsAuthorize("Address", "Editar")]
        [HttpPut]
        public async Task<ActionResult<AddressResponse>> Put(AddressDto addressDto) {
            return Response(await _addressService.Update(addressDto));
        }

        //[CustomAuthorize.ClaimsAuthorize("Address", "Excluir")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id) {
            await _addressService.Delete(id);
            return Response();
        }

        // GET api/Address
        /// <summary>
        /// Trazer todos os enderecos
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        /// 
        //[CustomAuthorize.ClaimsAuthorize("Address", "Consultar")]
        [HttpGet]
        public async Task<ActionResult> Get() {
            var address = _mapper.Map<IList<AddressDto>>(await _addressService.Get());
            return Response(address);
        }


        // GET api/Address/GetGraduate
        /// <summary>
        /// Pega todos os enderecos associados a um ID
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        /// 
        //[CustomAuthorize.ClaimsAuthorize("Address", "Consultar")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGraduate(string id) {
            var address = _mapper.Map<IList<AddressDto>>(await _addressService.GetWhere(c => c.GraduateId == id));
            return Response(address);
        }
    }
}