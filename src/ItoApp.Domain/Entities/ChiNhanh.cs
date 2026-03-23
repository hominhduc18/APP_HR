using ItoApp.Shared.Common;

using ItoApp.Shared.Exceptions;
using ItoApp.Shared.Enums;
using ItoApp.Shared.ValueObjects;
using ItoApp.Shared.Common;

namespace ItoApp.Domain.Entities
{
    public class ChiNhanh : BaseEntity
    {
        public string MaChiNhanh { get; set; } = string.Empty;
        public string TenChiNhanh { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string? MaSoThue { get; set; }
        public string? MoTa { get; set; }

        // Navigation
        public virtual ICollection<KhoaPhong> KhoaPhongs { get; set; } = new List<KhoaPhong>();
        public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
    }
}



