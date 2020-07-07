using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;
using SlimFormaturas.Domain.Dto.Graduate;
using SlimFormaturas.Domain.Dto.Contract;

namespace SlimFormaturas.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ApiController {

        readonly IContractService _contractService;
        readonly IMapper _mapper;

        public ContractController (
            IContractService contractService,
            NotificationHandler notifications,
            IMapper mapper
            ) : base(notifications) {
            _mapper = mapper;
            _contractService = contractService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ContractForCreationDto contractDto)
        {
            var contract = _mapper.Map<Contract>(contractDto);
            _ = await _contractService.Insert(contract);
            return Response(contract.ContractId);
        }
    }
}