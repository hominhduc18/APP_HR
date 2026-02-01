using ItoApp.Application.Staff.Dto;
using ItoApp.Domain.Entities;
using ItoApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/nhan-vien")]
    public class StaffController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStaff(
            [FromQuery] string? search,
            [FromQuery] Guid? branchId,
            [FromQuery] Guid? deptId,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = _context.NhanViens
                .Include(n => n.ChiNhanh)
                .Include(n => n.KhoaPhong)
                .Include(n => n.NhomNgheNghiep)
                .Include(n => n.ChucVu)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(n => n.HoTen.Contains(search) || n.MaNhanVien.Contains(search));
            }

            if (branchId.HasValue)
            {
                query = query.Where(n => n.ChiNhanhId == branchId.Value);
            }

            if (deptId.HasValue)
            {
                query = query.Where(n => n.KhoaPhongId == deptId.Value);
            }

            var total = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(n => new StaffDto
                {
                    Id = n.Id,
                    MaNhanVien = n.MaNhanVien,
                    HoTen = n.HoTen,
                    NgaySinh = n.NgaySinh,
                    GioiTinh = n.GioiTinh,
                    SoDienThoai = n.SoDienThoai,
                    Email = n.Email,
                    DiaChi = n.DiaChi,
                    NgayVaoLam = n.NgayVaoLam,
                    TrangThai = n.TrangThai,
                    ChiNhanhId = n.ChiNhanhId,
                    TenChiNhanh = n.ChiNhanh.TenChiNhanh,
                    KhoaPhongId = n.KhoaPhongId,
                    TenKhoaPhong = n.KhoaPhong.TenKhoaPhong,
                    NhomNgheNghiepId = n.NhomNgheNghiepId,
                    TenNhomNgheNghiep = n.NhomNgheNghiep.TenNhom,
                    ChucVuId = n.ChucVuId,
                    TenChucVu = n.ChucVu.TenChucVu
                }).ToListAsync();

            return Ok(new { total, items, page, pageSize });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStaffById(Guid id)
        {
            var n = await _context.NhanViens
                .Include(n => n.ChiNhanh)
                .Include(n => n.KhoaPhong)
                .Include(n => n.NhomNgheNghiep)
                .Include(n => n.ChucVu)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (n == null) return NotFound();

            var dto = new StaffDto
            {
                Id = n.Id,
                MaNhanVien = n.MaNhanVien,
                HoTen = n.HoTen,
                NgaySinh = n.NgaySinh,
                GioiTinh = n.GioiTinh,
                SoDienThoai = n.SoDienThoai,
                Email = n.Email,
                DiaChi = n.DiaChi,
                NgayVaoLam = n.NgayVaoLam,
                TrangThai = n.TrangThai,
                ChiNhanhId = n.ChiNhanhId,
                TenChiNhanh = n.ChiNhanh.TenChiNhanh,
                KhoaPhongId = n.KhoaPhongId,
                TenKhoaPhong = n.KhoaPhong.TenKhoaPhong,
                NhomNgheNghiepId = n.NhomNgheNghiepId,
                TenNhomNgheNghiep = n.NhomNgheNghiep.TenNhom,
                ChucVuId = n.ChucVuId,
                TenChucVu = n.ChucVu.TenChucVu
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody] CreateStaffRequest req)
        {
            var nv = new NhanVien
            {
                MaNhanVien = req.MaNhanVien,
                HoTen = req.HoTen,
                NgaySinh = req.NgaySinh,
                GioiTinh = req.GioiTinh,
                SoDienThoai = req.SoDienThoai,
                Email = req.Email,
                DiaChi = req.DiaChi,
                NgayVaoLam = req.NgayVaoLam,
                TrangThai = "Active",
                ChiNhanhId = req.ChiNhanhId,
                KhoaPhongId = req.KhoaPhongId,
                NhomNgheNghiepId = req.NhomNgheNghiepId,
                ChucVuId = req.ChucVuId
            };

            _context.NhanViens.Add(nv);
            
            _context.LichSuChinhSuas.Add(new LichSuChinhSua {
                NhanVienId = nv.Id,
                ThaoTac = "Thêm mới",
                NoiDung = $"Thêm mới nhân viên {nv.HoTen} ({nv.MaNhanVien})",
                NguoiThucHien = "Admin" // Placeholder
            });

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaffById), new { id = nv.Id }, nv.Id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStaff(Guid id, [FromBody] UpdateStaffRequest req)
        {
            var nv = await _context.NhanViens.FindAsync(id);
            if (nv == null) return NotFound();

            nv.MaNhanVien = req.MaNhanVien;
            nv.HoTen = req.HoTen;
            nv.NgaySinh = req.NgaySinh;
            nv.GioiTinh = req.GioiTinh;
            nv.SoDienThoai = req.SoDienThoai;
            nv.Email = req.Email;
            nv.DiaChi = req.DiaChi;
            nv.NgayVaoLam = req.NgayVaoLam;
            nv.ChiNhanhId = req.ChiNhanhId;
            nv.KhoaPhongId = req.KhoaPhongId;
            nv.NhomNgheNghiepId = req.NhomNgheNghiepId;
            nv.ChucVuId = req.ChucVuId;

            _context.LichSuChinhSuas.Add(new LichSuChinhSua {
                NhanVienId = nv.Id,
                ThaoTac = "Cập nhật",
                NoiDung = $"Cập nhật hồ sơ nhân viên {nv.HoTen}",
                NguoiThucHien = "Admin"
            });

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStaff(Guid id)
        {
            var nv = await _context.NhanViens.FindAsync(id);
            if (nv == null) return NotFound();

            _context.LichSuChinhSuas.Add(new LichSuChinhSua {
                ThaoTac = "Xóa",
                NoiDung = $"Xóa hồ sơ nhân viên {nv.HoTen} ({nv.MaNhanVien})",
                NguoiThucHien = "Admin"
            });

            _context.NhanViens.Remove(nv);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id:guid}/trang-thai")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateStaffStatusRequest req)
        {
            var nv = await _context.NhanViens.FindAsync(id);
            if (nv == null) return NotFound();

            var oldStatus = nv.TrangThai;
            nv.TrangThai = req.TrangThai;

            _context.LichSuChinhSuas.Add(new LichSuChinhSua {
                NhanVienId = nv.Id,
                ThaoTac = "Đổi trạng thái",
                NoiDung = $"Đổi trạng thái từ {oldStatus} sang {req.TrangThai}",
                NguoiThucHien = "Admin"
            });

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{id:guid}/dieu-chuyen")]
        public async Task<IActionResult> Transfer(Guid id, [FromBody] TransferStaffRequest req)
        {
            var nv = await _context.NhanViens.FindAsync(id);
            if (nv == null) return NotFound();

            var oldDeptId = nv.KhoaPhongId;
            nv.KhoaPhongId = req.NewKhoaPhongId;

            _context.LichSuChinhSuas.Add(new LichSuChinhSua {
                NhanVienId = nv.Id,
                ThaoTac = "Điều chuyển",
                NoiDung = $"Điều chuyển khoa phòng (Effective: {req.EffectiveDate:dd/MM/yyyy}). Lý do: {req.Reason}",
                NguoiThucHien = "Admin"
            });

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
