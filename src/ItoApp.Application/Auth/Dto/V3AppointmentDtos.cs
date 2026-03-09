using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ItoApp.Application.Auth.Dto
{
    public class PhanHoiKhungGioV3
    {
        [JsonPropertyName("khung_gio_id")]
        public int KhungGioId { get; set; }

        [JsonPropertyName("gio_bat_dau")]
        public string GioBatDau { get; set; } = string.Empty;

        [JsonPropertyName("gio_ket_thuc")]
        public string GioKetThuc { get; set; } = string.Empty;

        [JsonPropertyName("con_trong")]
        public bool ConTrong { get; set; }
    }

    public class PhanHoiGoiKhamV3
    {
        [JsonPropertyName("goi_kham_id")]
        public int GoiKhamId { get; set; }

        [JsonPropertyName("ten_goi")]
        public string TenGoi { get; set; } = string.Empty;

        [JsonPropertyName("gia_tien")]
        public decimal GiaTien { get; set; }

        [JsonPropertyName("mo_ta")]
        public string? MoTa { get; set; }
    }

    public class YeuCauDatLichV3
    {
        [Required]
        [JsonPropertyName("ho_so_id")]
        public int HoSoId { get; set; }

        [Required]
        [JsonPropertyName("chi_nhanh_id")]
        public int ChiNhanhId { get; set; }

        [Required]
        [JsonPropertyName("bac_si_id")]
        public int BacSiId { get; set; }

        [Required]
        [JsonPropertyName("ngay_hen")]
        public string NgayHen { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("khung_gio_id")]
        public int KhungGioId { get; set; }

        [JsonPropertyName("goi_kham_id")]
        public int? GoiKhamId { get; set; }

        [JsonPropertyName("ly_do_kham")]
        public string? LyDoKham { get; set; }
    }

    public class PhanHoiLichSuLichHenV3
    {
        [JsonPropertyName("lich_hen_id")]
        public int LichHenId { get; set; }

        [JsonPropertyName("ma_lich_hen")]
        public string MaLichHen { get; set; } = string.Empty;

        [JsonPropertyName("ngay_hen")]
        public string NgayHen { get; set; } = string.Empty;

        [JsonPropertyName("gio_hen")]
        public string GioHen { get; set; } = string.Empty;

        [JsonPropertyName("ten_bac_si")]
        public string TenBacSi { get; set; } = string.Empty;

        [JsonPropertyName("trang_thai")]
        public string TrangThai { get; set; } = string.Empty;

        [JsonPropertyName("ten_chi_nhanh")]
        public string TenChiNhanh { get; set; } = string.Empty;
    }

    public class YeuCauHuyLichHenV3
    {
        [Required]
        [JsonPropertyName("lich_hen_id")]
        public int LichHenId { get; set; }

        [JsonPropertyName("ly_do_huy")]
        public string? LyDoHuy { get; set; }
    }
}
