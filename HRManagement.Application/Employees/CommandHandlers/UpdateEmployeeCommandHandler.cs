using AutoMapper;
using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Domain.Aggregates.EmployeesAggregates;
using MediatR;

namespace HRManagement.Application.Employees.CommandHandlers
{
    public class UpdateEmployeeCommandHandler : ResponseHandler, IRequestHandler<UpdateEmployeeRequestDto, Response<Guid>>
    {
        private readonly EmployeeManager _employeeManager;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;


        public UpdateEmployeeCommandHandler(EmployeeManager employeeManager, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _employeeManager = employeeManager;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public async Task<Response<Guid>> Handle(UpdateEmployeeRequestDto request, CancellationToken cancellationToken)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (existingEmployee == null)
            {
                return NotFound<Guid>($"cannot find an employee with id {request.Id}");
            }
            var employee = _mapper.Map<UpdateEmployeeRequestDto, Employee>(request);
            return Success(await _employeeManager.UpdateEmployeeAsync(employee));
        }
    }
}
