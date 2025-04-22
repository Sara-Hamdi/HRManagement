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
        public async Task<Response<List<EmployeeResponseDto>>> GetEmployeesAsync()
        {
            return await _employeeService.GetEmployeesAsync();

        }
        [HttpGet("{id}")]
        public async Task<Response<EmployeeResponseDto>> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeeService.GetEmployeeByIdAsync(id);
        }
        [HttpPost]
        public async Task<Response<Guid>> CreateEmployeeAsync([FromBody] CreateEmployeeRequestDto request)
        {

            return await _employeeService.CreateEmployee(request);

        }

        [HttpPut("{id}")]
        public async Task<Response<Guid>> UpdateEmployeeAsync([FromRoute] Guid id, [FromBody] UpdateEmployeeRequestDto request)
        {
            request.Id = id;
            return await _employeeService.UpdateEmployee(request);
        }
        [HttpDelete("{id}")]
        public async Task<Response<Guid>> DeleteEmployeeAsync(Guid id)
        {

            return await _employeeService.DeleteEmployeeAsync(new DeleteEmployeeRequestDto { Id = id });
        }
    }
}
