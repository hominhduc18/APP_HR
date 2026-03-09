using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
    public class HopDongLaoDong : BaseEntity
    {
        public string SoHopDong { get; set; } = string.Empty;
        public string LoaiHopDong { get; set; } = string.Empty; // Có thời hạn, Vô thời hạn
        public DateTime NgayKy { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string? DuongDanFileScan { get; set; }
        
        public int NhanVienId { get; set; }
        public virtual NhanVien NhanVien { get; set; } = null!;
    }
}
