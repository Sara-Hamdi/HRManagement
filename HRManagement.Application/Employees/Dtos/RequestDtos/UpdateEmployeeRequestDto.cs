using HRManagement.Application.Baeses;
using MediatR;
using System.Text.Json.Serialization;

namespace HRManagement.Application.Employees.Dtos.RequestDtos
{
    public class UpdateEmployeeRequestDto : IRequest<Response<Guid>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public AddressRequestDto? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid? DepartmentId { get; set; } = null;
        public double? NetSalary { get; set; }
        public double? GrossSalary { get; set; }
        public Guid? PositionId { get; set; } = null;
    }
}
