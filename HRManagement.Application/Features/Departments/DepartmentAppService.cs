using HRManagement.Application.Baeses;
using HRManagement.Application.Departments.Interfaces;
using HRManagement.Application.Features.Departments.CommandsHandlers.Commands;
using HRManagement.Application.Features.Departments.QueryHandlers.Queries;
using HRManagement.Application.Features.Departments.QueryHandlers.Responses;
using MediatR;

namespace HRManagement.Application.Features.Departments
{
    public class DepartmentAppService : IDepartmentAppService
    {
        private readonly IMediator _mediator;
        public DepartmentAppService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Guid> CreateDepartmentAsync(CreateDepartmentCommand request)
        {
            return await _mediator.Send(request);
        }

        public async Task<PaginatedResult<DepartmentResponseDto>> GetDepartmentsAsync(GetDepartmentsQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
