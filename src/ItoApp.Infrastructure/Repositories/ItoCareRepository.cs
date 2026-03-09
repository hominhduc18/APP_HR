using ItoApp.Application.Interfaces;
using ItoApp.Domain.Entities.ItoCare;
using ItoApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Infrastructure.Repositories
{
    public class ItoCareRepository : IItoCareRepository
    {
        private readonly ApplicationDbContext _context;

        public ItoCareRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiNhanh>> LayTatCaChiNhanh()
        {
            return await _context.ItoCare_ChiNhanhs
                .Where(c => c.LaHoatDong)
                .OrderBy(c => c.ThuTuHienThi)
                .ToListAsync();
        }

        public async Task<ChiNhanh?> LayChiNhanhTheoId(int id)
        {
            return await _context.ItoCare_ChiNhanhs
                .FirstOrDefaultAsync(c => c.ChiNhanhId == id);
        }

        public async Task<NguoiDung?> LayNguoiDungTheoSDT(string sdt)
        {
            return await _context.ItoCare_NguoiDungs
                .FirstOrDefaultAsync(u => u.SoDienThoai == sdt);
        }

        public async Task<NguoiDung?> LayNguoiDungTheoId(int id)
        {
            return await _context.ItoCare_NguoiDungs
                .FirstOrDefaultAsync(u => u.NguoiDungId == id);
        }

        public async Task ThemNguoiDung(NguoiDung user)
        {
            await _context.ItoCare_NguoiDungs.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task CapNhatNguoiDung(NguoiDung user)
        {
            _context.ItoCare_NguoiDungs.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HoSoBenhNhan>> LayDanhSachHoSoTheoNguoiDung(int nguoiDungId)
        {
            return await _context.ItoCare_HoSoBenhNhans
                .Where(h => h.NguoiDungId == nguoiDungId)
                .ToListAsync();
        }

        public async Task<HoSoBenhNhan?> LayHoSoTheoId(int id)
        {
            return await _context.ItoCare_HoSoBenhNhans
                .FirstOrDefaultAsync(h => h.HoSoId == id);
        }

        public async Task<HoSoBenhNhan?> TimHoSo(string sdt, string ma)
        {
            return await _context.ItoCare_HoSoBenhNhans
                .FirstOrDefaultAsync(h => h.SoDienThoai == sdt || h.MaBenhNhan == ma);
        }

        public async Task ThemHoSo(HoSoBenhNhan hoSo)
        {
            await _context.ItoCare_HoSoBenhNhans.AddAsync(hoSo);
            await _context.SaveChangesAsync();
        }

        public async Task CapNhatHoSo(HoSoBenhNhan hoSo)
        {
            _context.ItoCare_HoSoBenhNhans.Update(hoSo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<KhoaPhong>> LayDanhSachKhoaTheoChiNhanh(int chiNhanhId)
        {
            return await _context.ItoCare_KhoaPhongs
                .Where(k => k.ChiNhanhId == chiNhanhId && k.LaHoatDong)
                .ToListAsync();
        }

        public async Task<IEnumerable<BacSi>> LayDanhSachBacSi(int chiNhanhId, int khoaId)
        {
            return await _context.ItoCare_BacSiChiNhanhs
                .Include(bc => bc.BacSi)
                .Where(bc => bc.ChiNhanhId == chiNhanhId && bc.BacSi != null && bc.BacSi.KhoaId == khoaId)
                .Select(bc => bc.BacSi!)
                .ToListAsync();
        }

        public async Task<IEnumerable<DateTime>> LayLichTrongBacSi(int bacSiId, DateTime tuNgay)
        {
            return await _context.ItoCare_LichLamViecs
                .Where(l => l.BacSiId == bacSiId && l.NgayLamViec >= tuNgay.Date)
                .Select(l => l.NgayLamViec)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<KhungGio>> LayDanhSachKhungGio(int bacSiId, DateTime ngay)
        {
            return await _context.ItoCare_KhungGios
                .Include(k => k.LichLamViec)
                .Where(k => k.LichLamViec != null && k.LichLamViec.BacSiId == bacSiId && k.LichLamViec.NgayLamViec.Date == ngay.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<GoiKham>> LayDanhSachGoiKham()
        {
            return await _context.ItoCare_GoiKhams
                .Where(g => g.LaHoatDong)
                .ToListAsync();
        }

        public async Task ThemLichHen(LichHen lichHen)
        {
            await _context.ItoCare_LichHens.AddAsync(lichHen);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LichHen>> LayDanhSachLichHenTheoNguoiDung(int nguoiDungId)
        {
            return await _context.ItoCare_LichHens
                .Include(l => l.BacSi)
                .Include(l => l.ChiNhanh)
                .Include(l => l.KhungGio)
                .Include(l => l.HoSoBenhNhan)
                .Where(l => l.HoSoBenhNhan != null && l.HoSoBenhNhan.NguoiDungId == nguoiDungId)
                .OrderByDescending(l => l.NgayHen)
                .ToListAsync();
        }

        public async Task<LichHen?> LayLichHenTheoId(int id)
        {
            return await _context.ItoCare_LichHens
                .Include(l => l.BacSi)
                .Include(l => l.ChiNhanh)
                .Include(l => l.KhungGio)
                .Include(l => l.HoSoBenhNhan)
                .FirstOrDefaultAsync(l => l.LichHenId == id);
        }

        public async Task CapNhatLichHen(LichHen lichHen)
        {
            _context.ItoCare_LichHens.Update(lichHen);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<KetQuaCls>> LayDanhSachKetQuaTheoHoSo(int hoSoId)
        {
            return await _context.ItoCare_KetQuaClss
                .Include(r => r.BacSi)
                .Where(r => r.HoSoId == hoSoId)
                .OrderByDescending(r => r.NgayThucHien)
                .ToListAsync();
        }

        public async Task<KetQuaCls?> LayKetQuaTheoId(int id)
        {
            return await _context.ItoCare_KetQuaClss
                .Include(r => r.BacSi)
                .FirstOrDefaultAsync(r => r.KetQuaId == id);
        }
    }
}
