using AutoMapper;
using HRManagement.Application.Baeses;
using HRManagement.Application.Features.Employees.QueriesHandlers.Queries;
using HRManagement.Application.Features.Employees.QueriesHandlers.Responses;
using HRManagement.Domain.Aggregates.EmployeeAggregate;
using HRManagement.Domain.ViewModels;
using MediatR;

namespace HRManagement.Application.Features.Employees.QueriesHandlers.Handlers
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, PaginatedResult<EmployeeResponseDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<EmployeeResponseDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetEmployeesPaginatedAsync(request.PageSize, request.PageNumber, request.SortingDirection, request.DepartmentId, request.SearchKey);
            var employees = _mapper.Map<List<EmployeeViewModel>, List<EmployeeResponseDto>>(result.employees);
            return new PaginatedResult<EmployeeResponseDto>(employees, result.totalCount);
        }
    }
}
