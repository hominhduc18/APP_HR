using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
    public class KyLuat : BaseEntity
    {
        public string HinhThuc { get; set; } = string.Empty; // Khiển trách, Cảnh cáo, Sa thải...
        public string LyDo { get; set; } = string.Empty;
        public DateTime NgayViPham { get; set; }
        public string? SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public string? Nodung { get; set; }

        public int NhanVienId { get; set; }
        public virtual NhanVien NhanVien { get; set; } = null!;
    }
}
