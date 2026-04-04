using AutoMapper;
using HRManagement.Application.Baeses;
using HRManagement.Application.Features.Departments.QueryHandlers.Queries;
using HRManagement.Application.Features.Departments.QueryHandlers.Responses;
using HRManagement.Domain.Aggregates.DepartmentAggregate;
using MediatR;

namespace HRManagement.Application.Features.Departments.QueryHandlers.Handlers
{
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, PaginatedResult<DepartmentResponseDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public GetDepartmentsQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<DepartmentResponseDto>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetDepartmentsAsync(request.PageSize, request.PageNumber, request.SortingDirection, request.SearchKey);
            var mappedList = _mapper.Map<List<Department>, List<DepartmentResponseDto>>(departments.departments);
            return new PaginatedResult<DepartmentResponseDto>(mappedList, departments.totalCount);

        }
    }
}
