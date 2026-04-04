using MediatR;
using System.Text.Json.Serialization;

namespace HRManagement.Application.Features.Users.CommandHandlers.Commands
{
    public class ChangeUserPasswordCommand : IRequest
    {
        [JsonIgnore]
        public string? UserId { get; set; } = null;
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
