using System;

namespace ItoApp.Application.Staff.Dto
{
    public class ContractDto
    {
        public Guid Id { get; set; }
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
        public Guid Id { get; set; }
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
        public Guid Id { get; set; }
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
}
