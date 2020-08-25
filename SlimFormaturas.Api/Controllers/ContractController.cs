using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Dto.Contract;
using System.Collections.Generic;
using AutoMapper;
using SlimFormaturas.Domain.Dto.Contract.Response;

namespace SlimFormaturas.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class ContractController : ApiController {

        readonly IContractService _contractService;
        readonly IMapper _mapper;

        public ContractController (
            IContractService contractService,
            NotificationHandler notifications,
            IMapper mapper
            ) : base(notifications) {
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpPost("InsertNew")]
        public async Task<ActionResult<ContractResponse>> Post([FromBody]ContractForCreationDto contractDto) {
            return Response(await _contractService.Insert(contractDto));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ContractResponse>> Put([FromBody] ContractDto contractDto) {
            return Response(await _contractService.Update(contractDto));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ContractDto>> Get(){
            return Response(_mapper.Map<IList<ContractDto>>(await _contractService.Get()));
        }

        [HttpGet("GetAllById/{id}")]
        public async Task<ActionResult<ContractDto>> Get(string id){
            return Response(_mapper.Map<ContractDto>(await _contractService.GetAllById(id)));
        }


        [HttpGet("GetByAnyKey/{Key}")]
        public async Task<ActionResult<ContractSearchResponse>> GetByAnyKey(string Key) {
            return Response(await _contractService.GetByAnyKey(Key));
        }
    }
}