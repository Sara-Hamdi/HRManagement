using HRManagement.Application.Users.Dtos;

namespace HRManagement.Application.Users.Interfaces
{
    public interface IUserAppService
    {
        Task RegisterUserAsync(RegisterUserRequestDto request);
        Task UpdateUserInfo(UpdateUserInfoRequestDto request);
        Task ChangeUserPasswordAsync(ChangeUserPasswordRequestDto request);
        Task<string> LoginUser(LoginUserRequestDto request);
    }
}
