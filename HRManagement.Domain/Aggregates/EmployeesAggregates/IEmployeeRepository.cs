using HRManagement.Domain.ViewModels;

namespace HRManagement.Domain.Aggregates.EmployeesAggregates
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeViewModel>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<Guid> CreateEmployeeAsync(Employee employee);
        Task<Employee?> GetEmployeeByNationalId(string nationalId);
        Task UpdateEmployeeAsync(Employee employee);
        Task<Guid> DeleteEmployeeAsync(Employee employee);

    }
}
