using HRManagement.Application.Users.Dtos;

namespace HRManagement.Application.Users.Interfaces
{
    public interface IUserAppService
    {
        Task RegisterUserAsync(RegisterUserRequestDto request);
    }
}
