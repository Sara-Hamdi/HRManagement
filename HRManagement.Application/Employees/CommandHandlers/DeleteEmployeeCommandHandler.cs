using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Domain.Aggregates.EmployeesAggregates;
using MediatR;

namespace HRManagement.Application.Employees.CommandHandlers
{
    public class DeleteEmployeeCommandHandler : ResponseHandler, IRequestHandler<DeleteEmployeeRequestDto, Response<Guid>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Baeses.Response<Guid>> Handle(DeleteEmployeeRequestDto request, CancellationToken cancellationToken)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (existingEmployee == null)
            {
                return NotFound<Guid>($"cannot find an employee with id {request.Id}");
            }
            return Success<Guid>(await _employeeRepository.DeleteEmployeeAsync(existingEmployee));

        }
    }
}
