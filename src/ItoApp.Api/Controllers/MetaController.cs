using ItoApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/danh-muc")]
    public class MetaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("chi-nhanh")]
        public async Task<IActionResult> GetBranches()
        {
            var branches = await _context.ChiNhanhs
                .Select(b => new {
                    b.Id,
                    b.MaChiNhanh,
                    b.TenChiNhanh,
                    b.DiaChi,
                    b.SoDienThoai,
                    b.MaSoThue
                }).ToListAsync();
            return Ok(branches);
        }

        [HttpGet("khoa-phong")]
        public async Task<IActionResult> GetDepartments(int? branchId)
        {
            var query = _context.KhoaPhongs.AsQueryable();
            if (branchId.HasValue)
            {
                query = query.Where(d => d.ChiNhanhId == branchId.Value);
            }

            var depts = await query
                .Select(d => new {
                    d.Id,
                    d.TenKhoaPhong,
                    d.ChiNhanhId
                }).ToListAsync();
            return Ok(depts);
        }

        [HttpGet("nhom-nghe-nghiep")]
        public async Task<IActionResult> GetJobGroups()
        {
            var groups = await _context.NhomNgheNghieps
                .Select(g => new {
                    g.Id,
                    g.TenNhom,
                    g.MaNhom
                }).ToListAsync();
            return Ok(groups);
        }

        [HttpGet("chuc-vu")]
        public async Task<IActionResult> GetPositions()
        {
            var positions = await _context.ChucVus
                .Select(p => new {
                    p.Id,
                    p.TenChucVu
                }).ToListAsync();
            return Ok(positions);
        }
    }
}
