using HRManagement.Application.Baeses;
using HRManagement.Application.Features.Roles.QueryHandlers.Queries;
using HRManagement.Application.Features.Roles.QueryHandlers.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Application.Features.Roles.QueryHandlers.Handlers
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, PaginatedResult<RoleResponseDto>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public GetRolesQueryHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<PaginatedResult<RoleResponseDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = _roleManager.Roles;
            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                roles = roles.Where(r => r.Name != null && r.Name.Contains(request.SearchKey, StringComparison.OrdinalIgnoreCase));
            }
            roles = request.SortingDirection == Shared.Enums.SortingDirection.DESC
                ? roles.OrderByDescending(r => r.Name)
                : roles.OrderBy(r => r.Name);
            var paginatedRoles = await roles
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(r => new RoleResponseDto
                {
                    Id = new Guid(r.Id),
                    Name = r.Name ?? string.Empty
                }).ToListAsync();
            return new PaginatedResult<RoleResponseDto>(paginatedRoles, roles.Count());
        }
    }

}
