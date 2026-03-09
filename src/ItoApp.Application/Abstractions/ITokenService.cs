namespace ItoApp.Application.Abstractions;

public record TokenPayload(string UserId, string Role);

public interface ITokenService
{
    (string accessToken, string refreshToken) CreateTokens(string userId, string role);
    TokenPayload? ValidateRefreshToken(string refreshToken);
}