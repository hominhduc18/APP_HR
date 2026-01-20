namespace ItoApp.Application.Abstractions;

public record TokenPayload(Guid UserId, string Role);

public interface ITokenService
{
    (string accessToken, string refreshToken) CreateTokens(Guid userId, string role);
    TokenPayload? ValidateRefreshToken(string refreshToken);
}