using ItoApp.Application.Abstractions;
using ItoApp.Domain;
using ItoApp.Domain.Entities;
using ItoApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using IOtpRepository = ItoApp.Domain.Interfaces.IOtpRepository;

namespace ItoApp.Infrastructure.Repositories
{



    public class OtpRepository : IOtpRepository
    {
        private readonly ApplicationDbContext _context;

        public OtpRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OtpCode?> GetLatestActiveOtpAsync(string identifier, OtpType type)
        {
            return await _context.OtpCodes
                .Where(o => o.Identifier == identifier.ToLower() &&
                            o.Type == type &&
                            !o.IsUsed &&
                            o.ExpiresAt > DateTime.UtcNow)
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task<OtpCode?> GetOtpByCodeAsync(string identifier, string code, OtpType type)
        {
            return await _context.OtpCodes
                .FirstOrDefaultAsync(o =>
                    o.Identifier == identifier.ToLower() &&
                    o.Code == code &&
                    o.Type == type);
        }

        public async Task AddAsync(OtpCode otp)
        {
            await _context.OtpCodes.AddAsync(otp);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OtpCode otp)
        {
            _context.OtpCodes.Update(otp);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetOtpCountLastHourAsync(string identifier)
        {
            var oneHourAgo = DateTime.UtcNow.AddHours(-1);

            return await _context.OtpCodes
                .Where(o => o.Identifier == identifier.ToLower() &&
                            o.CreatedAt > oneHourAgo)
                .CountAsync();
        }

        public async Task<bool> IsIdentifierBlockedAsync(string identifier)
        {
            // Kiểm tra nếu có quá nhiều OTP sai trong 15 phút
            var fifteenMinutesAgo = DateTime.UtcNow.AddMinutes(-15);

            var failedAttempts = await _context.OtpCodes
                .Where(o => o.Identifier == identifier.ToLower() &&
                            o.CreatedAt > fifteenMinutesAgo &&
                            o.AttemptCount >= 3)
                .CountAsync();

            return failedAttempts >= 3;
        }
    }
}