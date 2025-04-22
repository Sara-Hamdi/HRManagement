using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManagement.Domain.Aggregates.EmployeesAggregates;
namespace HRManagement.Domain.Aggregates.Departments
{
    public class Department
    {
        public Guid Id { get; private set; }
        [StringLength(100)]
        public string NameAr { get; private set; } = string.Empty;
        [StringLength(100)]
        public string NameEn { get; private set; } = string.Empty;

        public IReadOnlyCollection<Employee> Employees => _employees;

        private readonly List<Employee> _employees = new();

    }
}
