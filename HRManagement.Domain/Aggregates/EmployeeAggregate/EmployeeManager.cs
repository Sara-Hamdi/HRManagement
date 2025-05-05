using HRManagement.Domain.Shared.Exceptions;

namespace HRManagement.Domain.Aggregates.EmployeesAggregates
{
    public class EmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<bool> CheckIfEmployeeExist(string nationalId)
        {
            var employee = await _employeeRepository.GetEmployeeByNationalId(nationalId);
            return employee != null;

        }
        public async Task<Guid> CreateEmployeeAsync(Employee employee)
        {
            Employee newEmployee = new Employee("", employee.DepartmentId, employee.NetSalary, employee.GrossSalary, employee.PositionId, employee.NationalId);

            if (employee.Address != null)
            {
                newEmployee.AddAddress(employee.Address.City, employee.Address.Region, employee.Address.Notes);
            }
            return await _employeeRepository.CreateEmployeeAsync(newEmployee);
        }
        public async Task<Guid> UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(employee.Id);
            if (existingEmployee == null)
            {
                throw new EntityNotFoundException(employee.Id, nameof(Employee));
            }
            existingEmployee.Update(employee.DepartmentId, employee.NetSalary, employee.PositionId, employee.GrossSalary);
            if (existingEmployee.Address != null)
            {
                if (employee.Address != null)
                {
                    existingEmployee.Address.Update(employee.Address.City, employee.Address.Region, employee.Address.Notes);
                }
            }
            else
            {
                if (employee.Address != null)
                {
                    existingEmployee.AddAddress(employee.Address.City, employee.Address.Region, employee.Address.Notes);
                }
            }
            await _employeeRepository.UpdateEmployeeAsync(existingEmployee);
            return employee.Id;
        }
        public async Task<Guid> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
                throw new EntityNotFoundException(id, nameof(Employee));
            await _employeeRepository.DeleteEmployeeAsync(employee);
            return employee.Id;

        }
    }
}
