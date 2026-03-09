using ItoApp.Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text;

namespace ItoApp.Infrastructure.Sms;

public class ViettelSmsSender : SmsSenderBase, ISmsSender
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly ILogger<ViettelSmsSender> _logger;

    public ViettelSmsSender(IConfiguration configuration, HttpClient httpClient, ILogger<ViettelSmsSender> logger)
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task SendOtpAsync(string phone, string otp)
    {
        try
        {
            var config = _configuration.GetSection("Sms:Viettel");
            var apiKey = config["ApiKey"];
            var secretKey = config["SecretKey"];
            var brandName = config["BrandName"];
            var cpCode = config["CpCode"];
            var message = $"Ma OTP cua ban la: {otp}";

            var requestUrl = "https://api.viettel.com.vn/sms/v1/send";
            var requestData = new
            {
                api_key = apiKey,
                secret_key = secretKey,
                phone = FormatPhoneNumber(phone),
                message = message,
                brandname = brandName,
                cpcode = cpCode,
                message_type = "OTP",
                otp = otp
            };

            var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                _logger.LogError("Viettel Send Error: {Error}", error);
                throw new Exception("Failed to send SMS via Viettel");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Viettel Sender Exception");
            throw;
        }
    }
}
