using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ItoApp.Application.Auth.Dto
{
    public class PhanHoiHoSoBenhNhanV3
    {
        [JsonPropertyName("ho_so_id")]
        public int HoSoId { get; set; }

        [JsonPropertyName("ho_ten")]
        public string HoTen { get; set; } = string.Empty;

        [JsonPropertyName("ngay_sinh")]
        public string NgaySinh { get; set; } = string.Empty;

        [JsonPropertyName("gioi_tinh")]
        public string GioiTinh { get; set; } = string.Empty;

        [JsonPropertyName("so_dien_thoai")]
        public string SoDienThoai { get; set; } = string.Empty;

        [JsonPropertyName("quan_he")]
        public string? QuanHe { get; set; }

        [JsonPropertyName("ma_benh_nhan")]
        public string? MaBenhNhan { get; set; }
    }

    public class YeuCauThemHoSoV3
    {
        [Required]
        [JsonPropertyName("ho_ten")]
        public string HoTen { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("ngay_sinh")]
        public string NgaySinh { get; set; } = string.Empty; // Format YYYY-MM-DD

        [Required]
        [JsonPropertyName("gioi_tinh")]
        public string GioiTinh { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("so_dien_thoai")]
        public string SoDienThoai { get; set; } = string.Empty;

        [JsonPropertyName("quan_he")]
        public string? QuanHe { get; set; }
    }

    public class YeuCauCapNhatHoSoV3 : YeuCauThemHoSoV3
    {
        [Required]
        [JsonPropertyName("ho_so_id")]
        public int HoSoId { get; set; }
    }

    public class YeuCauXoaHoSoV3
    {
        [Required]
        [JsonPropertyName("ho_so_id")]
        public int HoSoId { get; set; }
    }
}
