using System.Text.Json.Serialization;

namespace ItoApp.Application.Auth.Dto
{
    public class PhanHoiChiNhanhV3
    {
        [JsonPropertyName("chi_nhanh_id")]
        public int ChiNhanhId { get; set; }

        [JsonPropertyName("ten_chi_nhanh")]
        public string TenChiNhanh { get; set; } = string.Empty;

        [JsonPropertyName("dia_chi")]
        public string DiaChi { get; set; } = string.Empty;

        [JsonPropertyName("so_dien_thoai")]
        public string SoDienThoai { get; set; } = string.Empty;

        [JsonPropertyName("anh_dai_dien")]
        public string? AnhDaiDien { get; set; }
    }

    public class PhanHoiKhoaPhongV3
    {
        [JsonPropertyName("khoa_id")]
        public int KhoaId { get; set; }

        [JsonPropertyName("ten_khoa")]
        public string TenKhoa { get; set; } = string.Empty;

        [JsonPropertyName("anh_dai_dien")]
        public string? AnhDaiDien { get; set; }
    }

    public class PhanHoiBacSiV3
    {
        [JsonPropertyName("bac_si_id")]
        public int BacSiId { get; set; }

        [JsonPropertyName("ho_ten")]
        public string HoTen { get; set; } = string.Empty;

        [JsonPropertyName("hoc_ham_hoc_vi")]
        public string? HocHamHocVi { get; set; }

        [JsonPropertyName("anh_dai_dien")]
        public string? AnhDaiDien { get; set; }

        [JsonPropertyName("chuyen_khoa")]
        public string? ChuyenKhoa { get; set; }
    }

    public class PhanHoiChiTietBacSiV3 : PhanHoiBacSiV3
    {
        [JsonPropertyName("gioi_thieu")]
        public string? GioiThieu { get; set; }

        [JsonPropertyName("lich_trong")]
        public List<string> LichTrong { get; set; } = new();
    }
}
