using System;

namespace ItoApp.Infrastructure.Services
{
    public interface ITokenService
    {
        (string AccessToken, string RefreshToken) CreateTokens(Guid userId, string role);
        bool ValidateToken(string token);
        Guid GetUserIdFromToken(string token);
    }
}