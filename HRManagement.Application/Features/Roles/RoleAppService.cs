using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Roles.Interfaces;
using HRManagement.Application.Features.Roles.QueryHandlers.Queries;
using HRManagement.Application.Features.Roles.QueryHandlers.Responses;
using MediatR;

namespace HRManagement.Application.Features.Roles
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IMediator _mediator;
        public RoleAppService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<PaginatedResult<RoleResponseDto>> GetRolesAsync(GetRolesQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
