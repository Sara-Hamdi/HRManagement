using AutoMapper;
using HRManagement.Application.Features.Employees.CommandHandlers.Commands;
using HRManagement.Domain.Aggregates.EmployeeAggregate;
using MediatR;

namespace HRManagement.Application.Features.Employees.CommandHandlers.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Guid>
    {
        private readonly EmployeeManager _employeeManager;
        private readonly IMapper _mapper;


        public UpdateEmployeeCommandHandler(EmployeeManager employeeManager, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _employeeManager = employeeManager;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var employee = _mapper.Map<UpdateEmployeeCommand, Employee>(request);
            return await _employeeManager.UpdateEmployeeAsync(employee);
        }
    }
}
