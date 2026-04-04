using HRManagement.Application.Features.Users.CommandHandlers.Commands;

namespace HRManagement.Application.Users.Interfaces
{
    public interface IUserAppService
    {
        Task RegisterUserAsync(RegisterUserCommand request);
        Task UpdateUserInfo(UpdateUserInfoCommand request);
        Task ChangeUserPasswordAsync(ChangeUserPasswordCommand request);
        Task<string> LoginUser(LoginUserCommand request);
    }
}
