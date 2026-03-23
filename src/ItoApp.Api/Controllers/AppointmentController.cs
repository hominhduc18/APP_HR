using ItoApp.Application.Auth.Dto;
using ItoApp.Application.Common;
using ItoApp.Application.Interfaces;
using ItoApp.Domain.Entities.ItoCare;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ItoApp.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/appointment")]
public class AppointmentController : ControllerBase
{
    private readonly IItoCareRepository _itoCareRepo;

    public AppointmentController(IItoCareRepository itoCareRepo)
    {
        _itoCareRepo = itoCareRepo;
    }

    // 1. GET /appointment/khung-gio
    [HttpGet("khung-gio")]
    public async Task<IActionResult> GetSlots([FromQuery] int bac_si_id, [FromQuery] string ngay)
    {
        try 
        {
            var date = DateTime.Parse(ngay);
            var slots = await _itoCareRepo.LayDanhSachKhungGio(bac_si_id, date);
            
            var response = slots.Select(s => new PhanHoiKhungGioV3
            {
                KhungGioId = s.KhungGioId,
                GioBatDau = s.GioBatDau,
                GioKetThuc = s.GioKetThuc,
                ConTrong = true // Logic check trống cần thêm
            }).ToList();

            return Ok(BaseResponse<List<PhanHoiKhungGioV3>>.ThanhCong(response));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    // 2. GET /appointment/goi-kham
    [HttpGet("goi-kham")]
    public async Task<IActionResult> GetPackages()
    {
        try 
        {
            var packages = await _itoCareRepo.LayDanhSachGoiKham();
            var response = packages.Select(p => new PhanHoiGoiKhamV3
            {
                GoiKhamId = p.GoiKhamId,
                TenGoi = p.TenGoi,
                GiaTien = p.GiaTien,
                MoTa = p.MoTa
            }).ToList();

            return Ok(BaseResponse<List<PhanHoiGoiKhamV3>>.ThanhCong(response));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    // 3. POST /appointment/dat-lich
    [HttpPost("dat-lich")]
    public async Task<IActionResult> Book([FromBody] YeuCauDatLichV3 req)
    {
        try 
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();

            var lichHen = new LichHen
            {
                HoSoId = req.HoSoId,
                ChiNhanhId = req.ChiNhanhId,
                BacSiId = req.BacSiId,
                NgayHen = DateTime.Parse(req.NgayHen),
                KhungGioId = req.KhungGioId,
                GoiKhamId = req.GoiKhamId,
                LyDoKham = req.LyDoKham,
                TrangThai = "cho_xac_nhan",
                MaLichHen = "ITO" + DateTime.Now.Ticks.ToString().Substring(10),
                NgayTao = DateTime.UtcNow
            };

            await _itoCareRepo.ThemLichHen(lichHen);
            
            return Ok(BaseResponse<object>.ThanhCong(new { lich_hen_id = lichHen.LichHenId, ma_lich_hen = lichHen.MaLichHen }, "Đặt lịch thành công"));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    // 4. GET /appointment/lich-su
    [HttpGet("lich-su")]
    public async Task<IActionResult> GetHistory()
    {
        try 
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();

            var userId = int.Parse(userIdStr);
            var history = await _itoCareRepo.LayDanhSachLichHenTheoNguoiDung(userId);
            
            var response = history.Select(h => new PhanHoiLichSuLichHenV3
            {
                LichHenId = h.LichHenId,
                MaLichHen = h.MaLichHen,
                NgayHen = h.NgayHen.ToString("yyyy-MM-dd"),
                GioHen = h.KhungGio?.GioBatDau ?? "",
                TenBacSi = h.BacSi?.HoTen ?? "",
                TrangThai = h.TrangThai,
                TenChiNhanh = h.ChiNhanh?.TenChiNhanh ?? ""
            }).ToList();

            return Ok(BaseResponse<List<PhanHoiLichSuLichHenV3>>.ThanhCong(response));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    // 5. POST /appointment/huy
    [HttpPost("huy")]
    public async Task<IActionResult> Cancel([FromBody] YeuCauHuyLichHenV3 req)
    {
        try 
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();

            var userId = int.Parse(userIdStr);
            var lichHen = await _itoCareRepo.LayLichHenTheoId(req.LichHenId);
            
            if (lichHen == null || lichHen.HoSoBenhNhan?.NguoiDungId != userId)
                return Ok(BaseResponse<object>.ThatBai("Lịch hẹn không tồn tại hoặc không thuộc quyền sở hữu."));

            lichHen.TrangThai = "da_huy";
            // lichHen.LyDoHuy = req.LyDoHuy; // Cần add field vào DB nếu muốn lưu
            
            await _itoCareRepo.CapNhatLichHen(lichHen);
            
            return Ok(BaseResponse<object>.ThanhCong(null, "Hủy lịch hẹn thành công"));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }
}

