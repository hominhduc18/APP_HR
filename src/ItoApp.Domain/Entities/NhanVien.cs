using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
    public class NhanVien : BaseEntity
    {
        public string MaNhanVien { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string TrangThai { get; set; } = "Active"; // Active, Terminated, Locked

        // Foreign Keys
        public Guid ChiNhanhId { get; set; }
        public virtual ChiNhanh ChiNhanh { get; set; } = null!;

        public Guid KhoaPhongId { get; set; }
        public virtual KhoaPhong KhoaPhong { get; set; } = null!;

        public Guid NhomNgheNghiepId { get; set; }
        public virtual NhomNgheNghiep NhomNgheNghiep { get; set; } = null!;

        public Guid ChucVuId { get; set; }
        public virtual ChucVu ChucVu { get; set; } = null!;

        // Navigation
        public virtual ICollection<HopDongLaoDong> HopDongLaoDongs { get; set; } = new List<HopDongLaoDong>();
        public virtual ICollection<ChungChiHanhNghe> ChungChiHanhNghes { get; set; } = new List<ChungChiHanhNghe>();
        public virtual ICollection<ChungChiDaoTao> ChungChiDaoTaos { get; set; } = new List<ChungChiDaoTao>();
    }
}
