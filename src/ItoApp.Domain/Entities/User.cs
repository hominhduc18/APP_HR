using ItoApp.Domain.Common;
using ItoApp.Domain.ValueObjects;

namespace ItoApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string FullName { get; private set; }
        public bool IsEmailVerified { get; private set; }
        public UserStatus Status { get; private set; }
        public string? ResetPasswordToken { get; private set; }
        public DateTime? ResetPasswordExpires { get; private set; }
        public DateTime? LastLoginAt { get; private set; }
        
        
        
        private User() {}
    }
    
    
}