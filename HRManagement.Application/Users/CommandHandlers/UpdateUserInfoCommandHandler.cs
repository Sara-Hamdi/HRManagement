using HRManagement.Application.Users.Dtos;
using HRManagement.Domain.Aggregates.UserAggregate;
using HRManagement.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRManagement.Application.Users.CommandHandlers
{
    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoRequestDto>
    {
        private readonly UserManager<User> _userManager;

        public UpdateUserInfoCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task Handle(UpdateUserInfoRequestDto request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null) throw new EntityNotFoundException(Guid.Parse(request.UserId), nameof(User));
            user.Update(request.FirstName, request.LastName, request.Email, request.PhoneNumber);
            await _userManager.UpdateAsync(user);


        }
    }
}
