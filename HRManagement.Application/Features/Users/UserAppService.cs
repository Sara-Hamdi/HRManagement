using HRManagement.Application.Features.Users.CommandHandlers.Commands;
using HRManagement.Application.Users.Interfaces;
using MediatR;

namespace HRManagement.Application.Features.Users
{
    public class UserAppService : IUserAppService
    {
        private readonly IMediator _mediator;
        public UserAppService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ChangeUserPasswordAsync(ChangeUserPasswordCommand request)
        {
            await _mediator.Send(request);
        }

        public async Task RegisterUserAsync(RegisterUserCommand request)
        {
            await _mediator.Send(request);
        }

        public async Task UpdateUserInfo(UpdateUserInfoCommand request)
        {
            await _mediator.Send(request);
        }
        public async Task<string> LoginUser(LoginUserCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
