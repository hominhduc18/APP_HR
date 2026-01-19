using System.ComponentModel.DataAnnotations;

namespace ItoApp.Application.Auth.Dto
{

     // Request để gửi OTP đăng ký
    public class SendRegisterOtpRequest
    {
        [Required(ErrorMessage = "Số điện thoại hoặc email là bắt buộc")]
        public string PhoneOrEmail { get; set; } = string.Empty;
    }
    
    // Request để xác thực OTP và đăng ký
    public class VerifyRegisterOtpRequest
    {
        [Required(ErrorMessage = "Số điện thoại hoặc email là bắt buộc")]
        public string PhoneOrEmail { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Mã OTP là bắt buộc")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Mã OTP phải có 6 chữ số")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Mã OTP chỉ được chứa số")]
        public string Otp { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [MaxLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự")]
        public string FullName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        [MaxLength(50, ErrorMessage = "Mật khẩu không được vượt quá 50 ký tự")]
        public string Password { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Xác nhận mật khẩu là bắt buộc")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
    
    // Request đăng nhập
    public class PatientLoginRequest
    {
        [Required(ErrorMessage = "Số điện thoại hoặc email là bắt buộc")]
        public string PhoneOrEmail { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        public string Password { get; set; } = string.Empty;
        
        public bool RememberMe { get; set; } = true;
    }
    
    // Request gửi OTP quên mật khẩu
    public class SendForgotPasswordOtpRequest
    {
        [Required(ErrorMessage = "Số điện thoại hoặc email là bắt buộc")]
        public string PhoneOrEmail { get; set; } = string.Empty;
    }
    
    // Request xác nhận OTP và đổi mật khẩu
    public class ConfirmForgotPasswordRequest
    {
        [Required(ErrorMessage = "Số điện thoại hoặc email là bắt buộc")]
        public string PhoneOrEmail { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Mã OTP là bắt buộc")]
        [StringLength(6, MinimumLength = 6)]
        public string Otp { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Mật khẩu mới là bắt buộc")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string NewPassword { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Xác nhận mật khẩu là bắt buộc")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
    
    // Response đăng nhập/đăng ký thành công
    public class PatientAuthResponse
    {
        public Guid UserId { get; set; }
        public Guid PatientId { get; set; }
        public string PhoneOrEmail { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime AccessTokenExpires { get; set; }
        public DateTime RefreshTokenExpires { get; set; }
        public bool IsVerified { get; set; }
        public bool HasProfile { get; set; }
    }

    
}