using HRManagement.Application.Baeses;
using HRManagement.Application.Features.Departments.CommandsHandlers.Commands;
using HRManagement.Application.Features.Departments.QueryHandlers.Queries;
using HRManagement.Application.Features.Departments.QueryHandlers.Responses;

namespace HRManagement.Application.Departments.Interfaces
{
    public interface IDepartmentAppService
    {
        Task<Guid> CreateDepartmentAsync(CreateDepartmentCommand request);
        Task<PaginatedResult<DepartmentResponseDto>> GetDepartmentsAsync(GetDepartmentsQuery request);
    }
}
