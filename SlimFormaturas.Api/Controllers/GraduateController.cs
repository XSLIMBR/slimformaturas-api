using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;
using SlimFormaturas.Domain.Dto.Graduate;

namespace SlimFormaturas.Api.Controllers {
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
        /// Buscar formando com filtros especificos
        /// </summary>
        /// <returns>Os formandos encontrados</returns>
        [HttpPost("Search")]
        public async Task<ActionResult<GraduateSearchResponse>> Search(GraduateSearch data) {
            return Response(await _graduateService.Search(data));
        }

        /// <summary>
        /// Inserir um novo formando na base
        /// </summary>
        /// <returns>O id do novo formando inserido</returns>
        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Incluir")]
        [HttpPost("InsertNew")]
        public async Task<IActionResult> Post([FromBody] GraduateForCreationDto graduateDto) {
            return Response((await _graduateService.Insert(graduateDto)).GraduateId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Editar")]
        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody]GraduateDto graduateDto) {
            _ = await _graduateService.Update(graduateDto);
            return Response(graduateDto.GraduateId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Excluir")]
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id) {
            //await _graduateService.Delete(id);
            //return Response("Success");
        //}

        // GET api/Graduate
        /// <summary>
        /// Get all graduates
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        /// 
       // [CustomAuthorize.ClaimsAuthorizeAttribute("Graduate", "Consultar")]
        [HttpGet("GetAll")]
        public async Task<ActionResult<GraduateDto>> Get() {
            var graduate = _mapper.Map<IList<GraduateDto>>(await _graduateService.Get());
            return Response(graduate);

        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Consultar")]
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<GraduateDto>> Get(string id) {
            var graduate = _mapper.Map<GraduateDto>(await _graduateService.GetAllById(id));
            return Response(graduate);
        }
    }
}