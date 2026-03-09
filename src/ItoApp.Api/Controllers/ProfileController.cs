using ItoApp.Application.Staff.Dto;
using ItoApp.Domain.Entities;
using ItoApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/nhan-vien/{staffId:int}")]
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- CONTRACTS ---
        [HttpGet("hop-dong")]
        public async Task<IActionResult> GetContracts(int staffId)
        {
            var data = await _context.HopDongLaoDongs
                .Where(x => x.NhanVienId == staffId)
                .Select(x => new ContractDto {
                    Id = x.Id,
                    SoHopDong = x.SoHopDong,
                    LoaiHopDong = x.LoaiHopDong,
                    NgayKy = x.NgayKy,
                    NgayHetHan = x.NgayHetHan,
                    DuongDanFileScan = x.DuongDanFileScan
                }).ToListAsync();
            return Ok(data);
        }

        [HttpPost("hop-dong")]
        public async Task<IActionResult> CreateContract(int staffId, [FromBody] CreateContractRequest req)
        {
            var item = new HopDongLaoDong {
                NhanVienId = staffId,
                SoHopDong = req.SoHopDong,
                LoaiHopDong = req.LoaiHopDong,
                NgayKy = req.NgayKy,
                NgayHetHan = req.NgayHetHan,
                DuongDanFileScan = req.DuongDanFileScan
            };
            _context.HopDongLaoDongs.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item.Id);
        }

        // --- LICENSES ---
        [HttpGet("chung-chi-hanh-nghe")]
        public async Task<IActionResult> GetLicenses(int staffId)
        {
            var data = await _context.ChungChiHanhNghes
                .Where(x => x.NhanVienId == staffId)
                .Select(x => new LicenseDto {
                    Id = x.Id,
                    SoChungChi = x.SoChungChi,
                    PhamViChuyenMon = x.PhamViChuyenMon,
                    NoiCap = x.NoiCap,
                    NgayCap = x.NgayCap,
                    NgayGiaHan = x.NgayGiaHan,
                    NgayHetHan = x.NgayHetHan
                }).ToListAsync();
            return Ok(data);
        }

        [HttpPost("chung-chi-hanh-nghe")]
        public async Task<IActionResult> CreateLicense(int staffId, [FromBody] CreateLicenseRequest req)
        {
            var item = new ChungChiHanhNghe {
                NhanVienId = staffId,
                SoChungChi = req.SoChungChi,
                PhamViChuyenMon = req.PhamViChuyenMon,
                NoiCap = req.NoiCap,
                NgayCap = req.NgayCap,
                NgayGiaHan = req.NgayGiaHan,
                NgayHetHan = req.NgayHetHan
            };
            _context.ChungChiHanhNghes.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item.Id);
        }

        // --- TRAINING ---
        [HttpGet("dao-tao")]
        public async Task<IActionResult> GetTraining(int staffId)
        {
            var data = await _context.ChungChiDaoTaos
                .Where(x => x.NhanVienId == staffId)
                .Select(x => new TrainingDto {
                    Id = x.Id,
                    TenChungChi = x.TenChungChi,
                    NoiDaoTao = x.NoiDaoTao,
                    NgayHoanThanh = x.NgayHoanThanh,
                    NgayHetHan = x.NgayHetHan
                }).ToListAsync();
            return Ok(data);
        }

        [HttpPost("dao-tao")]
        public async Task<IActionResult> CreateTraining(int staffId, [FromBody] CreateTrainingRequest req)
        {
            var item = new ChungChiDaoTao {
                NhanVienId = staffId,
                TenChungChi = req.TenChungChi,
                NoiDaoTao = req.NoiDaoTao,
                NgayHoanThanh = req.NgayHoanThanh,
                NgayHetHan = req.NgayHetHan
            };
            _context.ChungChiDaoTaos.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item.Id);
        }

        // --- PRIVILEGES ---
        [HttpGet("ky-thuat-chuyen-mon")]
        public async Task<IActionResult> GetPrivileges(int staffId)
        {
            var data = await _context.KyThuatChuyenMons
                .Where(x => x.NhanVienId == staffId)
                .Select(x => new PrivilegeDto {
                    Id = x.Id,
                    TenKyThuat = x.TenKyThuat,
                    SoQuyetDinh = x.SoQuyetDinh,
                    NgayPheDuyet = x.NgayPheDuyet,
                    MoTa = x.MoTa
                }).ToListAsync();
            return Ok(data);
        }

        [HttpPost("ky-thuat-chuyen-mon")]
        public async Task<IActionResult> CreatePrivilege(int staffId, [FromBody] CreatePrivilegeRequest req)
        {
            var item = new KyThuatChuyenMon {
                NhanVienId = staffId,
                TenKyThuat = req.TenKyThuat,
                SoQuyetDinh = req.SoQuyetDinh,
                NgayPheDuyet = req.NgayPheDuyet,
                MoTa = req.MoTa
            };
            _context.KyThuatChuyenMons.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item.Id);
        }

        // --- COMPLIANCE ---
        [HttpGet("ky-luat")]
        public async Task<IActionResult> GetCompliance(int staffId)
        {
            var data = await _context.KyLuats
                .Where(x => x.NhanVienId == staffId)
                .Select(x => new ComplianceDto {
                    Id = x.Id,
                    HinhThuc = x.HinhThuc,
                    LyDo = x.LyDo,
                    NgayViPham = x.NgayViPham,
                    SoQuyetDinh = x.SoQuyetDinh,
                    NgayQuyetDinh = x.NgayQuyetDinh
                }).ToListAsync();
            return Ok(data);
        }

        [HttpPost("ky-luat")]
        public async Task<IActionResult> CreateCompliance(int staffId, [FromBody] CreateComplianceRequest req)
        {
            var item = new KyLuat {
                NhanVienId = staffId,
                HinhThuc = req.HinhThuc,
                LyDo = req.LyDo,
                NgayViPham = req.NgayViPham,
                SoQuyetDinh = req.SoQuyetDinh,
                NgayQuyetDinh = req.NgayQuyetDinh
            };
            _context.KyLuats.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item.Id);
        }

        // --- AUDIT LOGS ---
        [HttpGet("nhat-ky-chinh-sua")]
        public async Task<IActionResult> GetAuditLogs(int staffId)
        {
            var data = await _context.LichSuChinhSuas
                .Where(x => x.NhanVienId == staffId)
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new AuditLogDto {
                    Id = x.Id,
                    ThaoTac = x.ThaoTac,
                    NoiDung = x.NoiDung,
                    NguoiThucHien = x.NguoiThucHien,
                    CreatedAt = x.CreatedAt
                }).ToListAsync();
            return Ok(data);
        }
    }
}
