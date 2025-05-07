using MediatR;
using System.Text.Json.Serialization;

namespace HRManagement.Application.Employees.Dtos.RequestDtos
{
    public class CreateEmployeeRequestDto : IRequest<Guid>
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
}
