using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;
using SlimFormaturas.Domain.Dto.Employee;
using SlimFormaturas.Domain.Dto.Employee.Response;

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
        public async Task<ActionResult<EmployeeResponse>> Post([FromBody]EmployeeForCreationDto EmployeeDto) {
            var Employee = _mapper.Map<Employee>(EmployeeDto);
            return Response(await _employeeService.Insert(Employee));
        }

        //[CustomAuthorize.ClaimsAuthorize("Employee", "Editar")]
        [HttpPut]
        public async Task<ActionResult<EmployeeResponse>> Put([FromBody]EmployeeDto EmployeeDto) {
            return Response(await _employeeService.Update(EmployeeDto));
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