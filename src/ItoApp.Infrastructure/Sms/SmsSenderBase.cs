using System.Text;

namespace ItoApp.Infrastructure.Sms;

public abstract class SmsSenderBase
{
    protected string FormatPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber)) return phoneNumber;
        
        phoneNumber = phoneNumber.Trim();
        var cleaned = new StringBuilder();
        foreach (char c in phoneNumber)
        {
            if (char.IsDigit(c) || c == '+')
                cleaned.Append(c);
        }
        
        phoneNumber = cleaned.ToString();
        
        if (phoneNumber.StartsWith("0"))
        {
            return "+84" + phoneNumber.Substring(1);
        }
        return phoneNumber.StartsWith("+") ? phoneNumber : "+" + phoneNumber;
    }
}


