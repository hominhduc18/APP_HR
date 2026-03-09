using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ItoApp.Application.Auth.Dto
{
    // 1. Đăng nhập
    public class YeuCauDangNhapV3
    {
        [Required]
        [JsonPropertyName("so_dien_thoai")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("mat_khau")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("token_thiet_bi")]
        public string? DeviceToken { get; set; }
    }

    public class PhanHoiDangNhapV3
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;

        [JsonPropertyName("user")]
        public ThongTinNguoiDungV3 User { get; set; } = new();
    }

    public class ThongTinNguoiDungV3
    {
        [JsonPropertyName("nguoi_dung_Id")]
        public int UserId { get; set; }

        [JsonPropertyName("ho_ten")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("vai_tro")]
        public string VaiTro { get; set; } = "benh_nhan";
    }

    // 2. Đăng ký
    public class YeuCauDangKyV3
    {
        [Required]
        [JsonPropertyName("so_dien_thoai")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("mat_khau")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("ho_ten")]
        public string FullName { get; set; } = string.Empty;
    }

    public class PhanHoiDangKyV3
    {
        [JsonPropertyName("nguoi_dung_Id")]
        public int UserId { get; set; }

        [JsonPropertyName("so_dien_thoai")]
        public string PhoneNumber { get; set; } = string.Empty;
    }

    // 3. Gửi OTP
    public class YeuCauGuiOtpV3
    {
        [Required]
        [JsonPropertyName("so_dien_thoai")]
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public class PhanHoiGuiOtpV3
    {
        [JsonPropertyName("otp_temp")]
        public string OtpTemp { get; set; } = string.Empty;
    }

    // 4. Xác minh OTP
    public class YeuCauXacMinhOtpV3
    {
        [Required]
        [JsonPropertyName("so_dien_thoai")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("ma_otp")]
        public string OtpCode { get; set; } = string.Empty;
    }

    public class PhanHoiXacMinhOtpV3
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "verified";
    }

    // 5. Đổi mật khẩu
    public class YeuCauDoiMatKhauV3
    {
        [Required]
        [JsonPropertyName("mat_khau_cu")]
        public string OldPassword { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("mat_khau_moi")]
        public string NewPassword { get; set; } = string.Empty;
    }

    // 6. Thông tin cá nhân
    public class PhanHoiHoSoNguoiDungV3
    {
        [JsonPropertyName("nguoi_dung_Id")]
        public int UserId { get; set; }

        [JsonPropertyName("ho_ten")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("so_dien_thoai")]
        public string PhoneNumber { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("anh_dai_dien")]
        public string? Avatar { get; set; }
    }
}
