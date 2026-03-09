namespace ItoApp.Application.Auth.Dto;

public class RegisterResponse
{
    public int UserId { get; set; }
    public int PatientId { get; set; }
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}