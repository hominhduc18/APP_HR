namespace ItoApp.Application;

public record OtpRecord(
    long OtpId,
    string OtpHash,
    DateTime ExpiresAt,
    DateTime? UsedAt,
    int AttemptCount
);
