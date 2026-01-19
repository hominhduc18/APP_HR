using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
    public class OtpCode : BaseEntity
    {
        public string Identifier { get; private set; } // phone or email
        public string Code { get; private set; }
        public OtpType Type { get; private set; }
        public OtpChannel Channel { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public bool IsUsed { get; private set; }
        public int AttemptCount { get; private set; }
        public DateTime? VerifiedAt { get; private set; }

        // Foreign key (optional)
        public Guid? UserId { get; private set; }

        private OtpCode()
        {
        }

        public OtpCode(string identifier, OtpType type, OtpChannel channel, int expiryMinutes = 5)
        {
            Identifier = identifier.ToLower().Trim();
            Code = GenerateOtpCode();
            Type = type;
            Channel = channel;
            ExpiresAt = DateTime.UtcNow.AddMinutes(expiryMinutes);
            IsUsed = false;
            AttemptCount = 0;
            CreatedAt = DateTime.UtcNow;
        }

        public bool IsValid()
        {
            return !IsUsed &&
                   ExpiresAt > DateTime.UtcNow &&
                   AttemptCount < 3;
        }

        public bool Verify(string code)
        {
            if (!IsValid())
                return false;

            AttemptCount++;

            if (Code != code)
            {
                UpdateTimestamp();
                return false;
            }

            IsUsed = true;
            VerifiedAt = DateTime.UtcNow;
            UpdateTimestamp();
            return true;
        }

        private string GenerateOtpCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}