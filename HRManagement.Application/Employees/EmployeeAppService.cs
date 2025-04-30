using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Application.Employees.Dtos.ResponseDtos;
using HRManagement.Application.Employees.Interfaces;
using MediatR;

namespace HRManagement.Application.Employees
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IEmployeeQuery _employeeQuery;
        private readonly IMediator _mediator;
        public EmployeeAppService(IEmployeeQuery employeeQuery, IMediator mediator)
        {
            _employeeQuery = employeeQuery;
            _mediator = mediator;
        }
        public async Task<List<EmployeeResponseDto>> GetEmployeesAsync(Guid? departmentId = null)
        {
            return await _employeeQuery.GetEmployeesAsync(departmentId);
        }
        public async Task<PaginatedResult<EmployeeResponseDto>> GetEmployeesPaginatedAsync(EmployeeQueryDto request)
        {
            return await _employeeQuery.GetEmployeesPaginatedAsync(request);

        }
        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeeQuery.GetEmployeeByIdAsync(id);
        }

        public async Task<Guid> CreateEmployee(CreateEmployeeRequestDto request)
        {
            return await _mediator.Send(request);
        }

        public async Task<Guid> UpdateEmployee(UpdateEmployeeRequestDto request)
        {
            return await _mediator.Send(request);
        }

        public Task<Guid> DeleteEmployeeAsync(DeleteEmployeeRequestDto request)
        {
            return _mediator.Send(request);
        }
    }
}
