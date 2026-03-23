using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ItoApp.Application.Abstractions;
using ItoApp.Application.Auth.Dto;
using ItoApp.Application.Common;
using ItoApp.Domain.Entities;
using ItoApp.Shared.Enums;
using ItoApp.Domain.Interfaces;
using ItoApp.Shared.ValueObjects;

namespace ItoApp.Application.Auth.Register;

public class RegisterService
{
    private readonly IUserRepository _users;
    private readonly IPatientRepository _patients;
    private readonly IOtpRepository _otps;
    private readonly ISmsSender _sms;
    private readonly ITokenService _tokens;

    public RegisterService(
        IUserRepository users, 
        IPatientRepository patients, 
        IOtpRepository otps, 
        ISmsSender sms,
        ITokenService tokens)
    {
        _users = users; 
        _patients = patients; 
        _otps = otps; 
        _sms = sms; 
        _tokens = tokens;
    }

    public async Task<BaseResponse<object>> SendOtpAsync(RegisterSendOtpRequest req)
    {
        var phoneValue = (req.Phone ?? "").Trim();
        if (string.IsNullOrWhiteSpace(phoneValue)) 
            return BaseResponse<object>.ThatBai("Số điện thoại không được để trống");

        try 
        {
            var phoneNumber = PhoneNumber.Create(phoneValue);
            var existingUser = await _users.GetByPhoneAsync(phoneNumber.Value);
            if (existingUser != null)
                return BaseResponse<object>.ThatBai("Số điện thoại đã được đăng ký");

            var otpCode = new OtpCode(phoneNumber.Value, OtpType.Register, OtpChannel.SMS);
            
            await _otps.AddAsync(otpCode);
            await _sms.SendOtpAsync(phoneNumber.Value, otpCode.Code);

            return BaseResponse<object>.ThanhCong(new { expiresIn = 300 }, "Đã gửi OTP đăng ký");
        }
        catch (ArgumentException ex)
        {
            return BaseResponse<object>.ThatBai(ex.Message);
        }
    }

    public async Task<BaseResponse<RegisterResponse>> VerifyOtpAsync(RegisterVerifyOtpRequest req)
    {
        var phoneValue = (req.Phone ?? "").Trim();
        var code = (req.Otp ?? "").Trim();

        try 
        {
            var phoneNumber = PhoneNumber.Create(phoneValue);
            var otpRecord = await _otps.GetLatestActiveOtpAsync(phoneNumber.Value, OtpType.Register);

            if (otpRecord == null) 
                return BaseResponse<RegisterResponse>.ThatBai("OTP không tồn tại hoặc đã hết hạn");

            if (!otpRecord.Verify(code))
            {
                await _otps.UpdateAsync(otpRecord);
                return BaseResponse<RegisterResponse>.ThatBai("Mã OTP không đúng");
            }

            await _otps.UpdateAsync(otpRecord);

            // Create user
            // In a real app, we should hash the password
            var user = new User(phoneNumber, req.Password, req.FullName);
            await _users.AddAsync(user);

            // Create patient
            var patient = new Patient(user.Id, req.FullName);
            await _patients.AddAsync(patient);

            var (access, refresh) = _tokens.CreateTokens(user.Id.ToString(), "PATIENT");

            return BaseResponse<RegisterResponse>.ThanhCong(
                new RegisterResponse { 
                    UserId = user.Id, 
                    PatientId = patient.Id, 
                    AccessToken = access, 
                    RefreshToken = refresh 
                },
                "Đăng ký thành công"
            );
        }
        catch (Exception ex)
        {
            return BaseResponse<RegisterResponse>.ThatBai(ex.Message);
        }
    }
}

