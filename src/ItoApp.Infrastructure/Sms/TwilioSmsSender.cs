using ItoApp.Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;

namespace ItoApp.Infrastructure.Sms;

public class TwilioSmsSender : SmsSenderBase, ISmsSender
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly ILogger<TwilioSmsSender> _logger;

    public TwilioSmsSender(IConfiguration configuration, HttpClient httpClient, ILogger<TwilioSmsSender> logger)
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task SendOtpAsync(string phone, string otp)
    {
        try
        {
            var config = _configuration.GetSection("Sms:Twilio");
            var accountSid = config["AccountSid"];
            var authToken = config["AuthToken"];
            var fromNumber = config["FromNumber"];
            var message = $"Ma OTP cua ban la: {otp}. Vui long khong chia se cho ai.";

            var requestUrl = $"https://api.twilio.com/2010-04-01/Accounts/{accountSid}/Messages.json";
            var requestData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("To", FormatPhoneNumber(phone)),
                new KeyValuePair<string, string>("From", fromNumber),
                new KeyValuePair<string, string>("Body", message)
            });

            var byteArray = Encoding.ASCII.GetBytes($"{accountSid}:{authToken}");
            _httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await _httpClient.PostAsync(requestUrl, requestData);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                _logger.LogError("Twilio Send Error: {Error}", error);
                throw new Exception("Failed to send SMS via Twilio");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Twilio Sender Exception");
            throw;
        }
    }
}
