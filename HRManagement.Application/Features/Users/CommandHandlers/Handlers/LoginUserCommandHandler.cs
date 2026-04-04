using HRManagement.Application.Features.Users.CommandHandlers.Commands;
using HRManagement.Application.Users.Interfaces;
using HRManagement.Domain.Aggregates.UserAggregate;
using HRManagement.Shared;
using HRManagement.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRManagement.Application.Features.Users.CommandHandlers.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginUserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new BusinessException(Constants.ErrorCodes.InvalidEmailOrPassword);
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                throw new BusinessException(Constants.ErrorCodes.InvalidEmailOrPassword);
            }
            return await _jwtTokenGenerator.GenerateTokenAsync(user);


        }

    }
}
