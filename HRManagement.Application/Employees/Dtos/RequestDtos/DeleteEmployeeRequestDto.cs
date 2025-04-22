using HRManagement.Application.Baeses;
using MediatR;
using System.Text.Json.Serialization;

namespace HRManagement.Application.Employees.Dtos.RequestDtos
{
    public class DeleteEmployeeRequestDto : IRequest<Response<Guid>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
