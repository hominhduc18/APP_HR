using ItoApp.Domain.Entities;
using ItoApp.Domain.Enums;
using ItoApp.Domain.Interfaces;
using ItoApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
                .Where(o => o.Identifier == identifier && o.Type == type && !o.IsUsed && o.ExpiresAt > DateTime.UtcNow)
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task<OtpCode?> GetOtpByCodeAsync(string identifier, string code, OtpType type)
        {
            return await _context.OtpCodes
                .FirstOrDefaultAsync(o => o.Identifier == identifier && o.Code == code && o.Type == type);
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
            var anHourAgo = DateTime.UtcNow.AddHours(-1);
            return await _context.OtpCodes
                .CountAsync(o => o.Identifier == identifier && o.CreatedAt > anHourAgo);
        }

        public async Task<bool> IsIdentifierBlockedAsync(string identifier)
        {
            // Placeholder for blocking logic
            return await Task.FromResult(false);
        }

        // Methods for RegisterService compatibility
        public async Task SaveAsync(string identifier, string type, string otpHash, DateTime expiresAt)
        {
            var otpType = Enum.TryParse<OtpType>(type, true, out var result) ? result : OtpType.Login;
            var otp = new OtpCode(identifier, otpHash, otpType, OtpChannel.SMS, expiresAt);
            await AddAsync(otp);
        }

        public async Task<OtpCode?> GetLatestAsync(string identifier, string type)
        {
            return await _context.OtpCodes
                .Where(o => o.Identifier == identifier)
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task MarkUsedAsync(int otpId)
        {
            var otp = await _context.OtpCodes.FindAsync(otpId);
            if (otp != null)
            {
                // otp.MarkAsUsed(); // Assuming this method exists or just set prop
                await _context.SaveChangesAsync();
            }
        }

        public async Task IncreaseAttemptAsync(int otpId)
        {
            var otp = await _context.OtpCodes.FindAsync(otpId);
            if (otp != null)
            {
                // Logic to increase attempt
                await _context.SaveChangesAsync();
            }
        }
    }
}