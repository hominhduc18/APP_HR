using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
    public class ChucVu : BaseEntity
    {
        public string TenChucVu { get; set; } = string.Empty;
        public string? MoTa { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
    }
}
