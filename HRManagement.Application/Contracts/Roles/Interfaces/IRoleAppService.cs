using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Roles.Dtos.QueryDtos;
using HRManagement.Application.Contracts.Roles.Dtos.ResponseDtos;

namespace HRManagement.Application.Contracts.Roles.Interfaces
{
    public interface IRoleAppService
    {
        Task<PaginatedResult<RoleResponseDto>> GetRolesAsync(RoleQueryDto request);
    }
}
