using HRManagement.Domain.Aggregates.Departments;
using HRManagement.Domain.Aggregates.UserAggregate;

namespace HRManagement.Domain.Aggregates.EmployeesAggregates
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public Guid DepartmentId { get; private set; }
        public double NetSalary { get; private set; }
        public double GrossSalary { get; private set; }
        public Guid PositionId { get; private set; }
        public Guid AddressId { get; private set; }
        public string NationalId { get; private set; }
        public string UserId { get; private set; }
        public User User { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual Department Department { get; private set; }
        public virtual Position Position { get; private set; }

        public Employee() { }
        public Employee(string userId, Guid departmentId, double netSalary, double grossSalary, Guid positionId, string nationalId)
        {
            UserId = userId;
            DepartmentId = departmentId;
            NetSalary = netSalary;
            PositionId = positionId;
            GrossSalary = grossSalary;
            NationalId = nationalId;

        }
        public Employee AddAddress(string city, string region, string? notes = null)
        {
            Address = new Address(city, region, notes);
            return this;
        }
        public Employee Update(
            Guid? departmentId, double? netSalary, Guid? positionId,
            double? grossSalary)
        {

            DepartmentId = (departmentId != null && departmentId != Guid.Empty) ? (Guid)departmentId : DepartmentId;
            NetSalary = netSalary ?? NetSalary;
            PositionId = (positionId != null && positionId != Guid.Empty) ? (Guid)positionId : PositionId;
            GrossSalary = grossSalary ?? GrossSalary;
            return this;

        }

    }
}
