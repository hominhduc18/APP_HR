using ItoApp.Application.Abstractions;

namespace ItoApp.Infrastructure.Auth;





public class DevTokenService : ITokenService
{
    public (string accessToken, string refreshToken) CreateTokens(Guid userId, string role)
        => ($"access-{userId}-{role}", $"refresh-{userId}-{Guid.NewGuid()}");

    public TokenPayload? ValidateRefreshToken(string refreshToken)
    {
        // Simple dummy check: format refresh-guid-role
        if (refreshToken.StartsWith("refresh-"))
        {
            var parts = refreshToken.Split('-');
            if (parts.Length >= 2 && Guid.TryParse(parts[1], out var userId))
            {
                return new TokenPayload(userId, "PATIENT");
            }
        }
        return null;
    }
}
