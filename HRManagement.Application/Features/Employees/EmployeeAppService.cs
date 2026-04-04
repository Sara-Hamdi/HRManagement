using HRManagement.Application.Baeses;

using HRManagement.Application.Contracts.Employees.Interfaces;
using HRManagement.Application.Features.Employees.CommandHandlers.Commands;
using HRManagement.Application.Features.Employees.QueriesHandlers.Queries;
using HRManagement.Application.Features.Employees.QueriesHandlers.Responses;
using MediatR;

namespace HRManagement.Application.Features.Employees
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IMediator _mediator;
        public EmployeeAppService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<PaginatedResult<EmployeeResponseDto>> GetEmployeesAsync(GetEmployeesQuery request)
        {
            return await _mediator.Send(request);

        }
        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync(GetEmployeeByIdQuery request)
        {
            return await _mediator.Send(request);
        }

        public async Task<Guid> CreateEmployee(CreateEmployeeCommand request)
        {
            return await _mediator.Send(request);
        }

        public async Task<Guid> UpdateEmployee(UpdateEmployeeCommand request)
        {
            return await _mediator.Send(request);
        }

        public Task<Guid> DeleteEmployeeAsync(DeleteEmployeeCommand request)
        {
            return _mediator.Send(request);
        }
    }
}
