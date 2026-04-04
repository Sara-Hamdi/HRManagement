using HRManagement.Application.Contracts.Roles.Dtos.QueryDtos;
using HRManagement.Application.Contracts.Roles.Dtos.ResponseDtos;
using HRManagement.Contract.Baeses;

namespace HRManagement.Application.Contracts.Roles.Interfaces
{
    public interface IRoleAppService
    {
        Task<PaginatedResult<RoleResponseDto>> GetRolesAsync(RoleQueryDto request);
    }
}
