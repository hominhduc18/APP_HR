using ItoApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStaff()
        {
            var staff = await _context.NhanViens
                .Include(n => n.ChiNhanh)
                .Include(n => n.KhoaPhong)
                .Include(n => n.NhomNgheNghiep)
                .Include(n => n.ChucVu)
                .Select(n => new {
                    n.Id,
                    n.MaNhanVien,
                    n.HoTen,
                    n.NgaySinh,
                    n.GioiTinh,
                    n.SoDienThoai,
                    TrangThai = n.TrangThai,
                    ChiNhanh = n.ChiNhanh.TenChiNhanh,
                    KhoaPhong = n.KhoaPhong.TenKhoaPhong,
                    NhomNgheNghiep = n.NhomNgheNghiep.TenNhom,
                    ChucVu = n.ChucVu.TenChucVu
                }).ToListAsync();
            return Ok(staff);
        }
    }
}
