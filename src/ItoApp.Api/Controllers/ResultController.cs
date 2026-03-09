using ItoApp.Application.Auth.Dto;
using ItoApp.Application.Common;
using ItoApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItoApp.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/result")]
public class ResultController : ControllerBase
{
    private readonly IItoCareRepository _itoCareRepo;

    public ResultController(IItoCareRepository itoCareRepo)
    {
        _itoCareRepo = itoCareRepo;
    }

    [HttpGet("danh-sach")]
    public async Task<IActionResult> GetResults([FromQuery] int ho_so_id)
    {
        try 
        {
            var results = await _itoCareRepo.LayDanhSachKetQuaTheoHoSo(ho_so_id);
            var response = results.Select(r => new PhanHoiKetQuaV3
            {
                KetQuaId = r.KetQuaId,
                TenDichVu = r.LoaiKetQua ?? "Xét nghiệm/Chẩn đoán",
                NgayThucHien = r.NgayThucHien.ToString("yyyy-MM-dd"),
                BacSiChiDinh = r.BacSi?.HoTen,
                TrangThai = "da_co_ket_qua"
            }).ToList();

            return Ok(BaseResponse<List<PhanHoiKetQuaV3>>.ThanhCong(response));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    [HttpGet("chi-tiet")]
    public async Task<IActionResult> GetDetail([FromQuery] int ket_qua_id)
    {
        try 
        {
            var result = await _itoCareRepo.LayKetQuaTheoId(ket_qua_id);
            if (result == null) return Ok(BaseResponse<object>.ThatBai("Kết quả không tồn tại"));

            var response = new PhanHoiChiTietKetQuaV3
            {
                KetQuaId = result.KetQuaId,
                TenDichVu = result.LoaiKetQua ?? "Chẩn đoán hình ảnh",
                NgayThucHien = result.NgayThucHien.ToString("yyyy-MM-dd"),
                BacSiChiDinh = result.BacSi?.HoTen,
                KetLuan = result.KetLuan,
                MoTaChiTiet = result.MoTa,
                HinhAnhUrls = string.IsNullOrEmpty(result.HinhAnhUrl) ? new() : result.HinhAnhUrl.Split(',').ToList()
            };

            return Ok(BaseResponse<PhanHoiChiTietKetQuaV3>.ThanhCong(response));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }
}
