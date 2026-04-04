using HRManagement.Application.Baeses;
using HRManagement.Application.Features.Roles.QueryHandlers.Responses;
using MediatR;

namespace HRManagement.Application.Features.Roles.QueryHandlers.Queries
{
    public class GetRolesQuery : PaginatingQueryDto, IRequest<PaginatedResult<RoleResponseDto>>
    {
    }
}
