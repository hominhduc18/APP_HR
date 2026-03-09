using ItoApp.Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text;

namespace ItoApp.Infrastructure.Sms;

public class MobifoneSmsSender : SmsSenderBase, ISmsSender
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly ILogger<MobifoneSmsSender> _logger;

    public MobifoneSmsSender(IConfiguration configuration, HttpClient httpClient, ILogger<MobifoneSmsSender> logger)
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task SendOtpAsync(string phone, string otp)
    {
        try
        {
            var config = _configuration.GetSection("Sms:Mobifone");
            var username = config["Username"];
            var password = config["Password"];
            var brandName = config["BrandName"];
            var message = $"Ma OTP cua ban la: {otp}";

            var requestUrl = "https://api.mobifone.com.vn/sms/send";
            var requestData = new
            {
                username = username,
                password = password,
                msisdn = FormatPhoneNumber(phone),
                message = message,
                brandname = brandName,
                type = "text"
            };

            var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Mobifone Send Error");
                throw new Exception("Failed to send SMS via Mobifone");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Mobifone Sender Exception");
            throw;
        }
    }
}
