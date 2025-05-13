using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Application.Employees.Dtos.ResponseDtos;
using HRManagement.Application.Employees.Interfaces;
using HRManagement.Domain.Shared;
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
        public async Task<List<EmployeeResponseDto>> GetEmployeesAsync([FromQuery] Guid? departmentId)
        {
            return await _employeeService.GetEmployeesAsync(departmentId);

        }
        [HttpGet]
        [Route("paginated")]
        [Authorize(Roles = Constants.Roles.Admin + "," + Constants.Roles.TeamLeader)]
        public async Task<PaginatedResult<EmployeeResponseDto>> GetEmployeesPaginatedAsync([FromQuery] EmployeeQueryDto request)
        {
            return await _employeeService.GetEmployeesPaginatedAsync(request);

        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync([FromRoute] Guid id)
        {
            return await _employeeService.GetEmployeeByIdAsync(id);
        }
        [HttpPost]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<Guid> CreateEmployeeAsync([FromBody] CreateEmployeeRequestDto request)
        {

            return await _employeeService.CreateEmployee(request);

        }

        [HttpPut("{id}")]
        public async Task<Guid> UpdateEmployeeAsync([FromRoute] Guid id, [FromBody] UpdateEmployeeRequestDto request)
        {
            request.Id = id;
            return await _employeeService.UpdateEmployee(request);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<Guid> DeleteEmployeeAsync(Guid id)
        {
            return await _employeeService.DeleteEmployeeAsync(new DeleteEmployeeRequestDto { Id = id });
        }
    }
}
