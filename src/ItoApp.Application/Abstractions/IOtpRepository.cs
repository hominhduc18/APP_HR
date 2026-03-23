// using System;
// using System.Threading.Tasks;
// using ItoApp.Domain.Entities;
// using ItoApp.Shared.Enums;

// namespace ItoApp.Domain.Interfaces
// {
//     public interface IOtpRepository
//     {
//         // Phương thức mới (đang dùng trong code)
//         Task<OtpCode?> GetLatestActiveOtpAsync(string identifier, OtpType type);
//         Task<OtpCode?> GetOtpByCodeAsync(string identifier, string code, OtpType type);
//         Task AddAsync(OtpCode otp);
//         Task UpdateAsync(OtpCode otp);
//         Task<int> GetOtpCountLastHourAsync(string identifier);
//         Task<bool> IsIdentifierBlockedAsync(string identifier);
        
//         // Phương thức cũ (để backward compatibility)
//         Task SaveAsync(string phone, string purpose, string otpHash, DateTime expiresAt);
//         Task<OtpRecord?> GetLatestAsync(string phone, string purpose);
//         Task MarkUsedAsync(long otpId);
//         Task IncreaseAttemptAsync(long otpId);
//     }
    
//     // Record cho backward compatibility
//     public record OtpRecord(
//         long OtpId,
//         string OtpHash,
//         DateTime ExpiresAt,
//         DateTime? UsedAt,
//         int AttemptCount
//     );
// }

