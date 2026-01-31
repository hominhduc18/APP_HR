using ItoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ItoApp.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // 1. Seed ChiNhanh
            if (!await context.ChiNhanhs.AnyAsync())
            {
                var chiNhanhs = new List<ChiNhanh>
                {
                    new ChiNhanh { MaChiNhanh = "TB", TenChiNhanh = "BỆNH VIỆN ITO Tân Bình", DiaChi = "305 Lê Văn Sỹ, P.1, Q.Tân Bình, TP.HCM", SoDienThoai = "028.3991.2222", MaSoThue = "3.02E+08" },
                    new ChiNhanh { MaChiNhanh = "PN", TenChiNhanh = "BỆNH VIỆN ITO Phú Nhuận", DiaChi = "140C Nguyễn Trọng Tuyển, P.8, Q.Phú Nhuận, TP.HCM", SoDienThoai = "028.3844.1111", MaSoThue = "3.02E+08" },
                    new ChiNhanh { MaChiNhanh = "PK", TenChiNhanh = "PHÒNG KHÁM ITO", DiaChi = "232 Lê Văn Sỹ, P.1, Q.Tân Bình, TP.HCM", SoDienThoai = "028.3991.2222", MaSoThue = "3.02E+08" }
                };
                await context.ChiNhanhs.AddRangeAsync(chiNhanhs);
                await context.SaveChangesAsync();
            }

            // 2. Seed NhomNgheNghiep
            if (!await context.NhomNgheNghieps.AnyAsync())
            {
                var nhoms = new List<NhomNgheNghiep>
                {
                    new NhomNgheNghiep { TenNhom = "Bác sĩ", MaNhom = "BS", MoTa = "Nhóm chuyên môn bác sĩ" },
                    new NhomNgheNghiep { TenNhom = "Điều dưỡng", MaNhom = "DD", MoTa = "Nhóm chuyên môn điều dưỡng" },
                    new NhomNgheNghiep { TenNhom = "Kỹ thuật viên", MaNhom = "KTV", MoTa = "Nhóm chuyên môn kỹ thuật viên" },
                    new NhomNgheNghiep { TenNhom = "Hành chính", MaNhom = "HC", MoTa = "Nhóm quản lý hành chính" }
                };
                await context.NhomNgheNghieps.AddRangeAsync(nhoms);
                await context.SaveChangesAsync();
            }

            // 3. Seed ChucVu
            if (!await context.ChucVus.AnyAsync())
            {
                var chucVus = new List<ChucVu>
                {
                    new ChucVu { TenChucVu = "Trưởng khoa", MoTa = "Quản lý khoa" },
                    new ChucVu { TenChucVu = "Phó khoa", MoTa = "Hỗ trợ quản lý khoa" },
                    new ChucVu { TenChucVu = "Bác sĩ chính", MoTa = "Chẩn đoán và điều trị chính" },
                    new ChucVu { TenChucVu = "ĐD Trưởng", MoTa = "Điều dưỡng trưởng khoa" },
                    new ChucVu { TenChucVu = "Nhân viên", MoTa = "Nhân viên chuyên môn" }
                };
                await context.ChucVus.AddRangeAsync(chucVus);
                await context.SaveChangesAsync();
            }

            // 4. Seed KhoaPhong
            if (!await context.KhoaPhongs.AnyAsync())
            {
                var chiNhanhTb = await context.ChiNhanhs.FirstAsync(c => c.MaChiNhanh == "TB");
                var chiNhanhPn = await context.ChiNhanhs.FirstAsync(c => c.MaChiNhanh == "PN");

                var khoaPhongs = new List<KhoaPhong>
                {
                    new KhoaPhong { TenKhoaPhong = "Khoa Nội", ChiNhanhId = chiNhanhTb.Id },
                    new KhoaPhong { TenKhoaPhong = "Khoa Ngoại", ChiNhanhId = chiNhanhTb.Id },
                    new KhoaPhong { TenKhoaPhong = "Khoa Cấp cứu", ChiNhanhId = chiNhanhPn.Id },
                    new KhoaPhong { TenKhoaPhong = "Khoa Xét nghiệm", ChiNhanhId = chiNhanhPn.Id }
                };
                await context.KhoaPhongs.AddRangeAsync(khoaPhongs);
                await context.SaveChangesAsync();
            }

            // 5. Seed NhanVien
            if (!await context.NhanViens.AnyAsync())
            {
                var chiNhanhTb = await context.ChiNhanhs.FirstAsync(c => c.MaChiNhanh == "TB");
                var khoaNoi = await context.KhoaPhongs.FirstAsync(k => k.TenKhoaPhong == "Khoa Nội");
                var nhomBs = await context.NhomNgheNghieps.FirstAsync(n => n.MaNhom == "BS");
                var chucVuTruongKhoa = await context.ChucVus.FirstAsync(c => c.TenChucVu == "Trưởng khoa");

                var nhanVien = new NhanVien
                {
                    MaNhanVien = "NV001",
                    HoTen = "Nguyễn Văn A",
                    NgaySinh = new DateTime(1985, 5, 20),
                    GioiTinh = "Nam",
                    SoDienThoai = "0901234567",
                    Email = "vana@ito.vn",
                    DiaChi = "123 Quận 1, TP.HCM",
                    NgayVaoLam = new DateTime(2015, 1, 1),
                    TrangThai = "Active",
                    ChiNhanhId = chiNhanhTb.Id,
                    KhoaPhongId = khoaNoi.Id,
                    NhomNgheNghiepId = nhomBs.Id,
                    ChucVuId = chucVuTruongKhoa.Id
                };
                await context.NhanViens.AddAsync(nhanVien);
                await context.SaveChangesAsync();
            }
        }
    }
}
