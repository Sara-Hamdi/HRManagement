using HRManagement.Application.Baeses;
using HRManagement.Application.Features.Employees.CommandHandlers.Commands;
using HRManagement.Application.Features.Employees.QueriesHandlers.Queries;
using HRManagement.Application.Features.Employees.QueriesHandlers.Responses;

namespace HRManagement.Application.Contracts.Employees.Interfaces
{
    public interface IEmployeeAppService
    {
        Task<PaginatedResult<EmployeeResponseDto>> GetEmployeesAsync(GetEmployeesQuery request);
        Task<EmployeeResponseDto> GetEmployeeByIdAsync(GetEmployeeByIdQuery request);
        Task<Guid> CreateEmployee(CreateEmployeeCommand request);
        Task<Guid> UpdateEmployee(UpdateEmployeeCommand request);
        Task<Guid> DeleteEmployeeAsync(DeleteEmployeeCommand request);


    }
}
