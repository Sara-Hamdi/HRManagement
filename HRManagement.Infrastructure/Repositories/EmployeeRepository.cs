using HRManagement.Domain.Aggregates.EmployeesAggregates;
using HRManagement.Domain.ViewModels;
using HRManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<EmployeeViewModel>> GetEmployeesAsync()
        {
            var query = from employee in _dbContext.Employees
                        join department in _dbContext.Departments on employee.DepartmentId equals department.Id
                        join position in _dbContext.Positions on employee.PositionId equals position.Id
                        join address in _dbContext.Addresses on employee.AddressId equals address.Id
                        select new EmployeeViewModel
                        {
                            FullName = employee.FullName!,
                            NetSalary = employee.NetSalary!,
                            GrossSalary = employee.GrossSalary!,
                            PhoneNumber = employee.PhoneNumber!,
                            Department = department.NameEn,
                            Position = position.NameEn,
                            Address = new AddressViewModel
                            {
                                City = address.City,
                                Region = address.Region,
                                Notes = address.Notes,
                            }
                        };
            return await query.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            var query = from employee in _dbContext.Employees
                        join department in _dbContext.Departments.AsNoTracking() on employee.DepartmentId equals department.Id
                        join position in _dbContext.Positions.AsNoTracking() on employee.PositionId equals position.Id
                        join address in _dbContext.Addresses.AsNoTracking() on employee.AddressId equals address.Id
                        where employee.Id == id
                        select employee;
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Guid> CreateEmployeeAsync(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<Employee?> GetEmployeeByNationalId(string nationalId)
        {
            var employee = await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.NationalId == nationalId);
            return employee;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<Guid> DeleteEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return employee.Id;
        }
    }
}
