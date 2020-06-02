using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Infra.CrossCutting.Identity.Authorization;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using SlimFormaturas.Domain.Dto.Phone;

namespace SlimFormaturas.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ApiController {
        readonly IPhoneService _phoneService;
        readonly IMapper _mapper;

        public PhoneController (
            IPhoneService phoneService,
            IMapper mapper,
            NotificationHandler notifications) : base(notifications) {
            _phoneService = phoneService;
            _mapper = mapper;
        }

        //[CustomAuthorize.ClaimsAuthorize("Phone", "Incluir")]
        [HttpPost]
        public async Task<ActionResult> Post ([FromBody]PhoneForCreationDto phoneForCreationDto) {
            var phone = _mapper.Map<Phone>(phoneForCreationDto);
            _ = await _phoneService.Insert(phone);
            return Response(phone.PhoneId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Phone", "Editar")]
        [HttpPut]
        public async Task<ActionResult<string>> Put(PhoneDto phoneDto) {
            _ = await _phoneService.Update(phoneDto);
            return Response(phoneDto.PhoneId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Phone", "Excluir")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id) {
            await _phoneService.Delete(id);
            return Response();
        }

        // GET api/Phone
        /// <summary>
        /// Get all phones
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        /// 
        //[CustomAuthorize.ClaimsAuthorize("Phone", "Consultar")]
        [HttpGet]
        public async Task<ActionResult> Get() {
            var phone = _mapper.Map<IList<PhoneDto>>(await _phoneService.Get());
            return Response(phone);
        }

        // GET api/Phone/GetGraduate
        /// <summary>
        /// Pega todos os telefones associados a um ID
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        /// 
        //[CustomAuthorize.ClaimsAuthorize("Phone", "Consultar")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGraduate(string id) {
            var phone = _mapper.Map<IList<PhoneDto>>(await _phoneService.GetWhere(c => c.GraduateId == id));
            return Response(phone);
        }
    }
}