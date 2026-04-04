using HRManagement.Domain.Aggregates.UserAggregate;

namespace HRManagement.Application.Users.Interfaces
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateTokenAsync(User user);
    }
}
