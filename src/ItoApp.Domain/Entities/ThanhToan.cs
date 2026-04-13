using ItoApp.Shared.Common;

namespace ItoApp.Domain.Entities
{
    public class ThanhToan : BaseEntity
    {
        public string MaDon { get; set; } = string.Empty;
        public decimal SoTien { get; set; }
        public string TrangThai { get; set; } = "PENDING"; // PENDING, PAID, FAILED
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public DateTime? NgayThanhToan { get; set; }
        public string? MaGiaoDich { get; set; } // vnp_TransactionNo
    }
}
