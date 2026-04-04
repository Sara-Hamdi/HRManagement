using HRManagement.Application.Features.Employees.QueriesHandlers.Responses;
using MediatR;
using System.Text.Json.Serialization;

namespace HRManagement.Application.Features.Employees.QueriesHandlers.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeResponseDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
