using AutoMapper;
using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Domain.Aggregates.EmployeesAggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Employees.CommandHandlers
{
    public class CreateEmployeeCommandHandler : ResponseHandler, IRequestHandler<CreateEmployeeRequestDto, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly EmployeeManager _employeeManager;
        
        
        public CreateEmployeeCommandHandler(IMapper mapper,EmployeeManager employeeManager) 
        {
            _mapper = mapper;
            _employeeManager = employeeManager;
        }
        public async Task<Response<Guid>> Handle(CreateEmployeeRequestDto request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<CreateEmployeeRequestDto, Employee>(request);
            if(await _employeeManager.CheckIfEmployeeExist(request.NationalId))
            {
                return BadRequest<Guid>("Employee already exist");
            }
            var id = await _employeeManager.CreateEmployeeAsync(employee);
            return Created(id);

        }
    }
}
