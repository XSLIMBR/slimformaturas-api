using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Dto.Contract;

namespace SlimFormaturas.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ApiController {

        readonly IContractService _contractService;

        public ContractController (
            IContractService contractService,
            NotificationHandler notifications
            ) : base(notifications) {
            _contractService = contractService;
        }

        [HttpPost("InsertNew")]
        public async Task<IActionResult> Post([FromBody]ContractForCreationDto contractDto) {
            return Response((await _contractService.Insert(contractDto)).ContractId);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] ContractDto contractDto) {
            return Response((await _contractService.Update(contractDto)).ContractId);
        }
    }
}