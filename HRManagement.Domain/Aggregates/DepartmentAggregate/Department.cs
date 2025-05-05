using HRManagement.Domain.Aggregates.EmployeesAggregates;
using HRManagement.Domain.Shared;
using System.ComponentModel.DataAnnotations;
namespace HRManagement.Domain.Aggregates.Departments
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

    }
}
