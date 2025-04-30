using MediatR;
using System.Text.Json.Serialization;

namespace HRManagement.Application.Employees.Dtos.RequestDtos
{
    public class DeleteEmployeeRequestDto : IRequest<Guid>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
