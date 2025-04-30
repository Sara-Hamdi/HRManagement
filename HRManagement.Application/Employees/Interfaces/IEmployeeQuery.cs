using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Application.Employees.Dtos.ResponseDtos;

namespace HRManagement.Application.Employees.Interfaces
{
    public interface IEmployeeQuery
    {
        Task<List<EmployeeResponseDto>> GetEmployeesAsync(Guid? departmentId = null);
        Task<EmployeeResponseDto> GetEmployeeByIdAsync(Guid id);
        Task<PaginatedResult<EmployeeResponseDto>> GetEmployeesPaginatedAsync(EmployeeQueryDto dto);
    }
}
