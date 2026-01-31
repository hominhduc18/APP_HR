using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
    public class KhoaPhong : BaseEntity
    {
        public string TenKhoaPhong { get; set; } = string.Empty;
        public string? MoTa { get; set; }
        
        public Guid ChiNhanhId { get; set; }
        public virtual ChiNhanh ChiNhanh { get; set; } = null!;

        // Navigation
        public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
    }
}
