using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Employees.Interfaces;
using HRManagement.Application.Features.Employees.CommandHandlers.Commands;
using HRManagement.Application.Features.Employees.QueriesHandlers.Queries;
using HRManagement.Application.Features.Employees.QueriesHandlers.Responses;
using HRManagement.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controllers
{
    [Route("hr-management/api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAppService _employeeService;
        public EmployeeController(IEmployeeAppService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Authorize(Roles = Constants.Roles.Admin + "," + Constants.Roles.TeamLeader)]
        public async Task<PaginatedResult<EmployeeResponseDto>> GetEmployeesAsync([FromQuery] GetEmployeesQuery request)
        {
            return await _employeeService.GetEmployeesAsync(request);

        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync([FromRoute] Guid id)
        {
            return await _employeeService.GetEmployeeByIdAsync(new GetEmployeeByIdQuery() { Id = id });
        }
        [HttpPost]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<Guid> CreateEmployeeAsync([FromBody] CreateEmployeeCommand request)
        {

            return await _employeeService.CreateEmployee(request);

        }

        [HttpPut("{id}")]
        public async Task<Guid> UpdateEmployeeAsync([FromRoute] Guid id, [FromBody] UpdateEmployeeCommand request)
        {
            request.Id = id;
            return await _employeeService.UpdateEmployee(request);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<Guid> DeleteEmployeeAsync(Guid id)
        {
            return await _employeeService.DeleteEmployeeAsync(new DeleteEmployeeCommand { Id = id });
        }
    }
}
