using System;

namespace ItoApp.Application.Staff.Dto
{
    public class StaffDto
    {
        public int Id { get; set; }
        public string MaNhanVien { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string TrangThai { get; set; } = string.Empty;
        
        public int ChiNhanhId { get; set; }
        public string TenChiNhanh { get; set; } = string.Empty;
        
        public int KhoaPhongId { get; set; }
        public string TenKhoaPhong { get; set; } = string.Empty;
        
        public int NhomNgheNghiepId { get; set; }
        public string TenNhomNgheNghiep { get; set; } = string.Empty;
        
        public int ChucVuId { get; set; }
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
        public int ChiNhanhId { get; set; }
        public int KhoaPhongId { get; set; }
        public int NhomNgheNghiepId { get; set; }
        public int ChucVuId { get; set; }
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
        public int NewKhoaPhongId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string? Reason { get; set; }
    }
}


