using ItoApp.Domain.Entities;
using ItoApp.Domain.Enums;

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

    
        Task SaveAsync(string identifier, string type, string otpHash, DateTime expiresAt);
        Task<OtpCode?> GetLatestAsync(string identifier, string type);
        Task MarkUsedAsync(Guid otpId);
        Task IncreaseAttemptAsync(Guid otpId);
    }
}