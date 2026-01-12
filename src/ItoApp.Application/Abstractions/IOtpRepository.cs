namespace ItoApp.Application.Abstractions;



public record OtpRecord(
    long OtpId,
    string OtpHash,
    DateTime ExpiresAt,
    DateTime? UsedAt,
    int AttemptCount
);

public interface IOtpRepository
{
    Task SaveAsync(string phone, string purpose, string otpHash, DateTime expiresAt);
    Task<OtpRecord?> GetLatestAsync(string phone, string purpose);
    Task MarkUsedAsync(long otpId);
    Task IncreaseAttemptAsync(long otpId);
}
