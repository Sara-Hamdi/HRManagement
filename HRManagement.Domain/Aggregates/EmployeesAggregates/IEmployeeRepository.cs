using HRManagement.Domain.ViewModels;
using static HRManagement.Domain.Shared.Enums;

namespace HRManagement.Domain.Aggregates.EmployeesAggregates
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeViewModel>> GetEmployeesAsync(Guid? departmentId = null);
        Task<(int totalCount, List<EmployeeViewModel> employees)> GetEmployeesPaginatedAsync(int pageSize, int pageNumber, SortingDirection? sortingDirection, Guid? departmentId = null, string? searchKey = null);
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<Guid> CreateEmployeeAsync(Employee employee);
        Task<Employee?> GetEmployeeByNationalId(string nationalId);
        Task UpdateEmployeeAsync(Employee employee);
        Task<Guid> DeleteEmployeeAsync(Employee employee);

    }
}
