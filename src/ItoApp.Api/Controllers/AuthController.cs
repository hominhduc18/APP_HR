using System.Security.Cryptography;
using ItoApp.Application.Abstractions;
using ItoApp.Application.Auth.Dto;
using ItoApp.Domain.Entities;
using ItoApp.Domain.Enums;
using ItoApp.Domain.Interfaces;
using ItoApp.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace ItoApp.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepo;
    private readonly IOtpRepository _otpRepo;
    private readonly ISmsSender _sms;

    public AuthController(
        ITokenService tokenService,
        IUserRepository userRepo,
        IOtpRepository otpRepo,
        ISmsSender sms)
    {
        _tokenService = tokenService;
        _userRepo = userRepo;
        _otpRepo = otpRepo;
        _sms = sms;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest req)
    {
        try 
        {
            var phoneNumber = PhoneNumber.Create(req.Phone);
            var user = await _userRepo.GetByPhoneAsync(phoneNumber.Value);
            
            if (user == null)
                return BadRequest("Số điện thoại chưa đăng ký.");

            var otpCode = new OtpCode(phoneNumber.Value, OtpType.Login, OtpChannel.SMS);
            await _otpRepo.AddAsync(otpCode);
            await _sms.SendOtpAsync(phoneNumber.Value, otpCode.Code);

            return Ok(new { message = "OTP đã gửi" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("verify")]
    public async Task<IActionResult> Verify([FromBody] VerifyLoginRequest req)
    {
        try 
        {
            var phoneNumber = PhoneNumber.Create(req.Phone);
            var otpRecord = await _otpRepo.GetLatestActiveOtpAsync(phoneNumber.Value, OtpType.Login);
            
            if (otpRecord == null || !otpRecord.Verify(req.Otp))
            {
                if (otpRecord != null) await _otpRepo.UpdateAsync(otpRecord);
                return BadRequest("OTP không hợp lệ.");
            }

            await _otpRepo.UpdateAsync(otpRecord);

            var user = await _userRepo.GetByPhoneAsync(phoneNumber.Value);
            if (user == null) return NotFound();

            var (access, refresh) = _tokenService.CreateTokens(user.Id, "PATIENT");
            return Ok(new { access, refresh });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("refresh")]
    public IActionResult Refresh([FromBody] RefreshRequest req)
    {
        var payload = _tokenService.ValidateRefreshToken(req.RefreshToken);
        if (payload == null) return Unauthorized();

        var (newAccess, newRefresh) = _tokenService.CreateTokens(payload.UserId, payload.Role);
        return Ok(new { access = newAccess, refresh = newRefresh });
    }
}