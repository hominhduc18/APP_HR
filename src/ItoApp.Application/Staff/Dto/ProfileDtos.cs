using System;

namespace ItoApp.Application.Staff.Dto
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string SoHopDong { get; set; } = string.Empty;
        public string LoaiHopDong { get; set; } = string.Empty;
        public DateTime NgayKy { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string? DuongDanFileScan { get; set; }
    }

    public class CreateContractRequest
    {
        public string SoHopDong { get; set; } = string.Empty;
        public string LoaiHopDong { get; set; } = string.Empty;
        public DateTime NgayKy { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string? DuongDanFileScan { get; set; }
    }

    public class LicenseDto
    {
        public int Id { get; set; }
        public string SoChungChi { get; set; } = string.Empty;
        public string PhamViChuyenMon { get; set; } = string.Empty;
        public string NoiCap { get; set; } = string.Empty;
        public DateTime NgayCap { get; set; }
        public DateTime? NgayGiaHan { get; set; }
        public DateTime? NgayHetHan { get; set; }
    }

    public class CreateLicenseRequest
    {
        public string SoChungChi { get; set; } = string.Empty;
        public string PhamViChuyenMon { get; set; } = string.Empty;
        public string NoiCap { get; set; } = string.Empty;
        public DateTime NgayCap { get; set; }
        public DateTime? NgayGiaHan { get; set; }
        public DateTime? NgayHetHan { get; set; }
    }

    public class TrainingDto
    {
        public int Id { get; set; }
        public string TenChungChi { get; set; } = string.Empty;
        public string NoiDaoTao { get; set; } = string.Empty;
        public DateTime NgayHoanThanh { get; set; }
        public DateTime? NgayHetHan { get; set; }
    }

    public class CreateTrainingRequest
    {
        public string TenChungChi { get; set; } = string.Empty;
        public string NoiDaoTao { get; set; } = string.Empty;
        public DateTime NgayHoanThanh { get; set; }
        public DateTime? NgayHetHan { get; set; }
    }

    public class PrivilegeDto
    {
        public int Id { get; set; }
        public string TenKyThuat { get; set; } = string.Empty;
        public string SoQuyetDinh { get; set; } = string.Empty;
        public DateTime NgayPheDuyet { get; set; }
        public string? MoTa { get; set; }
    }

    public class CreatePrivilegeRequest
    {
        public string TenKyThuat { get; set; } = string.Empty;
        public string SoQuyetDinh { get; set; } = string.Empty;
        public DateTime NgayPheDuyet { get; set; }
        public string? MoTa { get; set; }
    }

    public class ComplianceDto
    {
        public int Id { get; set; }
        public string HinhThuc { get; set; } = string.Empty;
        public string LyDo { get; set; } = string.Empty;
        public DateTime NgayViPham { get; set; }
        public string? SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
    }

    public class CreateComplianceRequest
    {
        public string HinhThuc { get; set; } = string.Empty;
        public string LyDo { get; set; } = string.Empty;
        public DateTime NgayViPham { get; set; }
        public string? SoQuyetDinh { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
    }

    public class AuditLogDto
    {
        public int Id { get; set; }
        public string ThaoTac { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public string NguoiThucHien { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
