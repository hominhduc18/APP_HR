using ItoApp.Domain.Entities;
using ItoApp.Domain.Enums;
using ItoApp.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace ItoApp.Infrastructure.Repositories;

// STRUCTURAL PATTERN: Decorator
// Giúp thêm chức năng (Logging) vào Repository mà không cần sửa code cũ của Repository đó.
public class LoggingOtpRepositoryDecorator : IOtpRepository
{
    private readonly IOtpRepository _innerRepository;
    private readonly ILogger<LoggingOtpRepositoryDecorator> _logger;

    public LoggingOtpRepositoryDecorator(IOtpRepository innerRepository, ILogger<LoggingOtpRepositoryDecorator> logger)
    {
        _innerRepository = innerRepository;
        _logger = logger;
    }

    public async Task AddAsync(OtpCode otp)
    {
        _logger.LogInformation("--- [DECORATOR] Adding OTP for {Identifier}", otp.Identifier);
        await _innerRepository.AddAsync(otp);
    }

    public Task<OtpCode?> GetLatestActiveOtpAsync(string identifier, OtpType type) => _innerRepository.GetLatestActiveOtpAsync(identifier, type);
    public Task<OtpCode?> GetOtpByCodeAsync(string identifier, string code, OtpType type) => _innerRepository.GetOtpByCodeAsync(identifier, code, type);
    public Task UpdateAsync(OtpCode otp) => _innerRepository.UpdateAsync(otp);
    public Task<int> GetOtpCountLastHourAsync(string identifier) => _innerRepository.GetOtpCountLastHourAsync(identifier);
    public Task<bool> IsIdentifierBlockedAsync(string identifier) => _innerRepository.IsIdentifierBlockedAsync(identifier);
    
    public async Task SaveAsync(string identifier, string type, string otpHash, DateTime expiresAt)
    {
        _logger.LogInformation("--- [DECORATOR] Saving OTP for {Identifier} with type {Type}", identifier, type);
        await _innerRepository.SaveAsync(identifier, type, otpHash, expiresAt);
    }

    public Task<OtpCode?> GetLatestAsync(string identifier, string type) => _innerRepository.GetLatestAsync(identifier, type);
    public Task MarkUsedAsync(int otpId) => _innerRepository.MarkUsedAsync(otpId);
    public Task IncreaseAttemptAsync(int otpId) => _innerRepository.IncreaseAttemptAsync(otpId);
}
