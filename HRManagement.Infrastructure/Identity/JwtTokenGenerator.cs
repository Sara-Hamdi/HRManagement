using HRManagement.Application.Configurations;
using HRManagement.Application.Users.Interfaces;
using HRManagement.Domain.Aggregates.UserAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _jwtOptions;
    private readonly UserManager<User> _userManager;

    public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions, UserManager<User> userManager)
    {
        _jwtOptions = jwtOptions.Value;
        _userManager = userManager;
    }

    public async Task<string> GenerateTokenAsync(User user)
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
                   issuer: _jwtOptions.Issuer,
                   audience: _jwtOptions.Audience,
                   expires: DateTime.Now.AddDays(1),
                   claims: claims,
                   signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Secret)), SecurityAlgorithms.HmacSha256Signature)
                   );
        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
