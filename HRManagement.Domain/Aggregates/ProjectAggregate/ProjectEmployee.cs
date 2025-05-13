using HRManagement.Domain.Aggregates.EmployeeAggregate;

namespace HRManagement.Domain.Aggregates.ProjectAggregate
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
