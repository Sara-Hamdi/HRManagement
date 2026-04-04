using MediatR;
using System.Text.Json.Serialization;

namespace HRManagement.Application.Features.Employees.CommandHandlers.Commands
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string? NationalId { get; set; }
        public AddressRequestDto Address { get; set; }
        public Guid DepartmentId { get; set; }
        public double NetSalary { get; set; }
        public double GrossSalary { get; set; }
        public Guid PositionId { get; set; }
        [JsonIgnore]
        public string? UserId { get; set; } = null;
    }
    public class AddressRequestDto
    {
        public required string City { get; set; }
        public required string Region { get; set; }
        public string? Notes { get; set; }
    }
}
