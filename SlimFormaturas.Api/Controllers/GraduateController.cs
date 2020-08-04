using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using SlimFormaturas.Domain.Dto.Graduate;

namespace SlimFormaturas.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [Consumes("application/json")]
    public class GraduateController : ApiController {
        readonly IGraduateService _graduateService;
        readonly IMapper _mapper;

        public GraduateController(
            IGraduateService graduateService,
            NotificationHandler notifications,
            IMapper mapper
            ) : base (notifications) {
            
            _graduateService = graduateService;
            _mapper = mapper;
        }

        /// <summary>
        /// Buscar todos os formandos com paginacao
        /// </summary>
        /// <returns>Os formandos encontrados</returns>
        [HttpGet("GetAllWithPagination")]
        public async Task<ActionResult<GraduateSearchResponse>> Search(int pageNumber, int pageSize) {

            var graduatesGet = await _graduateService.Get();

            var paginatedGraduates = _graduateService.PaginatedList(graduatesGet, pageNumber, pageSize);

            var result = _mapper.Map<IList<GraduateSearchResponse>>((List<Graduate>)paginatedGraduates);

            object response = new {
                totalData = graduatesGet.Count,
                data = result
            };

            return Response(response);
        }

        /// <summary>
        /// Buscar formando com filtros especificos com paginacao
        /// </summary>
        /// <returns>Os formandos encontrados</returns>
        [HttpPost("SearchWithPagination")]
        public async Task<ActionResult<GraduateSearchResponse>> Search(GraduateSearch data) {
            var graduatesGet = await _graduateService.Search(data);

            var paginatedGraduates =
                _graduateService.PaginatedList(graduatesGet, data.PageNumber, data.PageSize);

            var result = _mapper.Map<IList<GraduateSearchResponse>>((List<Graduate>)paginatedGraduates);

            object response = new {
                totalData = graduatesGet.Count,
                data = result
            };

            return Response(response);
        }

        /// <summary>
        /// Inserir um novo formando na base
        /// </summary>
        /// <returns>O Id do novo formando</returns>
        /// <response code="200">Retorna se o novo formando for inserido</response>
        /// <response code="404">Se contiver dados invalidos</response>   
        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Incluir")]
        [HttpPost("InsertNew")]
        public async Task<IActionResult> Post([FromBody] GraduateForCreationDto graduateDto) {
            return Response((await _graduateService.Insert(graduateDto)).GraduateId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Editar")]
        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody]GraduateDto graduateDto) {
            return Response((await _graduateService.Update(graduateDto)).GraduateId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Excluir")]
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id) {
            //await _graduateService.Delete(id);
            //return Response("Success");
        //}

        // GET api/Graduate
        /// <summary>
        /// Retornar todos os dados de todos os formandos
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        /// 
       // [CustomAuthorize.ClaimsAuthorizeAttribute("Graduate", "Consultar")]
        [HttpGet("GetAll")]
        public async Task<ActionResult<GraduateDto>> Get() {
            var graduate = _mapper.Map<IList<GraduateDto>>(await _graduateService.Get());
            return Response(graduate);

        }

        // GET api/Graduate
        /// <summary>
        /// Retornar todos os dados de um formando especifico
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        /// 
        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Consultar")]
        [HttpGet("GetAllById/{id}")]
        public async Task<ActionResult<GraduateDto>> Get(string id) {
            var graduate = _mapper.Map<GraduateDto>(await _graduateService.GetAllById(id));
            return Response(graduate);
        }


    }
}