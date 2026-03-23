using ItoApp.Shared.Common;

using ItoApp.Shared.Exceptions;
using ItoApp.Shared.Enums;
using ItoApp.Shared.ValueObjects;
using ItoApp.Shared.Common;

namespace ItoApp.Domain.Entities
{
    public class NhomNgheNghiep : BaseEntity
    {
        public string TenNhom { get; set; } = string.Empty; // Bác sĩ, Điều dưỡng, KTV, Hành chính
        public string? MaNhom { get; set; } // BS, DD, KTV, HC
        public string? MoTa { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
    }
}



