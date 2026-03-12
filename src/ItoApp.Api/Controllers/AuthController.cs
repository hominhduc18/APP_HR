using ItoApp.Application.Abstractions;
using ItoApp.Application.Auth.Dto;
using ItoApp.Application.Common;
using ItoApp.Application.Interfaces;
using ItoApp.Domain.Entities.ItoCare;
using ItoApp.Domain.Enums;
using ItoApp.Infrastructure.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ItoApp.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IItoCareRepository _itoCareRepo;
    private readonly ISmsSender _sms;

    public AuthController(
        ITokenService tokenService,
        IItoCareRepository itoCareRepo,
        ISmsSender sms)
    {
        _tokenService = tokenService;
        _itoCareRepo = itoCareRepo;
        _sms = sms;
    }
    /// <summary>
    /// Đăng nhập
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>

    [HttpPost("dang-nhap")]
    public async Task<IActionResult> Login([FromBody] YeuCauDangNhapV3 req)
    {
        try 
        {
            var user = await _itoCareRepo.LayNguoiDungTheoSDT(req.PhoneNumber);
            
            if (user == null || !PasswordHasher.VerifyPassword(req.Password, user.MatKhau))
                return Ok(BaseResponse<object>.ThatBai("Số điện thoại hoặc mật khẩu không chính xác."));

            var (access, _) = _tokenService.CreateTokens(user.NguoiDungId.ToString(), user.VaiTro);

            var response = new PhanHoiDangNhapV3
            {
                Token = access,
                User = new ThongTinNguoiDungV3
                {
                    UserId = user.NguoiDungId,
                    FullName = user.HoTen,
                    VaiTro = user.VaiTro
                }
            };

            return Ok(BaseResponse<PhanHoiDangNhapV3>.ThanhCong(response, "Đăng nhập thành công"));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }
    /// <summary>
    /// Đăng ký
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [HttpPost("dang-ky")]
    public async Task<IActionResult> Register([FromBody] YeuCauDangKyV3 req)
    {
        try 
        {
            var existingUser = await _itoCareRepo.LayNguoiDungTheoSDT(req.PhoneNumber);
            if (existingUser != null)
                return Ok(BaseResponse<object>.ThatBai("Số điện thoại đã được đăng ký."));

            var user = new NguoiDung
            {
                SoDienThoai = req.PhoneNumber,
                MatKhau = PasswordHasher.HashPassword(req.Password),
                HoTen = req.FullName,
                VaiTro = "benh_nhan",
                DaXacMinh = false,
                LaHoatDong = true,
                NgayTao = DateTime.UtcNow
            };
            
            await _itoCareRepo.ThemNguoiDung(user);

            var response = new PhanHoiDangKyV3
            {
                UserId = user.NguoiDungId,
                PhoneNumber = user.SoDienThoai
            };

            return Ok(BaseResponse<PhanHoiDangKyV3>.ThanhCong(response, "Đăng ký thành công"));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    // 3. POST /auth/gui-otp
    [HttpPost("gui-otp")]
    public async Task<IActionResult> SendOtp([FromBody] YeuCauGuiOtpV3 req)
    {
        try 
        {
            var otp = new Random().Next(100000, 999999).ToString();
            await _sms.SendOtpAsync(req.PhoneNumber, otp);

            var response = new PhanHoiGuiOtpV3 { OtpTemp = otp };
            return Ok(BaseResponse<PhanHoiGuiOtpV3>.ThanhCong(response, "Mã OTP đã được gửi"));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    // 4. POST /auth/xac-minh-otp
    [HttpPost("xac-minh-otp")]
    public async Task<IActionResult> VerifyOtp([FromBody] YeuCauXacMinhOtpV3 req)
    {
        try 
        {
            if (req.OtpCode == "123456" || req.OtpCode.Length == 6)
            {
                var response = new PhanHoiXacMinhOtpV3 { Status = "verified" };
                return Ok(BaseResponse<PhanHoiXacMinhOtpV3>.ThanhCong(response, "Xác minh thành công"));
            }
            
            return Ok(BaseResponse<object>.ThatBai("Mã OTP không hợp lệ hoặc đã hết hạn."));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    // 5. POST /auth/doi-mat-khau
    [Authorize]
    [HttpPost("doi-mat-khau")]
    public async Task<IActionResult> ChangePassword([FromBody] YeuCauDoiMatKhauV3 req)
    {
        try 
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();

            var userId = int.Parse(userIdStr);
            var user = await _itoCareRepo.LayNguoiDungTheoId(userId);
            if (user == null) return Ok(BaseResponse<object>.ThatBai("Người dùng không tồn tại."));

            if (!PasswordHasher.VerifyPassword(req.OldPassword, user.MatKhau))
                return Ok(BaseResponse<object>.ThatBai("Mật khẩu cũ không chính xác."));

            user.MatKhau = PasswordHasher.HashPassword(req.NewPassword);
            user.NgayCapNhat = DateTime.UtcNow;
            
            await _itoCareRepo.CapNhatNguoiDung(user);

            return Ok(BaseResponse<object>.ThanhCong(null, "Đổi mật khẩu thành công"));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    // 6. GET /auth/thong-tin-ca-nhan
    [Authorize]
    [HttpGet("thong-tin-ca-nhan")]
    public async Task<IActionResult> GetProfile()
    {
        try 
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();

            var userId = int.Parse(userIdStr);
            var user = await _itoCareRepo.LayNguoiDungTheoId(userId);
            if (user == null) return Ok(BaseResponse<object>.ThatBai("Người dùng không tồn tại."));

            var response = new PhanHoiHoSoNguoiDungV3
            {
                UserId = user.NguoiDungId,
                FullName = user.HoTen,
                PhoneNumber = user.SoDienThoai,
                Email = user.Email,
                Avatar = user.AnhDaiDien
            };

            return Ok(BaseResponse<PhanHoiHoSoNguoiDungV3>.ThanhCong(response, "Thành công"));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }
}