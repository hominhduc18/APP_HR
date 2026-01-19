using ItoApp.Domain.Entities;

namespace ItoApp.Domain.Interfaces
{
    public interface IOtpRepository
    {
        Task<OtpCode?> GetLatestActiveOtpAsync(string identifier, OtpType type);
        Task<OtpCode?> GetOtpByCodeAsync(string identifier, string code, OtpType type);
        Task AddAsync(OtpCode otp);
        Task UpdateAsync(OtpCode otp);
        Task<int> GetOtpCountLastHourAsync(string identifier);
        Task<bool> IsIdentifierBlockedAsync(string identifier);
    }
}