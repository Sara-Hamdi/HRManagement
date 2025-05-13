using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Domain.Aggregates.ProjectAggregate
{
    public class Project
    {
        public Guid Id { get; private set; }
        [StringLength(100)]
        public string Name { get; private set; }
        [StringLength(500)]
        public string Description { get; private set; }
        public int NumOfEmployees { get; private set; }
        public DateTime StartDate { get; private set; }
        public double Budget { get; private set; }
        public IReadOnlyCollection<ProjectEmployee> ProjectEmployees => _projectEmployees;

        private readonly List<ProjectEmployee> _projectEmployees = new();

        public void AddEmployee(ProjectEmployee projectEmployee)
        {
            _projectEmployees.Add(projectEmployee);
        }
    }

}
