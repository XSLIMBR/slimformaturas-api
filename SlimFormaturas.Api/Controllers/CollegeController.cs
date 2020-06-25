using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlimFormaturas.Domain.Dto.College;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] CollegeForCreationDto companyForCreationDto) {
            var College = _mapper.Map<College>(companyForCreationDto);
            _ = await _CollegeService.Insert(College);
            return Response(College.CollegeId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Editar")]
        [HttpPut]
        public async Task<IActionResult> Put ([FromBody] CollegeDto CollegeDto) {
            _ = await _CollegeService.Update(CollegeDto);
            return Response(CollegeDto.CollegeId);
        }

        // [CustomAuthorize.ClaimsAuthorizeAttribute("Graduate", "Consultar")]
        [HttpGet]
        public async Task<ActionResult<CollegeDto>> Get () {
            var shippingCompanies = _mapper.Map<IList<CollegeDto>>(await _CollegeService.Get());
            return Response(shippingCompanies);

        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Consultar")]
        [HttpGet("{id}")]
        public async Task<ActionResult<CollegeDto>> Get (string id) {
            var College = _mapper.Map<CollegeDto>(await _CollegeService.GetAllById(id));
            return Response(College);
        }
    }
}
