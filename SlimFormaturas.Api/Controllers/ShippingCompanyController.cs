using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlimFormaturas.Domain.Dto.ShippingCompany;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingCompanyController : ApiController
    {
        private readonly IShippingCompanyService _shippingCompanyService;
        readonly IMapper _mapper;

        public ShippingCompanyController(
            IShippingCompanyService shippingCompanyService,
            NotificationHandler notifications,
            IMapper mapper) : base (notifications){
            _shippingCompanyService = shippingCompanyService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] ShippingCompanyForCreationDto companyForCreationDto) {
            var shippingCompany = _mapper.Map<ShippingCompany>(companyForCreationDto);
            _ = await _shippingCompanyService.Insert(shippingCompany);
            return Response(shippingCompany.ShippingCompanyId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Editar")]
        [HttpPut]
        public async Task<IActionResult> Put ([FromBody] ShippingCompanyDto shippingCompanyDto) {
            _ = await _shippingCompanyService.Update(shippingCompanyDto);
            return Response(shippingCompanyDto.ShippingCompanyId);
        }

        // [CustomAuthorize.ClaimsAuthorizeAttribute("Graduate", "Consultar")]
        [HttpGet]
        public async Task<ActionResult<ShippingCompanyDto>> Get () {
            var shippingCompanies = _mapper.Map<IList<ShippingCompanyDto>>(await _shippingCompanyService.Get());
            return Response(shippingCompanies);

        }

        //[CustomAuthorize.ClaimsAuthorize("Graduate", "Consultar")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingCompanyDto>> Get (string id) {
            var shippingCompany = _mapper.Map<ShippingCompanyDto>(await _shippingCompanyService.GetAllById(id));
            return Response(shippingCompany);
        }
    }
}
