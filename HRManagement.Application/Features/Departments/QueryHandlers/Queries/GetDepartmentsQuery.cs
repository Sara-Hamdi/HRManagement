using HRManagement.Application.Baeses;
using HRManagement.Application.Features.Departments.QueryHandlers.Responses;
using MediatR;

namespace HRManagement.Application.Features.Departments.QueryHandlers.Queries
{
    public class GetDepartmentsQuery : PaginatingQueryDto, IRequest<PaginatedResult<DepartmentResponseDto>>
    {
    }
}
