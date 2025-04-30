using MediatR;

namespace HRManagement.Application.Employees.Dtos.RequestDtos
{
    public class CreateEmployeeRequestDto : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? NationalId { get; set; }
        public AddressRequestDto Address { get; set; }
        public string PhoneNumber { get; set; }
        public Guid DepartmentId { get; set; }
        public double NetSalary { get; set; }
        public double GrossSalary { get; set; }
        public Guid PositionId { get; set; }
    }
}
