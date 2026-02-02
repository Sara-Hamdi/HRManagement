using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Departments.Dtos.QueryDtos;
using HRManagement.Application.Contracts.Departments.Dtos.RequestDtos;
using HRManagement.Application.Contracts.Departments.Dtos.ResponseDtos;

namespace HRManagement.Application.Contracts.Departments.Interfaces
{
    public interface IDepartmentAppService
    {
        Task<Guid> CreateDepartmentAsync(CreateDepartmentRequestDto request);
        Task<PaginatedResult<DepartmentResponseDto>> GetDepartmentsAsync(DepartmentQueryDto request);
    }
}
