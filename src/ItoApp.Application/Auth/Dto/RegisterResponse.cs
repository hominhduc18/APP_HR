namespace ItoApp.Application.Auth.Dto;

public class RegisterResponse
{
    public long UserId { get; set; }
    public long PatientId { get; set; }
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}