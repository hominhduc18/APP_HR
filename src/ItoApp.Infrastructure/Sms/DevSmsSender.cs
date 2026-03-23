using ItoApp.Application.Abstractions;
using Microsoft.Extensions.Logging;

namespace ItoApp.Infrastructure.Sms;

public class DevSmsSender : ISmsSender
{
    private readonly ILogger<DevSmsSender> _logger;

    public DevSmsSender(ILogger<DevSmsSender> logger)
    {
        _logger = logger;
    }

    public Task SendOtpAsync(string phone, string otp)
    {
        _logger.LogInformation("📱 [MOCK SMS] To: {Phone} | OTP: {Otp}", phone, otp);
        return Task.CompletedTask;
    }
}


