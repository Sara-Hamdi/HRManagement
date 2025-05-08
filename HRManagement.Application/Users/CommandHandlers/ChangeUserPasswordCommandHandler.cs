using HRManagement.Application.Users.Dtos;
using HRManagement.Domain.Aggregates.UserAggregate;
using HRManagement.Domain.Shared;
using HRManagement.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRManagement.Application.Users.CommandHandlers
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordRequestDto>
    {
        private readonly UserManager<User> _userManager;
        public ChangeUserPasswordCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task Handle(ChangeUserPasswordRequestDto request, CancellationToken cancellationToken)
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
