namespace ItoApp.Domain;

public class User
{
    public long UserId { get; private set; }
    public string Phone { get; private set; }
    public string FullName { get; private set; }
    public string PasswordHash { get; private set; }

    public string Role { get; private set; }   
    public string Email { get; private set; }
    
    public UserStatus Status { get; private set; } = UserStatus.Pending;
    public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;
}