using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ItoApp.Infrastructure.External
{
    public interface ISmsService
    {
        Task<bool> SendOtpAsync(string phoneNumber, string otpCode, string message);
        Task<bool> SendSmsAsync(string phoneNumber, string message);
        Task<bool> VerifyPhoneNumberAsync(string phoneNumber);
    }
    
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ILogger<SmsService> _logger;
        
        public SmsService(
            IConfiguration configuration,
            HttpClient httpClient,
            ILogger<SmsService> logger)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _logger = logger;
        }
        
        public async Task<bool> SendOtpAsync(string phoneNumber, string otpCode, string message)
        {
            try
            {
                var formattedPhone = FormatPhoneNumber(phoneNumber);
                var smsConfig = _configuration.GetSection("Sms");
                
                // Kiểm tra provider
                var provider = smsConfig["Provider"]?.ToLower() ?? "mock";
                var useMock = smsConfig.GetValue<bool>("UseMock", true);
                
                if (useMock || provider == "mock")
                {
                    await SendMockSms(formattedPhone, otpCode, message);
                    return true;
                }
                
                // Chọn provider dựa trên cấu hình
                bool success = provider switch
                {
                    "twilio" => await SendViaTwilioAsync(formattedPhone, message, otpCode),
                    "vonage" => await SendViaVonageAsync(formattedPhone, message, otpCode),
                    "viettel" => await SendViaViettelAsync(formattedPhone, message, otpCode),
                    "mobifone" => await SendViaMobifoneAsync(formattedPhone, message, otpCode),
                    "vinaphone" => await SendViaVinaphoneAsync(formattedPhone, message, otpCode),
                    "brandsms" => await SendViaBrandSmsAsync(formattedPhone, message, otpCode),
                    _ => await SendMockSms(formattedPhone, otpCode, message)
                };
                
                if (success)
                {
                    _logger.LogInformation("✅ SMS sent successfully to {Phone}", formattedPhone);
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error sending SMS to {Phone}", phoneNumber);
                return false;
            }
        }
        
        public async Task<bool> SendSmsAsync(string phoneNumber, string message)
        {
            try
            {
                var formattedPhone = FormatPhoneNumber(phoneNumber);
                var smsConfig = _configuration.GetSection("Sms");
                var useMock = smsConfig.GetValue<bool>("UseMock", true);
                
                if (useMock)
                {
                    _logger.LogInformation("📱 Mock SMS to {Phone}: {Message}", formattedPhone, message);
                    return true;
                }
                
                return await SendViaTwilioAsync(formattedPhone, message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error sending SMS to {Phone}", phoneNumber);
                return false;
            }
        }
        
        public async Task<bool> VerifyPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                var formattedPhone = FormatPhoneNumber(phoneNumber);
                
                // Kiểm tra định dạng số điện thoại Việt Nam
                if (!IsValidVietnamPhoneNumber(formattedPhone))
                {
                    _logger.LogWarning("Invalid Vietnam phone number: {Phone}", formattedPhone);
                    return false;
                }
                
                // Có thể tích hợp với dịch vụ xác thực số điện thoại
                // như Twilio Lookup, Google Identity, etc.
                
                _logger.LogInformation("✅ Phone number verified: {Phone}", formattedPhone);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error verifying phone number: {Phone}", phoneNumber);
                return false;
            }
        }
        
        #region Private Methods - SMS Providers
        
        private async Task<bool> SendMockSms(string phoneNumber, string otpCode, string message)
        {
            // Log thông tin chi tiết cho development
            _logger.LogInformation("""
                📱 ========== MOCK SMS ==========
                📞 To: {Phone}
                🔑 OTP: {OtpCode}
                📝 Message: {Message}
                ⏰ Time: {Time}
                =================================
                """, 
                phoneNumber, 
                otpCode, 
                message, 
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            
            // Simulate delay
            await Task.Delay(100);
            return true;
        }
        
        private async Task<bool> SendViaTwilioAsync(string phoneNumber, string message, string otpCode = null)
        {
            try
            {
                var smsConfig = _configuration.GetSection("Sms:Twilio");
                var accountSid = smsConfig["AccountSid"];
                var authToken = smsConfig["AuthToken"];
                var fromNumber = smsConfig["FromNumber"];
                
                if (string.IsNullOrEmpty(accountSid) || string.IsNullOrEmpty(authToken))
                {
                    _logger.LogWarning("Twilio credentials not configured, using mock mode");
                    return await SendMockSms(phoneNumber, otpCode ?? "N/A", message);
                }
                
                // Using Twilio REST API
                var requestUrl = $"https://api.twilio.com/2010-04-01/Accounts/{accountSid}/Messages.json";
                
                var requestData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("To", phoneNumber),
                    new KeyValuePair<string, string>("From", fromNumber),
                    new KeyValuePair<string, string>("Body", message)
                });
                
                // Basic auth
                var byteArray = Encoding.ASCII.GetBytes($"{accountSid}:{authToken}");
                _httpClient.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                
                var response = await _httpClient.PostAsync(requestUrl, requestData);
                
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    _logger.LogDebug("Twilio response: {Response}", responseContent);
                    return true;
                }
                
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Twilio error: {Error}", errorContent);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending via Twilio");
                return false;
            }
        }
        
        private async Task<bool> SendViaVonageAsync(string phoneNumber, string message, string otpCode = null)
        {
            try
            {
                var smsConfig = _configuration.GetSection("Sms:Vonage");
                var apiKey = smsConfig["ApiKey"];
                var apiSecret = smsConfig["ApiSecret"];
                var fromNumber = smsConfig["FromNumber"];
                
                if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
                {
                    _logger.LogWarning("Vonage credentials not configured, using mock mode");
                    return await SendMockSms(phoneNumber, otpCode ?? "N/A", message);
                }
                
                var requestUrl = "https://rest.nexmo.com/sms/json";
                
                var requestData = new
                {
                    api_key = apiKey,
                    api_secret = apiSecret,
                    to = phoneNumber,
                    from = fromNumber,
                    text = message,
                    type = "unicode"
                };
                
                var content = new StringContent(
                    JsonSerializer.Serialize(requestData),
                    Encoding.UTF8,
                    "application/json");
                
                var response = await _httpClient.PostAsync(requestUrl, content);
                
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    _logger.LogDebug("Vonage response: {Response}", responseContent);
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending via Vonage");
                return false;
            }
        }
        
        private async Task<bool> SendViaViettelAsync(string phoneNumber, string message, string otpCode = null)
        {
            try
            {
                var smsConfig = _configuration.GetSection("Sms:Viettel");
                var apiKey = smsConfig["ApiKey"];
                var secretKey = smsConfig["SecretKey"];
                var brandName = smsConfig["BrandName"];
                var cpCode = smsConfig["CpCode"];
                
                if (string.IsNullOrEmpty(apiKey))
                {
                    _logger.LogWarning("Viettel SMS credentials not configured, using mock mode");
                    return await SendMockSms(phoneNumber, otpCode ?? "N/A", message);
                }
                
                // Viettel SMS API
                var requestUrl = "https://api.viettel.com.vn/sms/v1/send";
                
                var requestData = new
                {
                    api_key = apiKey,
                    secret_key = secretKey,
                    phone = phoneNumber,
                    message = message,
                    brandname = brandName,
                    cpcode = cpCode,
                    message_type = "OTP",
                    otp = otpCode
                };
                
                var content = new StringContent(
                    JsonSerializer.Serialize(requestData),
                    Encoding.UTF8,
                    "application/json");
                
                var response = await _httpClient.PostAsync(requestUrl, content);
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending via Viettel");
                return false;
            }
        }
        
        private async Task<bool> SendViaMobifoneAsync(string phoneNumber, string message, string otpCode = null)
        {
            try
            {
                var smsConfig = _configuration.GetSection("Sms:Mobifone");
                var username = smsConfig["Username"];
                var password = smsConfig["Password"];
                var brandName = smsConfig["BrandName"];
                
                if (string.IsNullOrEmpty(username))
                {
                    _logger.LogWarning("Mobifone SMS credentials not configured, using mock mode");
                    return await SendMockSms(phoneNumber, otpCode ?? "N/A", message);
                }
                
                // Mobifone SMS API
                var requestUrl = "https://api.mobifone.com.vn/sms/send";
                
                var requestData = new
                {
                    username = username,
                    password = password,
                    msisdn = phoneNumber,
                    message = message,
                    brandname = brandName,
                    type = "text"
                };
                
                var content = new StringContent(
                    JsonSerializer.Serialize(requestData),
                    Encoding.UTF8,
                    "application/json");
                
                var response = await _httpClient.PostAsync(requestUrl, content);
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending via Mobifone");
                return false;
            }
        }
        
        private async Task<bool> SendViaVinaphoneAsync(string phoneNumber, string message, string otpCode = null)
        {
            try
            {
                var smsConfig = _configuration.GetSection("Sms:Vinaphone");
                var clientId = smsConfig["ClientId"];
                var clientSecret = smsConfig["ClientSecret"];
                var sender = smsConfig["Sender"];
                
                if (string.IsNullOrEmpty(clientId))
                {
                    _logger.LogWarning("Vinaphone SMS credentials not configured, using mock mode");
                    return await SendMockSms(phoneNumber, otpCode ?? "N/A", message);
                }
                
                // Vinaphone SMS API
                var requestUrl = "https://sms.vinaphone.com.vn/api/send";
                
                var requestData = new
                {
                    client_id = clientId,
                    client_secret = clientSecret,
                    phone = phoneNumber,
                    message = message,
                    sender = sender,
                    is_unicode = true
                };
                
                var content = new StringContent(
                    JsonSerializer.Serialize(requestData),
                    Encoding.UTF8,
                    "application/json");
                
                var response = await _httpClient.PostAsync(requestUrl, content);
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending via Vinaphone");
                return false;
            }
        }
        
        private async Task<bool> SendViaBrandSmsAsync(string phoneNumber, string message, string otpCode = null)
        {
            try
            {
                var smsConfig = _configuration.GetSection("Sms:BrandSms");
                var apiKey = smsConfig["ApiKey"];
                var secretKey = smsConfig["SecretKey"];
                var brandName = smsConfig["BrandName"];
                
                if (string.IsNullOrEmpty(apiKey))
                {
                    _logger.LogWarning("BrandSMS credentials not configured, using mock mode");
                    return await SendMockSms(phoneNumber, otpCode ?? "N/A", message);
                }
                
                // BrandSMS.vn API (một nhà cung cấp SMS Việt Nam phổ biến)
                var requestUrl = "https://api.brandsms.vn/send";
                
                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var signature = GenerateSignature(apiKey, secretKey, timestamp);
                
                var requestData = new
                {
                    api_key = apiKey,
                    signature = signature,
                    timestamp = timestamp,
                    phone = phoneNumber,
                    message = message,
                    brandname = brandName,
                    type = "quangcao" // hoặc "csms" cho SMS chăm sóc khách hàng
                };
                
                var content = new StringContent(
                    JsonSerializer.Serialize(requestData),
                    Encoding.UTF8,
                    "application/json");
                
                var response = await _httpClient.PostAsync(requestUrl, content);
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending via BrandSMS");
                return false;
            }
        }
        
        #endregion
        
        #region Helper Methods
        
        private string FormatPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be empty");
            
            phoneNumber = phoneNumber.Trim();
            
            // Xóa tất cả ký tự không phải số và dấu +
            var cleaned = new StringBuilder();
            foreach (char c in phoneNumber)
            {
                if (char.IsDigit(c) || c == '+')
                    cleaned.Append(c);
            }
            
            phoneNumber = cleaned.ToString();
            
            // Chuẩn hóa số điện thoại Việt Nam
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
        
        private bool IsValidVietnamPhoneNumber(string phoneNumber)
        {
            // Pattern cho số điện thoại Việt Nam
            var patterns = new[]
            {
                @"^\+84(3[2-9]|5[2689]|7[06-9]|8[1-689]|9[0-9])\d{7}$", // Di động
                @"^\+84(2[0-9]|2[0-9]{2})\d{7,8}$" // Điện thoại bàn
            };
            
            foreach (var pattern in patterns)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, pattern))
                    return true;
            }
            
            return false;
        }
        
        private string GenerateSignature(string apiKey, string secretKey, long timestamp)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var input = $"{apiKey}{secretKey}{timestamp}";
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
        
        public string GenerateOtpMessage(string otpCode, string appName = "ITO App")
        {
            return $"""
                {appName} - Ma xac thuc OTP cua ban la: {otpCode}.
                Ma co hieu luc trong 5 phut.
                KHONG chia se ma nay voi bat ky ai.
                """;
        }
        
        public string GeneratePasswordResetMessage(string resetLink, string appName = "ITO App")
        {
            return $"""
                {appName} - Yeu cau dat lai mat khau.
                Bam vao lien ket de dat lai mat khau: {resetLink}
                Lien ket co hieu luc trong 1 gio.
                Neu ban khong yeu cau, vui long bo qua email nay.
                """;
        }
        
        #endregion
    }
}