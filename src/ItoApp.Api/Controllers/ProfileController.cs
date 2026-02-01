using ItoApp.Application.Staff.Dto;
using ItoApp.Domain.Entities;
using ItoApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/staff/{staffId:guid}")]
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- CONTRACTS ---
        [HttpGet("contracts")]
        public async Task<IActionResult> GetContracts(Guid staffId)
        {
            var data = await _context.HopDongLaoDongs
                .Where(x => x.NhanVienId == staffId)
                .Select(x => new ContractDto {
                    Id = x.Id,
                    SoHopDong = x.SouHopDong,
                    LoaiHopDong = x.LoaiHopDong,
                    NgayKy = x.NgayKy,
                    NgayHetHan = x.NgayHetHan,
                    DuongDanFileScan = x.DuongDanFileScan
                }).ToListAsync();
            return Ok(data);
        }

        [HttpPost("contracts")]
        public async Task<IActionResult> CreateContract(Guid staffId, [FromBody] CreateContractRequest req)
        {
            var item = new HopDongLaoDong {
                NhanVienId = staffId,
                SouHopDong = req.SoHopDong,
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
        [HttpGet("licenses")]
        public async Task<IActionResult> GetLicenses(Guid staffId)
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

        [HttpPost("licenses")]
        public async Task<IActionResult> CreateLicense(Guid staffId, [FromBody] CreateLicenseRequest req)
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
        [HttpGet("training")]
        public async Task<IActionResult> GetTraining(Guid staffId)
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

        [HttpPost("training")]
        public async Task<IActionResult> CreateTraining(Guid staffId, [FromBody] CreateTrainingRequest req)
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
    }
}
