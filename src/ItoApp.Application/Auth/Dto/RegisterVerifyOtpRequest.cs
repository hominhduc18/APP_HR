namespace ItoApp.Application.Auth.Dto;

public class RegisterVerifyOtpRequest
{
    public string Phone { get; set; } = string.Empty;
    public string Otp { get; set; } = string.Empty;
}