using HRManagement.Domain.Aggregates.EmployeeAggregate;
using HRManagement.Shared;
using System.ComponentModel.DataAnnotations;
namespace HRManagement.Domain.Aggregates.DepartmentAggregate
{
    public class Department
    {
        public Guid Id { get; private set; }
        [StringLength(Constants.StringLengths.SmallLength)]
        public string NameAr { get; private set; } = string.Empty;
        [StringLength(Constants.StringLengths.SmallLength)]
        public string NameEn { get; private set; } = string.Empty;

        public IReadOnlyCollection<Employee> Employees => _employees;

        private readonly List<Employee> _employees = new();
        public Department(Guid id, string nameAr, string nameEn)
        {
            Id = id;
            NameAr = nameAr;
            NameEn = nameEn;
        }
        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

    }
}
