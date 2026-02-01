using System.ComponentModel.DataAnnotations;

namespace ItoApp.Application.Auth.Dto
{
    public class PatientRequestOtpDto
    {
        [Required]
        [MinLength(9)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = "REGISTER"; // REGISTER, FORGOT_PASS
    }

    public class PatientRegisterDto
    {
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Otp { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }

    public class PatientLoginDto
    {
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class PatientResetPasswordDto
    {
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Otp { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; } = string.Empty;
    }

    public class PatientChangePasswordDto
    {
        // For logged-in users
        [Required]
        public long BenhNhanId { get; set; }

        [Required]
        public string OldPassword { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; } = string.Empty;
    }
}
