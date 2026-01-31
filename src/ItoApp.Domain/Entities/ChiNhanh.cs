using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
    public class ChiNhanh : BaseEntity
    {
        public string TenChiNhanh { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string? MoTa { get; set; }

        // Navigation
        public virtual ICollection<KhoaPhong> KhoaPhongs { get; set; } = new List<KhoaPhong>();
        public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
    }
}
