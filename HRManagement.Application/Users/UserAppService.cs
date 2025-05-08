using HRManagement.Application.Users.Dtos;
using HRManagement.Application.Users.Interfaces;
using MediatR;

namespace HRManagement.Application.Users
{
    public class UserAppService : IUserAppService
    {
        private readonly IMediator _mediator;
        public UserAppService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ChangeUserPasswordAsync(ChangeUserPasswordRequestDto request)
        {
            await _mediator.Send(request);
        }

        public async Task RegisterUserAsync(RegisterUserRequestDto request)
        {
            await _mediator.Send(request);
        }

        public async Task UpdateUserInfo(UpdateUserInfoRequestDto request)
        {
            await _mediator.Send(request);
        }
        public async Task<string> LoginUser(LoginUserRequestDto request)
        {
            return await _mediator.Send(request);
        }
    }
}
