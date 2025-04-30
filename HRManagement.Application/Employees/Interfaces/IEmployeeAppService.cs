using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Application.Employees.Dtos.ResponseDtos;

namespace HRManagement.Application.Employees.Interfaces
{
    public interface IEmployeeAppService
    {
        Task<List<EmployeeResponseDto>> GetEmployeesAsync(Guid? departmentId = null);
        Task<PaginatedResult<EmployeeResponseDto>> GetEmployeesPaginatedAsync(EmployeeQueryDto request);
        Task<EmployeeResponseDto> GetEmployeeByIdAsync(Guid id);
        Task<Guid> CreateEmployee(CreateEmployeeRequestDto request);
        Task<Guid> UpdateEmployee(UpdateEmployeeRequestDto request);
        Task<Guid> DeleteEmployeeAsync(DeleteEmployeeRequestDto request);

    }
}
