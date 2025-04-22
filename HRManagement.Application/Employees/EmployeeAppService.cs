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
        public async Task<Response<List<EmployeeResponseDto>>> GetEmployeesAsync()
        {
            return await _employeeQuery.GetEmployeesAsync();
        }

        public async Task<Response<EmployeeResponseDto>> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeeQuery.GetEmployeeByIdAsync(id);
        }

        public async Task<Response<Guid>> CreateEmployee(CreateEmployeeRequestDto request)
        {
            return await _mediator.Send(request);
        }

        public async Task<Response<Guid>> UpdateEmployee(UpdateEmployeeRequestDto request)
        {
            return await _mediator.Send(request);
        }

        public Task<Response<Guid>> DeleteEmployeeAsync(DeleteEmployeeRequestDto request)
        {
            return _mediator.Send(request);
        }
    }
}
