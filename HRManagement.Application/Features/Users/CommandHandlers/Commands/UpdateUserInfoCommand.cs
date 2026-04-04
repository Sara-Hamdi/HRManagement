using MediatR;
using System.Text.Json.Serialization;

namespace HRManagement.Application.Features.Users.CommandHandlers.Commands
{
    public class UpdateUserInfoCommand : IRequest
    {
        [JsonIgnore]
        public required string UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
