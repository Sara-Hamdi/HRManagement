using AutoMapper;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Domain.Aggregates.EmployeesAggregates;
using MediatR;

namespace HRManagement.Application.Employees.CommandHandlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeRequestDto, Guid>
    {
        private readonly EmployeeManager _employeeManager;
        private readonly IMapper _mapper;


        public UpdateEmployeeCommandHandler(EmployeeManager employeeManager, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _employeeManager = employeeManager;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(UpdateEmployeeRequestDto request, CancellationToken cancellationToken)
        {

            var employee = _mapper.Map<UpdateEmployeeRequestDto, Employee>(request);
            return await _employeeManager.UpdateEmployeeAsync(employee);
        }
    }
}
