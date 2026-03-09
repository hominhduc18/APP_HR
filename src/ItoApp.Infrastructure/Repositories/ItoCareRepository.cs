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

        public async Task<IEnumerable<ChiNhanh>> GetAllChiNhanhAsync()
        {
            return await _context.ItoCare_ChiNhanhs
                .Where(c => c.LaHoatDong)
                .OrderBy(c => c.ThuTuHienThi)
                .ToListAsync();
        }

        public async Task<ChiNhanh?> GetChiNhanhByIdAsync(int id)
        {
            return await _context.ItoCare_ChiNhanhs
                .FirstOrDefaultAsync(c => c.ChiNhanhId == id);
        }

        public async Task<IEnumerable<BacSi>> GetBacSisByChiNhanhAsync(int chiNhanhId)
        {
            return await _context.ItoCare_BacSiChiNhanhs
                .Where(bc => bc.ChiNhanhId == chiNhanhId)
                .Select(bc => bc.BacSi!)
                .ToListAsync();
        }
    }
}
