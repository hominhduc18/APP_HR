using ItoApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/dich-vu")]
    public class DichVuController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DichVuController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 1. Lấy danh sách Loại Dịch Vụ
        /// </summary>
        [HttpGet("danh-sach-loai")]
        public async Task<IActionResult> GetLoaiDichVu()
        {
            var loais = await _context.Dm_LoaiDichVus
                .Where(x => x.TamNgung == 0) // Chỉ lấy các loại đang hoạt động
                .OrderBy(x => x.Idx)
                .Select(x => new 
                {
                    x.LoaiDichVuId,
                    x.MaLoaiDichVu,
                    x.TenLoaiDichVu
                })
                .ToListAsync();

            return Ok(new { success = true, data = loais });
        }

        /// <summary>
        /// 2. Lấy danh sách Dịch Vụ chi tiết lọc theo Loại Dịch Vụ
        /// (Vì Dịch vụ liên kết với Loại thông qua Nhóm Dịch Vụ)
        /// </summary>
        [HttpGet("chi-tiet-theo-loai/{loaiDichVuId}")]
        public async Task<IActionResult> GetDichVuChiTiet(int loaiDichVuId)
        {
            var dichVus = await _context.Dm_DichVus
                .Include(dv => dv.NhomDichVu)
                .Where(dv => dv.NhomDichVu != null && dv.NhomDichVu.LoaiDichVuId == loaiDichVuId && dv.TamNgung == 0)
                .OrderBy(dv => dv.Idx)
                .Select(dv => new 
                {
                    dv.DichVuId,
                    dv.MaDichVu,
                    dv.TenDichVu,
                    dv.DonGia,
                    TenNhomDichVu = dv.NhomDichVu!.TenNhomDichVu // Lấy thêm tên nhóm
                })
                .ToListAsync();

            return Ok(new { success = true, data = dichVus });
        }

        /// <summary>
        /// 3. Lấy tất cả Dịch vụ (JOIN TỔNG với Nhóm và Loại như câu SQL của bạn)
        /// </summary>
        [HttpGet("join-tong")]
        public async Task<IActionResult> GetJoinTongDichVu()
        {
            var result = await _context.Dm_DichVus
                .Include(dv => dv.NhomDichVu)
                .ThenInclude(n => n!.LoaiDichVu)
                .Where(dv => dv.TamNgung == 0)
                .Select(dv => new 
                {
                    dichVuId = dv.DichVuId,
                    maDichVu = dv.MaDichVu,
                    tenDichVu = dv.TenDichVu,
                    donGia = dv.DonGia,
                    nhomDichVuId = dv.NhomDichVuId,
                    tenNhom = dv.NhomDichVu!.TenNhomDichVu,
                    loaiDichVuId = dv.NhomDichVu.LoaiDichVuId,
                    tenLoaiDichVu = dv.NhomDichVu.LoaiDichVu!.TenLoaiDichVu
                })
                .ToListAsync();

            return Ok(new { success = true, total = result.Count, data = result });
        }
    }
}
