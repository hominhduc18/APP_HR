using ItoApp.Application.Abstractions;

namespace ItoApp.Infrastructure.Auth;





public class DevTokenService : ITokenService
{
    public (string accessToken, string refreshToken) CreateTokens(string userId, string role)
        => ($"access-{userId}-{role}", $"refresh-{userId}-{role}");

    public TokenPayload? ValidateRefreshToken(string refreshToken)
    {
        if (refreshToken.StartsWith("refresh-"))
        {
            var parts = refreshToken.Split('-');
            if (parts.Length >= 3)
            {
                return new TokenPayload(parts[1], parts[2]);
            }
        }
        return null;
    }
}


