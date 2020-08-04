using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlimFormaturas.Domain.Dto.College;
using SlimFormaturas.Domain.Dto.College.Response;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class CollegeController : ApiController
    {
        private readonly ICollegeService _CollegeService;
        readonly IMapper _mapper;

        public CollegeController(
            ICollegeService CollegeService,
            NotificationHandler notifications,
            IMapper mapper) : base (notifications){
            _CollegeService = CollegeService;
            _mapper = mapper;
        }

        [HttpPost("InsertNew")]
        public async Task<ActionResult<CollegeResponse>> Post ([FromBody] CollegeForCreationDto collegeForCreationDto) {
            return Response(await _CollegeService.Insert(collegeForCreationDto));
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Editar")]
        [HttpPut("Update")]
        public async Task<ActionResult<CollegeResponse>> Put ([FromBody] CollegeDto CollegeDto) {
            return Response(await _CollegeService.Update(CollegeDto));
        }

        // [CustomAuthorize.ClaimsAuthorizeAttribute("Graduate", "Consultar")]
        [HttpGet("GetAll")]
        public async Task<ActionResult<CollegeDto>> Get () {
            return Response(_mapper.Map<IList<CollegeDto>>(await _CollegeService.Get()));

        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Consultar")]
        [HttpGet("GetAllById/{id}")]
        public async Task<ActionResult<CollegeDto>> Get (string id) {
            return Response(_mapper.Map<CollegeDto>(await _CollegeService.GetAllById(id)));
        }
    }
}
