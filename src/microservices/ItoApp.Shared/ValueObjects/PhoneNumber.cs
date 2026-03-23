using System.Text.RegularExpressions;

namespace ItoApp.Shared.ValueObjects;

public sealed class PhoneNumber : IEquatable<PhoneNumber>
{
    public string Value { get; }
    
    private PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone number cannot be empty");
            
        var normalizedPhone = NormalizePhoneNumber(value);
        if (!IsValidPhoneNumber(normalizedPhone))
            throw new ArgumentException("Invalid phone number format");
            
        Value = normalizedPhone;
    }
    
    public static PhoneNumber Create(string phoneNumber)
    {
        return new PhoneNumber(phoneNumber);
    }
    
    private static string NormalizePhoneNumber(string phoneNumber)
    {
        phoneNumber = phoneNumber.Trim();
        
        if (phoneNumber.StartsWith("0"))
        {
            return "+84" + phoneNumber.Substring(1);
        }
        else if (phoneNumber.StartsWith("84") && !phoneNumber.StartsWith("+84"))
        {
            return "+" + phoneNumber;
        }
        else if (!phoneNumber.StartsWith("+"))
        {
            return "+" + phoneNumber;
        }
        
        return phoneNumber;
    }
    
    private static bool IsValidPhoneNumber(string phoneNumber)
    {
        var pattern = @"^\+84(3[2-9]|5[2689]|7[06-9]|8[1-689]|9[0-9])\d{7}$";
        return Regex.IsMatch(phoneNumber, pattern);
    }
    
    public string ToNationalFormat()
    {
        if (Value.StartsWith("+84"))
        {
            return "0" + Value.Substring(3);
        }
        return Value;
    }
    
    public bool Equals(PhoneNumber? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }
    
    public override bool Equals(object? obj)
    {
        return Equals(obj as PhoneNumber);
    }
    
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
    
    public static bool operator ==(PhoneNumber? left, PhoneNumber? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }
    
    public static bool operator !=(PhoneNumber? left, PhoneNumber? right)
    {
        return !(left == right);
    }
    
    public override string ToString()
    {
        return ToNationalFormat();
    }
}
