using ItoApp.Application.Abstractions;

namespace ItoApp.Infrastructure.Auth;





public class DevTokenService : ITokenService
{
    public (string accessToken, string refreshToken) CreateTokens(long userId, string role)
        => ($"access-{userId}-{role}", $"refresh-{userId}-{Guid.NewGuid()}");
}
