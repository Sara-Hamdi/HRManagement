using HRManagement.Domain.Aggregates.UserAggregate;

namespace HRManagement.Application.Contracts.Users.Interfaces
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateTokenAsync(User user);
    }
}
