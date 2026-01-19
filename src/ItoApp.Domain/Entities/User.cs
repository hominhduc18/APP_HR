using ItoApp.Domain.Common;
using ItoApp.Domain.ValueObjects;

namespace ItoApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public Email? Email { get; private set; }
        public PhoneNumber? PhoneNumber { get; private set; }
        public string PasswordHash { get; private set; }
        public string FullName { get; private set; }
        public bool IsVerified { get; private set; }
        public UserStatus Status { get; private set; }
        public string? ResetPasswordToken { get; private set; }
        public DateTime? ResetPasswordExpires { get; private set; }
        public DateTime? LastLoginAt { get; private set; }
        
        // Navigation properties - QUAN TRỌNG
        public virtual Patient? Patient { get; private set; }
        
        private readonly List<RefreshToken> _refreshTokens = new();
        public virtual IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();
        
        // Private constructor for EF Core
        private User() 
        {
            // Khởi tạo để tránh null warnings
            PasswordHash = string.Empty;
            FullName = string.Empty;
        }
        
        // Constructor với Email
        public User(string email, string passwordHash, string fullName)
        {
            Email = Email.Create(email);
            PhoneNumber = null;
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            FullName = ValidateFullName(fullName);
            IsVerified = false;
            Status = UserStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }
        
        // Constructor với Phone
        public User(PhoneNumber phoneNumber, string passwordHash, string fullName)
        {
            Email = null;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            FullName = ValidateFullName(fullName);
            IsVerified = false;
            Status = UserStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }
        
        // Business methods
        public void Verify()
        {
            if (IsVerified)
                throw new Domain.Exceptions.DomainException("Already verified");
                
            IsVerified = true;
            UpdateTimestamp();
            
           // AddDomainEvent(new UserVerifiedEvent(Id, GetIdentifier()));
        }
        
        public void SetResetPasswordToken(string token, int expiryHours = 24)
        {
            ResetPasswordToken = token;
            ResetPasswordExpires = DateTime.UtcNow.AddHours(expiryHours);
            UpdateTimestamp();
        }
        
        public void ClearResetPasswordToken()
        {
            ResetPasswordToken = null;
            ResetPasswordExpires = null;
            UpdateTimestamp();
        }
        
        public void UpdatePassword(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash))
                throw new Domain.Exceptions.DomainException("Password cannot be empty");
                
            PasswordHash = newPasswordHash;
            ClearResetPasswordToken();
            UpdateTimestamp();
            
          //  AddDomainEvent(new PasswordChangedEvent(Id));
        }
        
        public void UpdateProfile(string fullName)
        {
            FullName = ValidateFullName(fullName);
            UpdateTimestamp();
        }
        
        public void RecordLogin()
        {
            LastLoginAt = DateTime.UtcNow;
            UpdateTimestamp();
        }
        
        public void ChangeStatus(UserStatus newStatus)
        {
            Status = newStatus;
            UpdateTimestamp();
        }
        
        public void AddRefreshToken(RefreshToken refreshToken)
        {
            _refreshTokens.Add(refreshToken);
        }
        
        public void RemoveRefreshToken(string token)
        {
            var refreshToken = _refreshTokens.FirstOrDefault(rt => rt.Token == token);
            if (refreshToken != null)
            {
                _refreshTokens.Remove(refreshToken);
            }
        }
        
        // Helper methods
        public string GetIdentifier()
        {
            return Email?.Value ?? PhoneNumber?.Value ?? throw new InvalidOperationException("User has no identifier");
        }
        
        public string GetDisplayIdentifier()
        {
            return Email?.Value ?? PhoneNumber?.ToNationalFormat() ?? "N/A";
        }
        
        public bool IsPhoneUser()
        {
            return PhoneNumber != null;
        }
        
        public bool IsEmailUser()
        {
            return Email != null;
        }
        
        private string ValidateFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new Domain.Exceptions.DomainException("Full name is required");
                
            var trimmedName = fullName.Trim();
            
            if (trimmedName.Length < 2 || trimmedName.Length > 100)
                throw new Domain.Exceptions.DomainException("Full name must be between 2 and 100 characters");
                
            return trimmedName;
        }
    }
    
}