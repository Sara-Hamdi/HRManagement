using HRManagement.Application.Features.Users.CommandHandlers.Commands;
using HRManagement.Domain.Aggregates.UserAggregate;
using HRManagement.Shared;
using HRManagement.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRManagement.Application.Features.Users.CommandHandlers.Handlers
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand>
    {
        private readonly UserManager<User> _userManager;
        public ChangeUserPasswordCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new EntityNotFoundException(Guid.Parse(request.UserId), nameof(User));
            }
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
            {
                throw new BusinessException(Constants.ErrorCodes.PasswordChangingFailed);
            }

        }
    }
}
