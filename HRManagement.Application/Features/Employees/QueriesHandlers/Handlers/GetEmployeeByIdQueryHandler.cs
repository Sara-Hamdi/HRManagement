using AutoMapper;
using HRManagement.Application.Features.Employees.QueriesHandlers.Queries;
using HRManagement.Application.Features.Employees.QueriesHandlers.Responses;
using HRManagement.Domain.Aggregates.EmployeeAggregate;
using HRManagement.Domain.ViewModels;
using MediatR;

namespace HRManagement.Application.Features.Employees.QueriesHandlers.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponseDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeResponseDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeWithDetailsAsync(request.Id);
            return _mapper.Map<EmployeeViewModel, EmployeeResponseDto>(employee);
        }
    }
}
