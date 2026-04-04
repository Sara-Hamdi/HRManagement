using HRManagement.Application.Baeses;
using HRManagement.Application.Features.Employees.QueriesHandlers.Responses;
using MediatR;

namespace HRManagement.Application.Features.Employees.QueriesHandlers.Queries
{
    public class GetEmployeesQuery : PaginatingQueryDto, IRequest<PaginatedResult<EmployeeResponseDto>>
    {
        public Guid? DepartmentId { get; set; }
    }
}
