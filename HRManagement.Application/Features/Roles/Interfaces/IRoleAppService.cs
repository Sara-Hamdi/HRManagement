using HRManagement.Application.Baeses;
using HRManagement.Application.Features.Roles.QueryHandlers.Queries;
using HRManagement.Application.Features.Roles.QueryHandlers.Responses;

namespace HRManagement.Application.Contracts.Roles.Interfaces
{
    public interface IRoleAppService
    {
        Task<PaginatedResult<RoleResponseDto>> GetRolesAsync(GetRolesQuery request);
    }
}
