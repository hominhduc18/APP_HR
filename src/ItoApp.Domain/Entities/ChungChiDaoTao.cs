using ItoApp.Shared.Common;

using ItoApp.Shared.Exceptions;
using ItoApp.Shared.Enums;
using ItoApp.Shared.ValueObjects;
using ItoApp.Shared.Common;

namespace ItoApp.Domain.Entities
{
    public class ChungChiDaoTao : BaseEntity
    {
        public string TenChungChi { get; set; } = string.Empty; // CPR, ACLS, KSNK...
        public string NoiDaoTao { get; set; } = string.Empty;
        public DateTime NgayHoanThanh { get; set; }
        public DateTime? NgayHetHan { get; set; }
        
        public int NhanVienId { get; set; }
        public virtual NhanVien NhanVien { get; set; } = null!;
    }
}



