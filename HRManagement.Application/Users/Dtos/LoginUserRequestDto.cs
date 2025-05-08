using MediatR;

namespace HRManagement.Application.Users.Dtos
{
    public class LoginUserRequestDto : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
