using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Departments.Dtos.QueryDtos;
using HRManagement.Application.Contracts.Departments.Dtos.RequestDtos;
using HRManagement.Application.Contracts.Departments.Dtos.ResponseDtos;
using HRManagement.Application.Contracts.Departments.Interfaces;
using MediatR;

namespace HRManagement.Application.Features.Departments
{
    public class DepartmentAppService : IDepartmentAppService
    {
        private readonly IMediator _mediator;
        private readonly IDepartmentQuery _departmentQuery;
        public DepartmentAppService(IMediator mediator, IDepartmentQuery departmentQuery)
        {
            _mediator = mediator;
            _departmentQuery = departmentQuery;
        }

        public async Task<Guid> CreateDepartmentAsync(CreateDepartmentRequestDto request)
        {
            return await _mediator.Send(request);
        }

        public async Task<PaginatedResult<DepartmentResponseDto>> GetDepartmentsAsync(DepartmentQueryDto request)
        {
            return await _departmentQuery.GetDepartmentsAsync(request);
        }
    }
}
