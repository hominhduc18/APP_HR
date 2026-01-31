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

            // 5. Seed NhanVien (Nhiều dữ liệu hơn để test)
            if (!await context.NhanViens.AnyAsync())
            {
                var chiNhanhTb = await context.ChiNhanhs.FirstAsync(c => c.MaChiNhanh == "TB");
                var chiNhanhPn = await context.ChiNhanhs.FirstAsync(c => c.MaChiNhanh == "PN");
                
                var khoaNoi = await context.KhoaPhongs.FirstAsync(k => k.TenKhoaPhong == "Khoa Nội");
                var khoaNgoai = await context.KhoaPhongs.FirstAsync(k => k.TenKhoaPhong == "Khoa Ngoại");
                var khoaCapCuu = await context.KhoaPhongs.FirstAsync(k => k.TenKhoaPhong == "Khoa Cấp cứu");
                
                var nhomBs = await context.NhomNgheNghieps.FirstAsync(n => n.MaNhom == "BS");
                var nhomDd = await context.NhomNgheNghieps.FirstAsync(n => n.MaNhom == "DD");
                var nhomHc = await context.NhomNgheNghieps.FirstAsync(n => n.MaNhom == "HC");
                
                var chucVuTruongKhoa = await context.ChucVus.FirstAsync(c => c.TenChucVu == "Trưởng khoa");
                var chucVuBacSi = await context.ChucVus.FirstAsync(c => c.TenChucVu == "Bác sĩ chính");
                var chucVuDdTruong = await context.ChucVus.FirstAsync(c => c.TenChucVu == "ĐD Trưởng");
                var chucVuNhanVien = await context.ChucVus.FirstAsync(c => c.TenChucVu == "Nhân viên");

                var listNhanVien = new List<NhanVien>
                {
                    new NhanVien { MaNhanVien = "NV001", HoTen = "Nguyễn Văn A", NgaySinh = new DateTime(1980, 1, 1), GioiTinh = "Nam", SoDienThoai = "0901234567", NgayVaoLam = new DateTime(2010, 1, 1), TrangThai = "Active", ChiNhanhId = chiNhanhTb.Id, KhoaPhongId = khoaNoi.Id, NhomNgheNghiepId = nhomBs.Id, ChucVuId = chucVuTruongKhoa.Id },
                    new NhanVien { MaNhanVien = "NV002", HoTen = "Trần Thị B", NgaySinh = new DateTime(1985, 2, 2), GioiTinh = "Nữ", SoDienThoai = "0902345678", NgayVaoLam = new DateTime(2012, 5, 10), TrangThai = "Active", ChiNhanhId = chiNhanhTb.Id, KhoaPhongId = khoaNoi.Id, NhomNgheNghiepId = nhomDd.Id, ChucVuId = chucVuDdTruong.Id },
                    new NhanVien { MaNhanVien = "NV003", HoTen = "Lê Văn C", NgaySinh = new DateTime(1990, 3, 3), GioiTinh = "Nam", SoDienThoai = "0903456789", NgayVaoLam = new DateTime(2015, 8, 15), TrangThai = "Active", ChiNhanhId = chiNhanhTb.Id, KhoaPhongId = khoaNgoai.Id, NhomNgheNghiepId = nhomBs.Id, ChucVuId = chucVuBacSi.Id },
                    new NhanVien { MaNhanVien = "NV004", HoTen = "Phạm Hoàng D", NgaySinh = new DateTime(1982, 4, 4), GioiTinh = "Nam", SoDienThoai = "0904567890", NgayVaoLam = new DateTime(2011, 3, 20), TrangThai = "Active", ChiNhanhId = chiNhanhPn.Id, KhoaPhongId = khoaCapCuu.Id, NhomNgheNghiepId = nhomBs.Id, ChucVuId = chucVuTruongKhoa.Id },
                    new NhanVien { MaNhanVien = "NV005", HoTen = "Võ Minh E", NgaySinh = new DateTime(1995, 5, 5), GioiTinh = "Nam", SoDienThoai = "0905678901", NgayVaoLam = new DateTime(2020, 1, 1), TrangThai = "Active", ChiNhanhId = chiNhanhPn.Id, KhoaPhongId = khoaCapCuu.Id, NhomNgheNghiepId = nhomDd.Id, ChucVuId = chucVuNhanVien.Id },
                    new NhanVien { MaNhanVien = "NV006", HoTen = "Đỗ Thùy F", NgaySinh = new DateTime(1988, 6, 6), GioiTinh = "Nữ", SoDienThoai = "0906789012", NgayVaoLam = new DateTime(2014, 11, 1), TrangThai = "Active", ChiNhanhId = chiNhanhTb.Id, KhoaPhongId = khoaNgoai.Id, NhomNgheNghiepId = nhomHc.Id, ChucVuId = chucVuNhanVien.Id },
                    new NhanVien { MaNhanVien = "NV007", HoTen = "Hoàng Kim G", NgaySinh = new DateTime(1992, 7, 7), GioiTinh = "Nữ", SoDienThoai = "0907890123", NgayVaoLam = new DateTime(2016, 2, 14), TrangThai = "Active", ChiNhanhId = chiNhanhPn.Id, KhoaPhongId = khoaCapCuu.Id, NhomNgheNghiepId = nhomDd.Id, ChucVuId = chucVuNhanVien.Id },
                    new NhanVien { MaNhanVien = "NV008", HoTen = "Ngô Bảo H", NgaySinh = new DateTime(1975, 8, 8), GioiTinh = "Nam", SoDienThoai = "0908901234", NgayVaoLam = new DateTime(2005, 12, 25), TrangThai = "Active", ChiNhanhId = chiNhanhTb.Id, KhoaPhongId = khoaNoi.Id, NhomNgheNghiepId = nhomBs.Id, ChucVuId = chucVuBacSi.Id },
                    new NhanVien { MaNhanVien = "NV009", HoTen = "Đặng Quang I", NgaySinh = new DateTime(1998, 9, 9), GioiTinh = "Nam", SoDienThoai = "0909012345", NgayVaoLam = new DateTime(2022, 6, 1), TrangThai = "Active", ChiNhanhId = chiNhanhPn.Id, KhoaPhongId = khoaCapCuu.Id, NhomNgheNghiepId = nhomHc.Id, ChucVuId = chucVuNhanVien.Id },
                    new NhanVien { MaNhanVien = "NV011", HoTen = "Lý Minh L", NgaySinh = new DateTime(1987, 11, 11), GioiTinh = "Nam", SoDienThoai = "0912123456", NgayVaoLam = new DateTime(2013, 8, 1), TrangThai = "Active", ChiNhanhId = chiNhanhTb.Id, KhoaPhongId = khoaNgoai.Id, NhomNgheNghiepId = nhomBs.Id, ChucVuId = chucVuBacSi.Id },
                    new NhanVien { MaNhanVien = "NV012", HoTen = "Phan Thu M", NgaySinh = new DateTime(1991, 12, 12), GioiTinh = "Nữ", SoDienThoai = "0913234567", NgayVaoLam = new DateTime(2018, 1, 15), TrangThai = "Active", ChiNhanhId = chiNhanhPn.Id, KhoaPhongId = khoaCapCuu.Id, NhomNgheNghiepId = nhomDd.Id, ChucVuId = chucVuNhanVien.Id },
                    new NhanVien { MaNhanVien = "NV013", HoTen = "Vũ Văn N", NgaySinh = new DateTime(1984, 1, 13), GioiTinh = "Nam", SoDienThoai = "0914345678", NgayVaoLam = new DateTime(2010, 9, 20), TrangThai = "Active", ChiNhanhId = chiNhanhTb.Id, KhoaPhongId = khoaNoi.Id, NhomNgheNghiepId = nhomBs.Id, ChucVuId = chucVuBacSi.Id },
                    new NhanVien { MaNhanVien = "NV014", HoTen = "Trịnh Kim O", NgaySinh = new DateTime(1996, 2, 14), GioiTinh = "Nữ", SoDienThoai = "0915456789", NgayVaoLam = new DateTime(2021, 3, 1), TrangThai = "Active", ChiNhanhId = chiNhanhPn.Id, KhoaPhongId = khoaCapCuu.Id, NhomNgheNghiepId = nhomDd.Id, ChucVuId = chucVuNhanVien.Id },
                    new NhanVien { MaNhanVien = "NV015", HoTen = "Nguyễn Thành P", NgaySinh = new DateTime(1989, 3, 15), GioiTinh = "Nam", SoDienThoai = "0916567890", NgayVaoLam = new DateTime(2014, 7, 10), TrangThai = "Active", ChiNhanhId = chiNhanhTb.Id, KhoaPhongId = khoaNgoai.Id, NhomNgheNghiepId = nhomHc.Id, ChucVuId = chucVuNhanVien.Id }
                };
                
                await context.NhanViens.AddRangeAsync(listNhanVien);
                await context.SaveChangesAsync();
            }

        }
    }
}
