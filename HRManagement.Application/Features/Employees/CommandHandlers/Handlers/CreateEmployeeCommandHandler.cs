using AutoMapper;
using HRManagement.Application.Features.Employees.CommandHandlers.Commands;
using HRManagement.Domain.Aggregates.EmployeeAggregate;
using HRManagement.Shared;
using HRManagement.Shared.Exceptions;
using MediatR;

namespace HRManagement.Application.Features.Employees.CommandHandlers.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly EmployeeManager _employeeManager;


        public CreateEmployeeCommandHandler(IMapper mapper, EmployeeManager employeeManager)
        {
            _mapper = mapper;
            _employeeManager = employeeManager;
        }
        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<CreateEmployeeCommand, Employee>(request);

            if (await _employeeManager.CheckIfEmployeeExist(request.NationalId!) != null)
            {
                throw new BusinessException(Constants.ErrorCodes.EmployeeAlreadyExists);
            }
            var id = await _employeeManager.CreateEmployeeAsync(employee);
            return id;

        }
    }
}
