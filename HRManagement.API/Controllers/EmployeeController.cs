using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Application.Employees.Dtos.ResponseDtos;
using HRManagement.Application.Employees.Interfaces;
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
        public async Task<List<EmployeeResponseDto>> GetEmployeesAsync([FromQuery] Guid? departmentId)
        {
            return await _employeeService.GetEmployeesAsync(departmentId);

        }
        [HttpGet]
        [Route("paginated")]
        public async Task<PaginatedResult<EmployeeResponseDto>> GetEmployeesPaginatedAsync([FromQuery] EmployeeQueryDto request)
        {
            return await _employeeService.GetEmployeesPaginatedAsync(request);

        }
        [HttpGet("{id}")]
        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync([FromRoute] Guid id)
        {
            return await _employeeService.GetEmployeeByIdAsync(id);
        }
        [HttpPost]
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
        public async Task<Guid> DeleteEmployeeAsync(Guid id)
        {
            return await _employeeService.DeleteEmployeeAsync(new DeleteEmployeeRequestDto { Id = id });
        }
    }
}
