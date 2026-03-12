using ItoApp.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ItoApp.Infrastructure.Sms;

public class SmsSenderFactory : ISmsSenderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public SmsSenderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ISmsSender GetSender(string providerName)
    {
        return providerName.ToLower() switch
        {
            "twilio" => _serviceProvider.GetRequiredService<TwilioSmsSender>(),
            "viettel" => _serviceProvider.GetRequiredService<ViettelSmsSender>(),
            "mobifone" => _serviceProvider.GetRequiredService<MobifoneSmsSender>(),
            _ => _serviceProvider.GetRequiredService<DevSmsSender>()
        };
    }
}
