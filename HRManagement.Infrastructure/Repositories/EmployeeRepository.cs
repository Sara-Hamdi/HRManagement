using HRManagement.Domain.Aggregates.EmployeesAggregates;
using HRManagement.Domain.Shared.Exceptions;
using HRManagement.Domain.ViewModels;
using HRManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static HRManagement.Domain.Shared.Enums;

namespace HRManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<EmployeeViewModel>> GetEmployeesAsync(Guid? departmentId = null)
        {
            var query = from employee in _dbContext.Employees.AsNoTracking()
                        join department in _dbContext.Departments.AsNoTracking() on employee.DepartmentId equals department.Id
                        join position in _dbContext.Positions.AsNoTracking() on employee.PositionId equals position.Id
                        join address in _dbContext.Addresses.AsNoTracking() on employee.AddressId equals address.Id
                        where departmentId == null || employee.DepartmentId == departmentId
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
            return await query.FirstOrDefaultAsync() ?? throw new EntityNotFoundException(nameof(Employee), id);
        }
        public async Task<(int totalCount, List<EmployeeViewModel> employees)> GetEmployeesPaginatedAsync(int pageSize, int pageNumber, SortingDirection? sortingDirection, Guid? departmentId = null, string? searchKey = null)
        {
            var query = from employee in _dbContext.Employees
                        join department in _dbContext.Departments.AsNoTracking() on employee.DepartmentId equals department.Id
                        join position in _dbContext.Positions.AsNoTracking() on employee.PositionId equals position.Id
                        join address in _dbContext.Addresses.AsNoTracking() on employee.AddressId equals address.Id
                        where departmentId == null || departmentId == employee.DepartmentId
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

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            var skipCount = (pageNumber - 1) * pageSize;
            if (searchKey != null)
            {
                query = query.Where(e => e.FullName.Contains(searchKey));
            }
            if (sortingDirection == SortingDirection.DESC)
            {
                query = query.OrderByDescending(e => e.FullName).Skip(skipCount).Take(pageSize);
            }
            else
            {
                query = query.OrderBy(e => e.FullName).Skip(skipCount).Take(pageSize);

            }
            var totalCount = await query.CountAsync();

            return (totalCount, await query.ToListAsync());
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
