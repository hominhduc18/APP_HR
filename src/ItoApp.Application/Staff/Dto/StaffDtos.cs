using System;

namespace ItoApp.Application.Staff.Dto
{
    public class StaffDto
    {
        public Guid Id { get; set; }
        public string MaNhanVien { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string TrangThai { get; set; } = string.Empty;
        
        public Guid ChiNhanhId { get; set; }
        public string TenChiNhanh { get; set; } = string.Empty;
        
        public Guid KhoaPhongId { get; set; }
        public string TenKhoaPhong { get; set; } = string.Empty;
        
        public Guid NhomNgheNghiepId { get; set; }
        public string TenNhomNgheNghiep { get; set; } = string.Empty;
        
        public Guid ChucVuId { get; set; }
        public string TenChucVu { get; set; } = string.Empty;
    }

    public class CreateStaffRequest
    {
        public string MaNhanVien { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public Guid ChiNhanhId { get; set; }
        public Guid KhoaPhongId { get; set; }
        public Guid NhomNgheNghiepId { get; set; }
        public Guid ChucVuId { get; set; }
    }

    public class UpdateStaffRequest : CreateStaffRequest
    {
    }

    public class UpdateStaffStatusRequest
    {
        public string TrangThai { get; set; } = string.Empty;
    }

    public class TransferStaffRequest
    {
        public Guid NewKhoaPhongId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string? Reason { get; set; }
    }
}
