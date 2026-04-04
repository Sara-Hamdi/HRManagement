using MediatR;
using System.Text.Json.Serialization;

namespace HRManagement.Application.Features.Employees.CommandHandlers.Commands
{
    public class DeleteEmployeeCommand : IRequest<Guid>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
