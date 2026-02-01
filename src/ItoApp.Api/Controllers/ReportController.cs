using ItoApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("staff-360/{id:guid}")]
        public async Task<IActionResult> ExportStaff360(Guid id)
        {
            var staff = await _context.NhanViens
                .Include(n => n.ChiNhanh)
                .Include(n => n.KhoaPhong)
                .Include(n => n.HopDongLaoDongs)
                .Include(n => n.ChungChiHanhNghes)
                .Include(n => n.ChungChiDaoTaos)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (staff == null) return NotFound();

            // Logic to generate PDF would go here.
            // Returning JSON for now as a data source for the report.
            return Ok(new {
                message = "Dữ liệu xuất hồ sơ 360",
                data = staff
            });
        }

        [HttpGet("license-red-list")]
        public async Task<IActionResult> ExportLicenseRedList()
        {
            var today = DateTime.Now;
            var next3Months = today.AddMonths(3);

            var data = await _context.ChungChiHanhNghes
                .Include(c => c.NhanVien)
                .Where(c => c.NgayHetHan != null && c.NgayHetHan <= next3Months)
                .OrderBy(c => c.NgayHetHan)
                .Select(c => new {
                    c.NhanVien.MaNhanVien,
                    c.NhanVien.HoTen,
                    c.SoChungChi,
                    c.NgayHetHan,
                    Status = c.NgayHetHan < today ? "Đã hết hạn" : "Sắp hết hạn"
                })
                .ToListAsync();

            return Ok(new {
                message = "Danh sách rủi ro nợ CCHN",
                items = data
            });
        }

        [HttpGet("training-gap")]
        public async Task<IActionResult> ExportTrainingGap()
        {
            // Logic to find staff missing required training like CPR, ACLS
            // This is a placeholder logic
            var staff = await _context.NhanViens
                .Include(n => n.ChungChiDaoTaos)
                .Select(n => new {
                    n.MaNhanVien,
                    n.HoTen,
                    DaCoCPR = n.ChungChiDaoTaos.Any(t => t.TenChungChi.Contains("CPR")),
                    DaCoACLS = n.ChungChiDaoTaos.Any(t => t.TenChungChi.Contains("ACLS"))
                })
                .Where(x => !x.DaCoCPR || !x.DaCoACLS)
                .ToListAsync();

            return Ok(new {
                message = "Báo cáo nợ đào tạo (Gap Analysis)",
                items = staff
            });
        }

        [HttpGet("hr-master-list")]
        public async Task<IActionResult> ExportMasterList()
        {
            var data = await _context.NhanViens
                .Include(n => n.ChiNhanh)
                .Include(n => n.KhoaPhong)
                .Include(n => n.NhomNgheNghiep)
                .Include(n => n.ChucVu)
                .Select(n => new {
                    n.MaNhanVien,
                    n.HoTen,
                    n.NgaySinh,
                    n.GioiTinh,
                    n.NgayVaoLam,
                    KhoaPhong = n.KhoaPhong.TenKhoaPhong,
                    ChucVu = n.ChucVu.TenChucVu,
                    TrangThai = n.TrangThai
                })
                .ToListAsync();

            return Ok(new {
                message = "Danh sách nhân viên chuẩn Excel Sở Y Tế",
                items = data
            });
        }
    }
}
