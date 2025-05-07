using MediatR;
using System.Text.Json.Serialization;

namespace HRManagement.Application.Users.Dtos
{
    public class UpdateUserInfoRequestDto : IRequest
    {
        [JsonIgnore]
        public required string UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
