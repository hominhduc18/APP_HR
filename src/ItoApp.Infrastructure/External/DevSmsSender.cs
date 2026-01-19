using ItoApp.Application.Abstractions;

namespace ItoApp.Infrastructure.Sms;





public class DevSmsSender : ISmsSender
{
    public Task SendOtpAsync(string phone, string otp)
    {
        Console.WriteLine($"[DEV OTP REGISTER] {phone} => {otp}");
        return Task.CompletedTask;
    }
}
