using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Employees.Dtos.RequestDtos;
using HRManagement.Application.Contracts.Employees.Dtos.ResponseDtos;

namespace HRManagement.Application.Contracts.Employees.Interfaces
{
    public interface IEmployeeQuery
    {
        Task<List<EmployeeResponseDto>> GetEmployeesAsync(Guid? departmentId = null);
        Task<EmployeeResponseDto> GetEmployeeByIdAsync(Guid id);
        Task<PaginatedResult<EmployeeResponseDto>> GetEmployeesPaginatedAsync(EmployeeQueryDto dto);
    }
}
