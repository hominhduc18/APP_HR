using System.Text.RegularExpressions;

namespace ItoApp.Shared.ValueObjects;

public sealed class Email : IEquatable<Email>
{
    public string Value { get; }
    private Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty");
                
        if (!IsValidEmail(value))
            throw new ArgumentException("Invalid email format");
                
        Value = value.ToLower().Trim();
    }
        
    public static Email Create(string email)
    {
        return new Email(email);
    }
        
    private static bool IsValidEmail(string email)
    {
        var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }
        
    public bool Equals(Email? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }
        
    public override bool Equals(object? obj)
    {
        return Equals(obj as Email);
    }
        
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
        
    public static bool operator ==(Email? left, Email? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }
        
    public static bool operator !=(Email? left, Email? right)
    {
        return !(left == right);
    }
        
    public override string ToString()
    {
        return Value;
    }
}
