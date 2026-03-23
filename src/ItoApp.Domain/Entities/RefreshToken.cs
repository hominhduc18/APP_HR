using ItoApp.Shared.Common;

using ItoApp.Shared.Exceptions;
using ItoApp.Shared.Enums;
using ItoApp.Shared.ValueObjects;
using ItoApp.Shared.Common;

namespace ItoApp.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public string? ReplacedByToken { get; private set; }
        public string? ReasonRevoked { get; private set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
        public bool IsRevoked => RevokedAt != null;
        public bool IsActive => !IsRevoked && !IsExpired;
        
        // Foreign key
        public int UserId { get; private set; }
        public virtual User User { get; private set; }
        
        private RefreshToken() {}
        
        public RefreshToken(int userId, int expiryDays = 7)
        {
            UserId = userId;
            Token = GenerateToken();
            ExpiresAt = DateTime.UtcNow.AddDays(expiryDays);
            CreatedAt = DateTime.UtcNow;
        }
        
        public void Revoke(string replacedByToken = null, string reason = null)
        {
            RevokedAt = DateTime.UtcNow;
            ReplacedByToken = replacedByToken;
            ReasonRevoked = reason;
            UpdateTimestamp();
        }
        
        private string GenerateToken()
        {
            var randomBytes = new byte[32];
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}


