using MediatR;

namespace HRManagement.Application.Contracts.Users.Dtos
{
    public class LoginUserRequestDto : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
