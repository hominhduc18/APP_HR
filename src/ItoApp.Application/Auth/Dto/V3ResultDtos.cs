using System.Text.Json.Serialization;

namespace ItoApp.Application.Auth.Dto
{
    public class PhanHoiKetQuaV3
    {
        [JsonPropertyName("ket_qua_id")]
        public int KetQuaId { get; set; }

        [JsonPropertyName("ten_dich_vu")]
        public string TenDichVu { get; set; } = string.Empty;

        [JsonPropertyName("ngay_thuc_hien")]
        public string NgayThucHien { get; set; } = string.Empty;

        [JsonPropertyName("bac_si_chi_dinh")]
        public string? BacSiChiDinh { get; set; }

        [JsonPropertyName("trang_thai")]
        public string TrangThai { get; set; } = "da_co_ket_qua";
    }

    public class PhanHoiChiTietKetQuaV3 : PhanHoiKetQuaV3
    {
        [JsonPropertyName("ket_luan")]
        public string? KetLuan { get; set; }

        [JsonPropertyName("mo_ta_chi_tiet")]
        public string? MoTaChiTiet { get; set; }

        [JsonPropertyName("hinh_anh_urls")]
        public List<string> HinhAnhUrls { get; set; } = new();
    }
}
