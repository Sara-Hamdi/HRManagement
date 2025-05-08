using HRManagement.API.Configurations;
using HRManagement.Application.Users.Dtos;
using HRManagement.Domain.Aggregates.UserAggregate;
using HRManagement.Domain.Shared;
using HRManagement.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRManagement.Application.Users.CommandHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserRequestDto, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtOptions _jwtSettings;

        public LoginUserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JwtOptions> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> Handle(LoginUserRequestDto request, CancellationToken cancellationToken)
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
            return await GetToken(user);


        }
        public async Task<string> GetToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email!),

            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var token = new JwtSecurityToken(
                       issuer: _jwtSettings.Issuer,
                       audience: _jwtSettings.Audience,
                       expires: DateTime.Now.AddDays(1),
                       claims: claims,
                       signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
                       );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
