using ItoApp.Shared.Common;

using ItoApp.Shared.Exceptions;
using ItoApp.Shared.Enums;
using ItoApp.Shared.ValueObjects;
using ItoApp.Shared.Common;

namespace ItoApp.Domain.Entities
{
    public class KyThuatChuyenMon : BaseEntity
    {
        public string TenKyThuat { get; set; } = string.Empty;
        public string SoQuyetDinh { get; set; } = string.Empty;
        public DateTime NgayPheDuyet { get; set; }
        public string? MoTa { get; set; }

        public int NhanVienId { get; set; }
        public virtual NhanVien NhanVien { get; set; } = null!;
    }
}



