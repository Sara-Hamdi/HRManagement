using HRManagement.Domain.Aggregates.Departments;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Domain.Aggregates.EmployeesAggregates
{
    public class Employee
    {
        public Guid Id { get; private set; }
        [StringLength(100)]
        public string FirstName { get; private set; }
        [StringLength(100)]
        public string LastName { get; private set; }
        public string? FullName { get; private set; }
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; private set; }
        public string NationalId { get; private set; }
        public Guid? AddressId { get; private set; }
        [StringLength(100)]
        public string PhoneNumber { get; private set; }
        public Guid DepartmentId { get; private set; }
        public double NetSalary { get; private set; }
        public double GrossSalary { get; private set; }
        public Guid PositionId { get; private set; }
        public virtual Department Department { get; private set; }
        public virtual Address? Address { get; private set; }
        public virtual Position Position { get; private set; }

        public Employee() { }
        public Employee(string firstName, string lastName, string phoneNumber, Guid departmentId, double netSalary, double grossSalary, Guid positionId, string email, string nationalId)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = firstName + " " + lastName;
            DepartmentId = departmentId;
            NetSalary = netSalary;
            PhoneNumber = phoneNumber;
            PositionId = positionId;
            GrossSalary = grossSalary;
            Email = email;
            NationalId = nationalId;
        }
        public Employee AddAddress(string city, string region, string? notes = null)
        {
            Address = new Address(city, region, notes);
            return this;
        }
        public Employee Update(string? firstName, string? lastName,
            Guid? departmentId, double? netSalary, string? phoneNumber, Guid? positionId,
            double? grossSalary, string? email)
        {
            FirstName = firstName ?? FirstName;
            LastName = lastName ?? LastName;
            DepartmentId = (departmentId != null && departmentId != Guid.Empty) ? (Guid)departmentId : DepartmentId;
            NetSalary = netSalary ?? NetSalary;
            PhoneNumber = phoneNumber ?? PhoneNumber;
            PositionId = (positionId != null && positionId != Guid.Empty) ? (Guid)positionId : PositionId;
            GrossSalary = grossSalary ?? GrossSalary;
            Email = email ?? Email;
            SetFullName();
            return this;

        }
        public Employee SetFullName()
        {
            FullName = FirstName + " " + LastName;
            return this;
        }

    }
}
