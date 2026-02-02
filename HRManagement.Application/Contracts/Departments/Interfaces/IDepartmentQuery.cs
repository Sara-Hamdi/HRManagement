using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Departments.Dtos.QueryDtos;
using HRManagement.Application.Contracts.Departments.Dtos.ResponseDtos;

namespace HRManagement.Application.Contracts.Departments.Interfaces
{
    public interface IDepartmentQuery
    {
        Task<PaginatedResult<DepartmentResponseDto>> GetDepartmentsAsync(DepartmentQueryDto dto);
    }
}
