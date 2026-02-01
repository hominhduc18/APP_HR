using System.Security.Cryptography;
using System.Text;
using ItoApp.Application.Auth.Dto;
using ItoApp.Domain.Entities;
using ItoApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/patient-auth")]
    public class PatientAuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientAuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            var hash = HashPassword(password);
            return hash == hashedPassword;
        }

        private string GenerateOtp()
        {
            return new Random().Next(100000, 999999).ToString();
        }

        [HttpPost("request-otp")]
        public async Task<IActionResult> RequestOtp([FromBody] PatientRequestOtpDto req)
        {
            // 1. Kiểm tra SĐT
            var existingAccount = await _context.TaiKhoanBenhNhans
                .FirstOrDefaultAsync(x => x.SoDienThoai == req.PhoneNumber);

            if (req.Type == "REGISTER" && existingAccount != null)
            {
                return BadRequest("Số điện thoại này đã được đăng ký.");
            }

            if (req.Type == "FORGOT_PASS" && existingAccount == null)
            {
                return BadRequest("Số điện thoại này chưa được đăng ký tài khoản.");
            }

            // 2. Tạo OTP
            var otp = GenerateOtp();
            var logOtp = new Log_OTP
            {
                SoDienThoai = req.PhoneNumber,
                MaOTP = otp,
                LoaiOTP = req.Type,
                HieuLucDen = DateTime.UtcNow.AddMinutes(1), // Hết hạn sau 1 phút
                DaSuDung = false,
                NgayTao = DateTime.UtcNow
            };

            _context.Log_OTPs.Add(logOtp);
            await _context.SaveChangesAsync();

            // 3. Trả về OTP (Môi trường Dev/Test)
            // Trong thực tế sẽ gọi SMS Gateway
            return Ok(new 
            { 
                success = true, 
                message = "Đã gửi mã OTP (giả lập)", 
                debug_otp = otp,
                expired_in = "1 minute"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PatientRegisterDto req)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Validate OTP
                var validOtp = await _context.Log_OTPs
                    .Where(x => x.SoDienThoai == req.PhoneNumber 
                           && x.MaOTP == req.Otp 
                           && x.LoaiOTP == "REGISTER"
                           && !x.DaSuDung)
                    .OrderByDescending(x => x.NgayTao)
                    .FirstOrDefaultAsync();

                if (validOtp == null)
                {
                    return BadRequest("Mã OTP không chính xác hoặc chưa yêu cầu.");
                }

                if (validOtp.HieuLucDen < DateTime.UtcNow)
                {
                    return BadRequest("Mã OTP đã hết hạn.");
                }

                // 2. Check tồn tại Account lần nữa
                if (await _context.TaiKhoanBenhNhans.AnyAsync(x => x.SoDienThoai == req.PhoneNumber))
                {
                    return BadRequest("Số điện thoại đã tồn tại.");
                }

                // 3. Tạo Bệnh Nhân
                var benhNhan = new BenhNhan
                {
                    TenBenhNhan = req.FullName ?? "Chưa cập nhật",
                    SoDienThoai = req.PhoneNumber,
                    NgayTao = DateTime.UtcNow
                };
                _context.BenhNhans.Add(benhNhan);
                await _context.SaveChangesAsync(); // Để lấy ID

                // 4. Tạo Tài Khoản
                var taiKhoan = new TaiKhoanBenhNhan
                {
                    BenhNhan_Id = benhNhan.BenhNhan_Id,
                    SoDienThoai = req.PhoneNumber,
                    MatKhau = HashPassword(req.Password),
                    TrangThai = true,
                    NgayTao = DateTime.UtcNow
                };
                _context.TaiKhoanBenhNhans.Add(taiKhoan);

                // 5. Đánh dấu OTP đã dùng
                validOtp.DaSuDung = true;
                
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { success = true, message = "Đăng ký thành công", benhNhanId = benhNhan.BenhNhan_Id });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "Lỗi hệ thống: " + ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] PatientLoginDto req)
        {
            var account = await _context.TaiKhoanBenhNhans
                .Include(x => x.BenhNhan)
                .FirstOrDefaultAsync(x => x.SoDienThoai == req.PhoneNumber);

            if (account == null)
            {
                return BadRequest("Dữ liệu đăng nhập không chính xác.");
            }

            if (!VerifyPassword(req.Password, account.MatKhau))
            {
                return BadRequest("Dữ liệu đăng nhập không chính xác.");
            }

            if (!account.TrangThai)
            {
                return BadRequest("Tài khoản đã bị khóa.");
            }

            // TODO: Generate JWT Token here
            // Hiện tại trả về Info
            return Ok(new 
            { 
                success = true,
                message = "Đăng nhập thành công",
                token = "fake-jwt-token-" + Guid.NewGuid(),
                user = new 
                {
                    account.Id,
                    account.BenhNhan_Id,
                    account.BenhNhan?.TenBenhNhan,
                    account.SoDienThoai
                }
            });
        }

        [HttpPost("reset-password")] // Quên mật khẩu
        public async Task<IActionResult> ResetPassword([FromBody] PatientResetPasswordDto req)
        {
             // 1. Validate OTP
            var validOtp = await _context.Log_OTPs
                .Where(x => x.SoDienThoai == req.PhoneNumber 
                       && x.MaOTP == req.Otp 
                       && x.LoaiOTP == "FORGOT_PASS"
                       && !x.DaSuDung)
                .OrderByDescending(x => x.NgayTao)
                .FirstOrDefaultAsync();

            if (validOtp == null) return BadRequest("Mã OTP không đúng hoặc chưa yêu cầu.");
            if (validOtp.HieuLucDen < DateTime.UtcNow) return BadRequest("Mã OTP đã hết hạn.");

            // 2. Lấy tài khoản
            var account = await _context.TaiKhoanBenhNhans
                .FirstOrDefaultAsync(x => x.SoDienThoai == req.PhoneNumber);

            if (account == null) return BadRequest("Tài khoản không tồn tại.");

            // 3. Đổi pass
            account.MatKhau = HashPassword(req.NewPassword);
            validOtp.DaSuDung = true;

            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Đặt lại mật khẩu thành công." });
        }

        [HttpPost("change-password")] // Đổi mật khẩu (Đã đăng nhập)
        public async Task<IActionResult> ChangePassword([FromBody] PatientChangePasswordDto req)
        {
            var account = await _context.TaiKhoanBenhNhans
                .Include(x => x.BenhNhan)
                .FirstOrDefaultAsync(x => x.BenhNhan_Id == req.BenhNhanId);

            if (account == null) return BadRequest("Tài khoản không tồn tại.");

            if (!VerifyPassword(req.OldPassword, account.MatKhau))
            {
                return BadRequest("Mật khẩu cũ không đúng.");
            }

            account.MatKhau = HashPassword(req.NewPassword);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Đổi mật khẩu thành công." });
        }
    }
}
