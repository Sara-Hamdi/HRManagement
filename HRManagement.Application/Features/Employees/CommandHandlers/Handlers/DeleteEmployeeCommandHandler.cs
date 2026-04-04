using HRManagement.Application.Features.Employees.CommandHandlers.Commands;
using HRManagement.Domain.Aggregates.EmployeeAggregate;
using MediatR;

namespace HRManagement.Application.Features.Employees.CommandHandlers.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Guid>
    {
        private readonly EmployeeManager _employeeManager;

        public DeleteEmployeeCommandHandler(EmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        public async Task<Guid> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _employeeManager.DeleteEmployeeAsync(request.Id);

        }
    }
}
