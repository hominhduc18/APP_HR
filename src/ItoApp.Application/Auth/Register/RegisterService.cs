using ItoApp.Application.Abstractions;
using ItoApp.Application.Auth.Dto;
using ITOApp.Application.Common;

namespace ItoApp.Application.Auth.Register;

using System.Security.Cryptography;
using System.Text;




public class RegisterService
{
    private readonly IUserRepository _users;
    private readonly IPatientRepository _patients;
    private readonly IOtpRepository _otps;
    private readonly ISmsSender _sms;
    private readonly ITokenService _tokens;

    public RegisterService(IUserRepository users, IPatientRepository patients, IOtpRepository otps, ISmsSender sms, ITokenService tokens)
    {
        _users = users; _patients = patients; _otps = otps; _sms = sms; _tokens = tokens;
    }

 
    public async Task<BaseResponse<object>> SendOtpAsync(RegisterSendOtpRequest req)
    {
        var phone = (req.Phone ?? "").Trim();
        if (phone.Length < 9) return BaseResponse<object>.Error("Số điện thoại không hợp lệ");

        if (await _users.ExistsByPhoneAsync(phone))
            return BaseResponse<object>.Error("Số điện thoại đã được đăng ký");

        var otp = RandomNumberGenerator.GetInt32(0, 1000000).ToString("D6");
        var otpHash = Sha256(otp);
        var expiresAt = DateTime.UtcNow.AddMinutes(3);

        await _otps.SaveAsync(phone, "REGISTER", otpHash, expiresAt);
        await _sms.SendOtpAsync(phone, otp);

        return BaseResponse<object>.Success(new { expiresIn = 180 }, "Đã gửi OTP đăng ký");
    }

    // Step 2: verify OTP + tạo user/patient
    public async Task<BaseResponse<RegisterResponse>> VerifyOtpAsync(RegisterVerifyOtpRequest req)
    {
        var phone = (req.Phone ?? "").Trim();
        var code = (req.Otp ?? "").Trim();

        var record = await _otps.GetLatestAsync(phone, "REGISTER");
        if (record == null) return BaseResponse<RegisterResponse>.Error("OTP không tồn tại");
        if (record.UsedAt != null) return BaseResponse<RegisterResponse>.Error("OTP đã được sử dụng");
        if (DateTime.UtcNow > record.ExpiresAt) return BaseResponse<RegisterResponse>.Error("OTP đã hết hạn");

        if (Sha256(code) != record.OtpHash)
        {
            await _otps.IncreaseAttemptAsync(record.OtpId);
            return BaseResponse<RegisterResponse>.Error("OTP không đúng");
        }

        await _otps.MarkUsedAsync(record.OtpId);

        var userId = await _users.CreatePatientUserAsync(phone);
        var patientId = await _patients.CreateAsync(userId);

        var (access, refresh) = _tokens.CreateTokens(userId, "PATIENT");

        return BaseResponse<RegisterResponse>.Success(
            new RegisterResponse { UserId = userId, PatientId = patientId, AccessToken = access, RefreshToken = refresh },
            "Đăng ký thành công",
            new { traceId = Guid.NewGuid().ToString() }
        );
    }

    private static string Sha256(string input)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes);
    }
}
