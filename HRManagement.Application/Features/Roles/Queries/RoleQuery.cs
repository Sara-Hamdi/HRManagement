using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Roles.Dtos.QueryDtos;
using HRManagement.Application.Contracts.Roles.Dtos.ResponseDtos;
using HRManagement.Application.Contracts.Roles.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Application.Features.Roles.Queries
{
    public class RoleQuery : IRoleQuery
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleQuery(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<PaginatedResult<RoleResponseDto>> GetRolesAsync(RoleQueryDto dto)
        {
            var roles = _roleManager.Roles;
            if (!string.IsNullOrEmpty(dto.SearchKey))
            {
                roles = roles.Where(r => r.Name != null && r.Name.Contains(dto.SearchKey, StringComparison.OrdinalIgnoreCase));
            }
            roles = dto.SortingDirection == Shared.Enums.SortingDirection.DESC
                ? roles.OrderByDescending(r => r.Name)
                : roles.OrderBy(r => r.Name);
            var paginatedRoles = await roles
                .Skip((dto.PageNumber - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .Select(r => new RoleResponseDto
                {
                    Id = new Guid(r.Id),
                    Name = r.Name ?? string.Empty
                }).ToListAsync();
            return new PaginatedResult<RoleResponseDto>(paginatedRoles, roles.Count());
        }
    }
}
