using AutoMapper;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Domain.Aggregates.EmployeesAggregates;
using HRManagement.Domain.Shared;
using HRManagement.Domain.Shared.Exceptions;
using MediatR;

namespace HRManagement.Application.Employees.CommandHandlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeRequestDto, Guid>
    {
        private readonly IMapper _mapper;
        private readonly EmployeeManager _employeeManager;


        public CreateEmployeeCommandHandler(IMapper mapper, EmployeeManager employeeManager)
        {
            _mapper = mapper;
            _employeeManager = employeeManager;
        }
        public async Task<Guid> Handle(CreateEmployeeRequestDto request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<CreateEmployeeRequestDto, Employee>(request);

            if (await _employeeManager.CheckIfEmployeeExist(request.NationalId!) != null)
            {
                throw new BusinessException(Constants.ErrorCodes.EmployeeAlreadyExists);
            }
            var id = await _employeeManager.CreateEmployeeAsync(employee);
            return id;

        }
    }
}
