using MediatR;

namespace HRManagement.Application.Features.Users.CommandHandlers.Commands
{
    public class LoginUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
