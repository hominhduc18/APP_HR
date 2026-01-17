namespace ItoApp.Application.Abstractions;

public interface ISmsSender
{
    Task SendOtpAsync(string phone, string otp);
}