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

            // Seed Dm_LoaiDichVu
            if (!await context.Dm_LoaiDichVus.AnyAsync())
            {
                var loaiDichVus = new List<Dm_LoaiDichVu>
                {
                    new Dm_LoaiDichVu { LoaiDichVuId = 1, MaLoaiDichVu = "KB", TenLoaiDichVu = "Khám bệnh", TenKhongDau = "Kham benh", Idx = 1000, TamNgung = 0, CongTy_Id = 1, Id_Old = 1 },
                    new Dm_LoaiDichVu { LoaiDichVuId = 2, MaLoaiDichVu = "CLS", TenLoaiDichVu = "Cận lâm sàng", TenKhongDau = "Can lam sang", Idx = 2000, TamNgung = 0, CongTy_Id = 1, Id_Old = 2 },
                    new Dm_LoaiDichVu { LoaiDichVuId = 10, MaLoaiDichVu = "DV", TenLoaiDichVu = "Dịch vụ", TenKhongDau = "Dich vu", Idx = 4000, TamNgung = 0, CongTy_Id = 1, Id_Old = 5 },
                    new Dm_LoaiDichVu { LoaiDichVuId = 5, MaLoaiDichVu = "PT", TenLoaiDichVu = "Phẫu thuật", TenKhongDau = "Phau thuat", Idx = 6000, TamNgung = 0, CongTy_Id = 1, Id_Old = 3 },
                    new Dm_LoaiDichVu { LoaiDichVuId = 6, MaLoaiDichVu = "TT", TenLoaiDichVu = "Thủ thuật", TenKhongDau = "Thu thuat", Idx = 5000, TamNgung = 0, CongTy_Id = 1, Id_Old = 8 },
                    new Dm_LoaiDichVu { LoaiDichVuId = 11, MaLoaiDichVu = "TIEUPHAU", TenLoaiDichVu = "Tiểu phẫu", TenKhongDau = "Tieu phau", Idx = 4500, TamNgung = 0, CongTy_Id = 1, Id_Old = null },
                    new Dm_LoaiDichVu { LoaiDichVuId = 9, MaLoaiDichVu = "XNM", TenLoaiDichVu = "Xét nghiệm", TenKhongDau = "Xet nghiem", Idx = 3000, TamNgung = 0, CongTy_Id = 1, Id_Old = null }
                };
                await context.Dm_LoaiDichVus.AddRangeAsync(loaiDichVus);
                await context.SaveChangesAsync();
            }

            // Seed Dm_NhomDichVu
            if (!await context.Dm_NhomDichVus.AnyAsync())
            {
                var nhomDichVus = new List<Dm_NhomDichVu>
                {
                    new Dm_NhomDichVu { NhomDichVuId = 1, LoaiDichVuId = 1, MaNhomDichVu = "KBC", TenNhomDichVu = "Khám bệnh", TenKhongDau = "Kham Ben", Cap = 1, CapTren_Id = null, TraKetQua = 1, Idx = 1000, TamNgung = 0, CongTy_Id = 1, Id_Old = 6, SoLoaiGia = 1, TieuDeKetQua = null },
                    new Dm_NhomDichVu { NhomDichVuId = 2, LoaiDichVuId = 9, MaNhomDichVu = "XNHH", TenNhomDichVu = "XN huyết học", TenKhongDau = "XN huyet hoa", Cap = 1, CapTren_Id = null, TraKetQua = 1, Idx = 300, TamNgung = 0, CongTy_Id = 1, Id_Old = 3, SoLoaiGia = 1, TieuDeKetQua = null },
                    new Dm_NhomDichVu { NhomDichVuId = 3, LoaiDichVuId = 9, MaNhomDichVu = "XNSH", TenNhomDichVu = "XN Sinh Hóa", TenKhongDau = "XN Sinh Hoa", Cap = 1, CapTren_Id = null, TraKetQua = 0, Idx = 100, TamNgung = 0, CongTy_Id = 1, Id_Old = 11, SoLoaiGia = 1, TieuDeKetQua = null },
                    new Dm_NhomDichVu { NhomDichVuId = 4, LoaiDichVuId = 9, MaNhomDichVu = "XNVS", TenNhomDichVu = "XN vi sinh", TenKhongDau = "XN vi sinh", Cap = 2, CapTren_Id = null, TraKetQua = 0, Idx = 400, TamNgung = 0, CongTy_Id = 1, Id_Old = 13, SoLoaiGia = 1, TieuDeKetQua = null },
                    new Dm_NhomDichVu { NhomDichVuId = 6, LoaiDichVuId = 2, MaNhomDichVu = "CT", TenNhomDichVu = "CT Scanner", TenKhongDau = "CT Scanne", Cap = 2, CapTren_Id = null, TraKetQua = 1, Idx = 1000, TamNgung = 0, CongTy_Id = 1, Id_Old = 17, SoLoaiGia = 1, TieuDeKetQua = "KẾT QUẢ CT", MaSo_SYT = "MS: 09/BV" },
                    new Dm_NhomDichVu { NhomDichVuId = 7, LoaiDichVuId = 2, MaNhomDichVu = "SA", TenNhomDichVu = "Siêu âm", TenKhongDau = "Sieu am", Cap = 2, CapTren_Id = null, TraKetQua = 1, Idx = 1000, TamNgung = 0, CongTy_Id = 1, Id_Old = 19, SoLoaiGia = 1, TieuDeKetQua = "KẾT QUẢ SA", MaSo_SYT = "MS: 11/BV" },
                    new Dm_NhomDichVu { NhomDichVuId = 10, LoaiDichVuId = 2, MaNhomDichVu = "DC", TenNhomDichVu = "Điện cơ", TenKhongDau = "Dien co", Cap = 2, CapTren_Id = null, TraKetQua = 0, Idx = 1000, TamNgung = 0, CongTy_Id = 1, Id_Old = 24, SoLoaiGia = 1, TieuDeKetQua = "KẾT QUẢ DC" },
                    new Dm_NhomDichVu { NhomDichVuId = 12, LoaiDichVuId = 2, MaNhomDichVu = "MRI", TenNhomDichVu = "MRI", TenKhongDau = "MRI", Cap = 2, CapTren_Id = null, TraKetQua = 1, Idx = 1000, TamNgung = 1, CongTy_Id = 1, Id_Old = 77, SoLoaiGia = 1, TieuDeKetQua = null, MaSo_SYT = "MS: 10/BV" },
                    new Dm_NhomDichVu { NhomDichVuId = 39, LoaiDichVuId = 6, MaNhomDichVu = "TP", TenNhomDichVu = "Tiểu phẫu", TenKhongDau = "Tieu phau", Cap = 1, CapTren_Id = null, TraKetQua = 0, Idx = 1, TamNgung = 0, CongTy_Id = 1, Id_Old = 66, SoLoaiGia = 1, TieuDeKetQua = null },
                    new Dm_NhomDichVu { NhomDichVuId = 51, LoaiDichVuId = 10, MaNhomDichVu = "DVKP", TenNhomDichVu = "DV Chung", TenKhongDau = "DV Chung", Cap = 1, CapTren_Id = null, TraKetQua = 0, Idx = 1000, TamNgung = 0, CongTy_Id = 1, Id_Old = null, SoLoaiGia = 1, TieuDeKetQua = null }
                };
                await context.Dm_NhomDichVus.AddRangeAsync(nhomDichVus);
                await context.SaveChangesAsync();
            }

            // Seed Dm_DichVu (A few sample rows)
            if (!await context.Dm_DichVus.AnyAsync())
            {
                var dichVus = new List<Dm_DichVu>
                {
                    new Dm_DichVu { 
                        DichVuId = 1, NhomDichVuId = 1, MaDichVu = "4110", 
                        TenDichVu = "Khám bệnh", TenKhongDau = "Kham benh", 
                        Cap = 1, DonViTinh = "Lần", Idx = 1000, BHYT = 1, TamNgung = 0,
                        DonGia = 150000, DonGiaBHYT = 38700, DonGiaNuocNgoai = 400000,
                        CongTy_Id = 1, SoLoaiGia = 1, CoGia = 1
                    },
                    new Dm_DichVu { 
                         DichVuId = 2, NhomDichVuId = 1, MaDichVu = "4155", 
                         TenDichVu = "Khám bệnh (Ngoài giờ)", TenKhongDau = "Kham benh ngoai gio", 
                         Cap = 1, DonViTinh = "Lần", Idx = 2000, BHYT = 0, TamNgung = 0,
                         DonGia = 200000, DonGiaBHYT = 0, DonGiaNuocNgoai = 500000,
                         CongTy_Id = 1, SoLoaiGia = 1, CoGia = 1
                    },
                     new Dm_DichVu { 
                         DichVuId = 88, NhomDichVuId = 6, MaDichVu = "4129", 
                         TenDichVu = "Chụp CT Scanner Sọ não", TenKhongDau = "Chup CT Scanner So nao", 
                         Cap = 1, DonViTinh = "Lần", Idx = 1000, BHYT = 1, TamNgung = 0,
                         DonGia = 1300000, DonGiaBHYT = 1000000, DonGiaNuocNgoai = 2000000,
                         CongTy_Id = 1, SoLoaiGia = 1, CoGia = 1, MapBHYT = 1
                    },
                    new Dm_DichVu { 
                         DichVuId = 112, NhomDichVuId = 7, MaDichVu = "2182", 
                         TenDichVu = "Siêu âm bụng tổng quát", TenKhongDau = "Sieu am bung tong quat", 
                         Cap = 1, DonViTinh = "Lần", Idx = 1000, BHYT = 1, TamNgung = 0,
                         DonGia = 220000, DonGiaBHYT = 150000, DonGiaNuocNgoai = 500000,
                         CongTy_Id = 1, SoLoaiGia = 1, CoGia = 1, MapBHYT = 1
                    }
                };
                await context.Dm_DichVus.AddRangeAsync(dichVus);
                await context.SaveChangesAsync();
            }

            // Seed STT (Queue)
            if (!await context.STTs.AnyAsync())
            {
                var today = DateTime.Now.Date;
                var stts = new List<STT>
                {
                    new STT { Ngay = today, SoThuTu = 1, HoTen = "Lê Văn Tám", NamSinh = 1990, GioiTinh = "Nam", DiaChi = "Q.3, TP.HCM", DienThoai = "090111222", DoiTuong = 0, TrangThai = 0, LyDoKham = "Đau bụng", NgayTao = DateTime.Now },
                    new STT { Ngay = today, SoThuTu = 2, HoTen = "Trần Thị Lan", NamSinh = 1985, GioiTinh = "Nữ", DiaChi = "Tân Bình, TP.HCM", DienThoai = "090333444", DoiTuong = 1, SoTheBHYT = "DN4791234567890", TrangThai = 1, LyDoKham = "Tái khám tiểu đường", NgayTao = DateTime.Now.AddMinutes(5) },
                    new STT { Ngay = today, SoThuTu = 3, HoTen = "Nguyễn Hùng", NamSinh = 2000, GioiTinh = "Nam", DiaChi = "Phú Nhuận, TP.HCM", DienThoai = "090555666", DoiTuong = 0, TrangThai = 0, LyDoKham = "Sốt cao", NgayTao = DateTime.Now.AddMinutes(10) }
                };
                await context.STTs.AddRangeAsync(stts);
                await context.SaveChangesAsync();
            }

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

                // 6. Seed ChungChiHanhNghe (Để test Dashboard)
                var nv1 = listNhanVien.First(n => n.MaNhanVien == "NV001");
                var nv3 = listNhanVien.First(n => n.MaNhanVien == "NV003");
                var nv4 = listNhanVien.First(n => n.MaNhanVien == "NV004");

                var licenses = new List<ChungChiHanhNghe>
                {
                    new ChungChiHanhNghe { SoChungChi = "12345/HCM-CCHN", PhamViChuyenMon = "Nội khoa", NoiCap = "Sở Y Tế HCM", NgayCap = new DateTime(2020, 1, 1), NgayHetHan = DateTime.Now.AddMonths(1), NhanVienId = nv1.Id },
                    new ChungChiHanhNghe { SoChungChi = "67890/HCM-CCHN", PhamViChuyenMon = "Ngoại khoa", NoiCap = "Sở Y Tế HCM", NgayCap = new DateTime(2021, 5, 15), NgayHetHan = DateTime.Now.AddMonths(2), NhanVienId = nv3.Id },
                    new ChungChiHanhNghe { SoChungChi = "11223/HCM-CCHN", PhamViChuyenMon = "Hồi sức cấp cứu", NoiCap = "Sở Y Tế HCM", NgayCap = new DateTime(2019, 10, 10), NgayHetHan = DateTime.Now.AddDays(15), NhanVienId = nv4.Id }
                };
                await context.ChungChiHanhNghes.AddRangeAsync(licenses);
                await context.SaveChangesAsync();
            }

        }
    }
}
