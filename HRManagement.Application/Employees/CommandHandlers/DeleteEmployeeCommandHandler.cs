using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Domain.Aggregates.EmployeesAggregates;
using MediatR;

namespace HRManagement.Application.Employees.CommandHandlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeRequestDto, Guid>
    {
        private readonly EmployeeManager _employeeManager;

        public DeleteEmployeeCommandHandler(EmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        public async Task<Guid> Handle(DeleteEmployeeRequestDto request, CancellationToken cancellationToken)
        {
            return await _employeeManager.DeleteEmployeeAsync(request.Id);

        }
    }
}
