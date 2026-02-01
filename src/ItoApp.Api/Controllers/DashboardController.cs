using ItoApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/thong-ke")]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("chi-so-kpi")]
        public async Task<IActionResult> GetKpis()
        {
            var totalStaff = await _context.NhanViens.CountAsync(n => n.TrangThai == "Active");
            var resigned = await _context.NhanViens.CountAsync(n => n.TrangThai == "Terminated");
            
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var newHires = await _context.NhanViens.CountAsync(n => n.NgayVaoLam.Month == currentMonth && n.NgayVaoLam.Year == currentYear);

            var staffWithLicense = await _context.ChungChiHanhNghes.Select(c => c.NhanVienId).Distinct().CountAsync();
            var licenseRate = totalStaff > 0 ? (double)staffWithLicense / totalStaff * 100 : 0;

            // Fake some other stats for demo based on image
            var kpis = new {
                tongNhanVien = totalStaff,
                dangLamViec = totalStaff,
                nghiViec = resigned,
                tuyenMoi = newHires,
                tyLeCCHN = Math.Round(licenseRate, 1),
                caHetHanCCHN = await _context.ChungChiHanhNghes.CountAsync(c => c.NgayHetHan < DateTime.Now),
                tyLeDaoTao = 85.5, // Placeholder
                nhanVienNoDaoTao = 12 // Placeholder
            };

            return Ok(kpis);
        }

        [HttpGet("bieu-do/co-cau")]
        public async Task<IActionResult> GetStructureChart()
        {
            var data = await _context.NhanViens
                .Include(n => n.NhomNgheNghiep)
                .GroupBy(n => n.NhomNgheNghiep.MaNhom)
                .Select(g => new {
                    group = g.Key ?? "Khác",
                    count = g.Count()
                }).ToListAsync();
            
            // Format to match image suggestion {BS: n, DD: n, KTV: n, HC: n}
            var result = data.ToDictionary(x => x.group, x => x.count);
            return Ok(result);
        }

        [HttpGet("bieu-do/khoa-phong")]
        public async Task<IActionResult> GetDeptChart()
        {
            var data = await _context.NhanViens
                .Include(n => n.KhoaPhong)
                .GroupBy(n => n.KhoaPhong.TenKhoaPhong)
                .Select(g => new {
                    khoa = g.Key,
                    count = g.Count()
                })
                .OrderByDescending(x => x.count)
                .Take(10)
                .ToListAsync();

            return Ok(data);
        }

        [HttpGet("bieu-do/bien-dong")]
        public async Task<IActionResult> GetTrendChart()
        {
            // Calculate trend for last 6 months
            var result = new List<object>();
            for (int i = 5; i >= 0; i--)
            {
                var monthDate = DateTime.Now.AddMonths(-i);
                var monthLabel = $"T{monthDate.Month}";
                
                var inCount = await _context.NhanViens.CountAsync(n => n.NgayVaoLam.Month == monthDate.Month && n.NgayVaoLam.Year == monthDate.Year);
                // For "out", we'd need a ResignDate field, using placeholder or random low number for now
                var outCount = (i % 2 == 0) ? 1 : 0; 

                result.Add(new { month = monthLabel, @in = inCount, @out = outCount });
            }

            return Ok(result);
        }

        [HttpGet("canh-bao/chung-chi")]
        public async Task<IActionResult> GetLicenseAlerts()
        {
            var today = DateTime.Now;
            var next3Months = today.AddMonths(3);

            var alerts = await _context.ChungChiHanhNghes
                .Include(c => c.NhanVien)
                .Where(c => c.NgayHetHan != null && c.NgayHetHan >= today && c.NgayHetHan <= next3Months)
                .OrderBy(c => c.NgayHetHan)
                .Take(10)
                .Select(c => new {
                    nhanVien = c.NhanVien.HoTen,
                    maNV = c.NhanVien.MaNhanVien,
                    soCCHN = c.SoChungChi,
                    ngayHetHan = c.NgayHetHan
                })
                .ToListAsync();

            return Ok(alerts);
        }
    }
}
