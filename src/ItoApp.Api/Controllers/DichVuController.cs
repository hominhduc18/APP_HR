using ItoApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/dich-vu")]
    public class DichVuController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DichVuController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 1. Lấy danh sách Loại Dịch Vụ
        /// </summary>
        [HttpGet("danh-sach-loai")]
        public async Task<IActionResult> GetLoaiDichVu()
        {
            var loais = await _context.Dm_LoaiDichVus
                .Where(x => x.TamNgung == 0) // Chỉ lấy các loại đang hoạt động
                .OrderBy(x => x.Idx)
                .Select(x => new 
                {
                    x.LoaiDichVuId,
                    x.MaLoaiDichVu,
                    x.TenLoaiDichVu
                })
                .ToListAsync();

            return Ok(new { success = true, data = loais });
        }

        /// <summary>
        /// 2. Lấy danh sách Dịch Vụ chi tiết lọc theo Loại Dịch Vụ
        /// Dùng ADO.NET Query thuần tuý để bám sát cấu trúc Data thật của bạn
        /// </summary>
        [HttpGet("chi-tiet-theo-loai/{loaiDichVuId}")]
        public async Task<IActionResult> GetDichVuChiTiet(int loaiDichVuId)
        {
            var dichVus = new List<object>();
            using var connection = _context.Database.GetDbConnection();
            using var command = connection.CreateCommand();
            
            command.CommandText = @"SELECT dv.""NhomDichVuId"", dv.""MaNhomDichVu"", dv.""TenNhomDichVu""
                                    FROM ""Dm_DichVu"" dv 
                                    WHERE dv.""LoaiDichVuId"" = @loaidv 
                                      AND dv.""TamNgung"" = 0";
            
            var param = command.CreateParameter();
            param.ParameterName = "@loaidv";
            param.Value = loaiDichVuId;
            command.Parameters.Add(param);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                dichVus.Add(new 
                {
                    DichVuId = reader["NhomDichVuId"],
                    MaDichVu = reader["MaNhomDichVu"] == DBNull.Value ? null : reader["MaNhomDichVu"],
                    TenDichVu = reader["TenNhomDichVu"] == DBNull.Value ? null : reader["TenNhomDichVu"],
                    DonGia = 0 // Trong CSDL hiện tại bảng Dm_DichVu không có trường DonGia
                });
            }
            await connection.CloseAsync();

            return Ok(new { success = true, data = dichVus });
        }

        /// <summary>
        /// 3. Lấy tất cả Dịch vụ (JOIN TỔNG như câu SQL của bạn)
        /// Dùng ADO.NET Query thuần tuý
        /// </summary>
        [HttpGet("join-tong")]
        public async Task<IActionResult> GetJoinTongDichVu()
        {
            var result = new List<object>();
            using var connection = _context.Database.GetDbConnection();
            using var command = connection.CreateCommand();
            
            command.CommandText = @"
                SELECT dv.""NhomDichVuId"", dv.""MaNhomDichVu"", dv.""TenNhomDichVu"",
                       ldv.""LoaiDichVuId"", ldv.""TenLoaiDichVu""
                FROM ""Dm_DichVu"" dv
                JOIN ""Dm_LoaiDichVu"" ldv ON ldv.""LoaiDichVuId"" = dv.""LoaiDichVuId""
                WHERE dv.""TamNgung"" = 0";

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new 
                {
                    dichVuId = reader["NhomDichVuId"],
                    maDichVu = reader["MaNhomDichVu"] == DBNull.Value ? null : reader["MaNhomDichVu"],
                    tenDichVu = reader["TenNhomDichVu"] == DBNull.Value ? null : reader["TenNhomDichVu"],
                    donGia = 0,
                    loaiDichVuId = reader["LoaiDichVuId"],
                    tenLoaiDichVu = reader["TenLoaiDichVu"] == DBNull.Value ? null : reader["TenLoaiDichVu"]
                });
            }
            await connection.CloseAsync();

            return Ok(new { success = true, total = result.Count, data = result });
        }
    }
}
