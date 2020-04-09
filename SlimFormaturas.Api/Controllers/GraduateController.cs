using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SlimFormaturas.Domain.Dto;
using AutoMapper;
using System.Collections.Generic;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GraduateController : ApiController {
         readonly IGraduateService _graduateService;
         readonly IMapper _mapper;

        public GraduateController(
            IGraduateService graduateService,
            NotificationHandler notifications,
            IMapper mapper
            ) : base (notifications)
        {
            _graduateService = graduateService;
            _mapper = mapper;
        }

        /// <summary>
        /// Inserir um novo formando na base teste
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": julinho,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <returns>O id do novo formando inserido</returns>
        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Incluir")]
        [HttpPost]
        public async Task<IActionResult> Post(GraduateDto graduateDto) {
            var graduate = _mapper.Map<Graduate>(graduateDto);
            return Response(await _graduateService.Insert(graduate));
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Editar")]
        [HttpPut]
        public async Task<IActionResult> Put(GraduateDto graduateDto) {
            var graduate = _mapper.Map<Graduate>(graduateDto);
            return Response(await _graduateService.Update(graduate));
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Excluir")]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) {
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
        public async Task<IActionResult> Get() {
            return Response(await _graduateService.Get());
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Consultar")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) {
            return Response(await _graduateService.Get(id));
        }
    }
}