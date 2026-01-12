namespace ItoApp.Application.Abstractions;

public interface ITokenService
{
    (string accessToken, string refreshToken) CreateTokens(long userId, string role);
}