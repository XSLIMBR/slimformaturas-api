using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;
using SlimFormaturas.Domain.Dto.Employee;

namespace SlimFormaturas.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : ApiController {
         readonly IEmployeeService _employeeService;
         readonly IMapper _mapper;

        public EmployeeController(
            IEmployeeService employeeService,
            NotificationHandler notifications,
            IMapper mapper
            ) : base (notifications)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Inserir um novo formando na base teste
        /// </summary>
        /// <returns>O id do novo formando inserido</returns>
        //[CustomAuthorize.ClaimsAuthorize("Employee", "Incluir")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EmployeeForCreationDto EmployeeDto) {
            var Employee = _mapper.Map<Employee>(EmployeeDto);
            _ = await _employeeService.Insert(Employee);
            return Response(Employee.EmployeeId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Employee", "Editar")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]EmployeeDto EmployeeDto) {
            _ = await _employeeService.Update(EmployeeDto);
            return Response(EmployeeDto.EmployeeId);
        }

        //[CustomAuthorize.ClaimsAuthorize("Employee", "Excluir")]
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id) {
            //await _EmployeeService.Delete(id);
            //return Response("Success");
        //}

        // GET api/Employee
        /// <summary>
        /// Get all Employees
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        /// 
       // [CustomAuthorize.ClaimsAuthorizeAttribute("Employee", "Consultar")]
        [HttpGet]
        public async Task<ActionResult<EmployeeDto>> Get() {
            var Employee = _mapper.Map<IList<EmployeeDto>>(await _employeeService.Get());
            return Response(Employee);

        }

        //[CustomAuthorize.ClaimsAuthorize("Employee", "Consultar")]
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(string id) {
            var Employee = _mapper.Map<EmployeeDto>(await _employeeService.GetAllById(id));
            return Response(Employee);
        }
    }
}