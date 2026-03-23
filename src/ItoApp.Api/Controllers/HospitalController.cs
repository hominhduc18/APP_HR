using ItoApp.Application.Auth.Dto;
using ItoApp.Application.Common;
using ItoApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItoApp.Api.Controllers;

[ApiController]
[Route("api/hospital")]
public class HospitalController : ControllerBase
{
    private readonly IItoCareRepository _itoCareRepo;

    public HospitalController(IItoCareRepository itoCareRepo)
    {
        _itoCareRepo = itoCareRepo;
    }

    // 1. GET /hospital/chi-nhanh
    [HttpGet("chi-nhanh")]
    public async Task<IActionResult> GetBranches()
    {
        try 
        {
            var branches = await _itoCareRepo.LayTatCaChiNhanh();
            var response = branches.Select(b => new PhanHoiChiNhanhV3
            {
                ChiNhanhId = b.ChiNhanhId,
                TenChiNhanh = b.TenChiNhanh,
                DiaChi = b.DiaChi,
                SoDienThoai = b.SoDienThoai,
                AnhDaiDien = b.AnhDaiDien
            }).ToList();

            return Ok(BaseResponse<List<PhanHoiChiNhanhV3>>.ThanhCong(response));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    // 2. GET /hospital/khoa-phong
    [HttpGet("khoa-phong")]
    public async Task<IActionResult> GetDepartments([FromQuery] int chi_nhanh_id)
    {
        try 
        {
            var departments = await _itoCareRepo.LayDanhSachKhoaTheoChiNhanh(chi_nhanh_id);
            var response = departments.Select(d => new PhanHoiKhoaPhongV3
            {
                KhoaId = d.KhoaId,
                TenKhoa = d.TenKhoa,
                AnhDaiDien = d.AnhDaiDien
            }).ToList();

            return Ok(BaseResponse<List<PhanHoiKhoaPhongV3>>.ThanhCong(response));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    // 3. GET /hospital/bac-si
    [HttpGet("bac-si")]
    public async Task<IActionResult> GetDoctors([FromQuery] int chi_nhanh_id, [FromQuery] int khoa_id)
    {
        try 
        {
            var doctors = await _itoCareRepo.LayDanhSachBacSi(chi_nhanh_id, khoa_id);
            var response = doctors.Select(d => new PhanHoiBacSiV3
            {
                BacSiId = d.BacSiId,
                HoTen = d.HoTen,
                HocHamHocVi = d.HocHamHocVi,
                AnhDaiDien = d.AnhDaiDien,
                ChuyenKhoa = d.ChuyenKhoa
            }).ToList();

            return Ok(BaseResponse<List<PhanHoiBacSiV3>>.ThanhCong(response));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }

    // 4. GET /hospital/bac-si-chi-tiet
    [HttpGet("bac-si-chi-tiet")]
    public async Task<IActionResult> GetDoctorDetail([FromQuery] int bac_si_id)
    {
        try 
        {
            var lichTrong = await _itoCareRepo.LayLichTrongBacSi(bac_si_id, DateTime.Now);

            var response = new PhanHoiChiTietBacSiV3
            {
                BacSiId = bac_si_id,
                HoTen = "Bác sĩ Sample",
                HocHamHocVi = "ThS. BS",
                ChuyenKhoa = "Nội tổng quát",
                GioiThieu = "Kinh nghiệm 10 năm...",
                LichTrong = lichTrong.Select(d => d.ToString("yyyy-MM-dd")).ToList()
            };

            return Ok(BaseResponse<PhanHoiChiTietBacSiV3>.ThanhCong(response));
        }
        catch (Exception ex)
        {
            return Ok(BaseResponse<object>.ThatBai(ex.Message));
        }
    }
}

