using HRManagement.Domain.Aggregates.EmployeesAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Domain.Aggregates.Projects
{
    public class ProjectEmployee
    {
        public Guid Id { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Guid ProjectId { get; private set; }
        public DateTime EmployeeProjectJoiningDate { get; private set; }
        public Employee Employee { get; private set; } = new();
        public Project Project { get; private set; } = new();
    }
}
