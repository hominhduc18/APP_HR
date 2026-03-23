using ItoApp.Shared.Common;

using ItoApp.Shared.Exceptions;
using ItoApp.Shared.Enums;
using ItoApp.Shared.ValueObjects;
using ItoApp.Shared.Common;

namespace ItoApp.Domain.Entities
{
    public class ChungChiHanhNghe : BaseEntity
    {
        public string SoChungChi { get; set; } = string.Empty;
        public string PhamViChuyenMon { get; set; } = string.Empty;
        public string NoiCap { get; set; } = string.Empty;
        public DateTime NgayCap { get; set; }
        public DateTime? NgayGiaHan { get; set; }
        public DateTime? NgayHetHan { get; set; }
        
        public int NhanVienId { get; set; }
        public virtual NhanVien NhanVien { get; set; } = null!;
    }
}



