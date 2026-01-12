namespace ItoApp.Domain;

public class User
{
    public long UserId { get; private set; }
    public string Phone { get; private set; }
    public string FullName { get; private set; }
    public string PasswordHash { get; private set; }
    public string Status { get; private set; } 
    public string Role { get; private set; }   
}