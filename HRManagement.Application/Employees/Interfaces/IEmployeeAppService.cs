using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Application.Employees.Dtos.ResponseDtos;

namespace HRManagement.Application.Employees.Interfaces
{
    public interface IEmployeeAppService
    {
        Task<Response<List<EmployeeResponseDto>>> GetEmployeesAsync();
        Task<Response<EmployeeResponseDto>> GetEmployeeByIdAsync(Guid id);
        Task<Response<Guid>> CreateEmployee(CreateEmployeeRequestDto request);
        Task<Response<Guid>> UpdateEmployee(UpdateEmployeeRequestDto request);
        Task<Response<Guid>> DeleteEmployeeAsync(DeleteEmployeeRequestDto request);

    }
}
