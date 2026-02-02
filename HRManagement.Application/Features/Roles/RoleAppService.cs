using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Roles.Dtos.QueryDtos;
using HRManagement.Application.Contracts.Roles.Dtos.ResponseDtos;
using HRManagement.Application.Contracts.Roles.Interfaces;

namespace HRManagement.Application.Features.Roles
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IRoleQuery _roleQuery;
        public RoleAppService(IRoleQuery roleQuery)
        {
            _roleQuery = roleQuery;
        }
        public async Task<PaginatedResult<RoleResponseDto>> GetRolesAsync(RoleQueryDto dto)
        {
            return await _roleQuery.GetRolesAsync(dto);
        }
    }
}
