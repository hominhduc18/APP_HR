using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItoApp.Infrastructure.Migrations.SqlServer
{
    /// <inheritdoc />
    public partial class AddThanhToanTable_SqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenhNhan",
                columns: table => new
                {
                    BenhNhan_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaYTe = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TenBenhNhan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenKhongDau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TheoDoiTienSu = table.Column<int>(type: "int", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CMND = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NgayCap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuocTich_Id = table.Column<int>(type: "int", nullable: true),
                    TinhThanh_Id = table.Column<int>(type: "int", nullable: true),
                    QuanHuyen_Id = table.Column<int>(type: "int", nullable: true),
                    XaPhuong_Id = table.Column<int>(type: "int", nullable: true),
                    SoNha = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NhomMau = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    YeuToRh_Id = table.Column<int>(type: "int", nullable: true),
                    TienSu = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NgheNghiep_Id = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NguoiLienHe = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SoDienThoaiNguoiLienHe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CongTy_Id = table.Column<int>(type: "int", nullable: true),
                    ChiNhanh_Id = table.Column<int>(type: "int", nullable: true),
                    TiepNhan_Id = table.Column<int>(type: "int", nullable: true),
                    BenhAn_Id_CLS = table.Column<int>(type: "int", nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Old = table.Column<int>(type: "int", nullable: true),
                    NguoiTao_Id = table.Column<int>(type: "int", nullable: true),
                    Login_Id_Tao = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DanToc_Id = table.Column<int>(type: "int", nullable: true),
                    NoiLamViec = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenhNhan", x => x.BenhNhan_Id);
                });

            migrationBuilder.CreateTable(
                name: "chi_nhanh",
                columns: table => new
                {
                    chi_nhanh_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_chi_nhanh = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    dia_chi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phuong_xa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    quan_huyen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tinh_thanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    so_dien_thoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    gio_hoat_dong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    kinh_do = table.Column<decimal>(type: "decimal(18,10)", precision: 18, scale: 10, nullable: true),
                    vi_do = table.Column<decimal>(type: "decimal(18,10)", precision: 18, scale: 10, nullable: true),
                    anh_dai_dien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    la_hoat_dong = table.Column<bool>(type: "bit", nullable: false),
                    thu_tu_hien_thi = table.Column<int>(type: "int", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chi_nhanh", x => x.chi_nhanh_id);
                });

            migrationBuilder.CreateTable(
                name: "ChiNhanh",
                columns: table => new
                {
                    Id_ChiNhanh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaChiNhanh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenChiNhanh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaSoThue = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiNhanh", x => x.Id_ChiNhanh);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    Id_ChucVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.Id_ChucVu);
                });

            migrationBuilder.CreateTable(
                name: "Dm_LoaiDichVu",
                columns: table => new
                {
                    LoaiDichVuId = table.Column<int>(type: "int", nullable: false),
                    MaLoaiDichVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoaiDichVu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenKhongDau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Idx = table.Column<int>(type: "int", nullable: false),
                    TamNgung = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Login_Id_Tao = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Login_Id_CapNhat = table.Column<int>(type: "int", nullable: true),
                    CongTy_Id = table.Column<int>(type: "int", nullable: false),
                    Id_Old = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dm_LoaiDichVu", x => x.LoaiDichVuId);
                });

            migrationBuilder.CreateTable(
                name: "Dm_PhongBan",
                columns: table => new
                {
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    MaPhong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenKhongDau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ViTri = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LoaiPhong = table.Column<int>(type: "int", nullable: true),
                    Cap = table.Column<int>(type: "int", nullable: false),
                    CapTren_Id = table.Column<int>(type: "int", nullable: true),
                    TruongPhong = table.Column<int>(type: "int", nullable: true),
                    PhoPhong = table.Column<int>(type: "int", nullable: true),
                    PhoPhong2 = table.Column<int>(type: "int", nullable: true),
                    Idx = table.Column<int>(type: "int", nullable: false),
                    ThucHienCLS = table.Column<int>(type: "int", nullable: false),
                    TamNgung = table.Column<int>(type: "int", nullable: false),
                    QuyTrinh = table.Column<int>(type: "int", nullable: false),
                    ChiNhanh_Id = table.Column<int>(type: "int", nullable: false),
                    CongTy_Id = table.Column<int>(type: "int", nullable: false),
                    Id_Old = table.Column<int>(type: "int", nullable: true),
                    GroupCha = table.Column<int>(type: "int", nullable: true),
                    NhanVien = table.Column<int>(type: "int", nullable: true),
                    STT = table.Column<int>(type: "int", nullable: true),
                    STTNhom = table.Column<int>(type: "int", nullable: true),
                    KhoaChuyenMon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhanLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dm_PhongBan", x => x.PhongBanId);
                    table.ForeignKey(
                        name: "FK_Dm_PhongBan_Dm_PhongBan_CapTren_Id",
                        column: x => x.CapTren_Id,
                        principalTable: "Dm_PhongBan",
                        principalColumn: "PhongBanId");
                });

            migrationBuilder.CreateTable(
                name: "goi_kham",
                columns: table => new
                {
                    goi_kham_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_goi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    mo_ta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gia_goi = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    anh_banner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    la_hoat_dong = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goi_kham", x => x.goi_kham_id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log_OTP",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoDienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaOTP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HieuLucDen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaSuDung = table.Column<bool>(type: "bit", nullable: false),
                    LoaiOTP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_OTP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nguoi_dung",
                columns: table => new
                {
                    nguoi_dung_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    so_dien_thoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    mat_khau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ho_ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    anh_dai_dien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vai_tro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    token_thiet_bi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    da_xac_minh = table.Column<bool>(type: "bit", nullable: false),
                    la_hoat_dong = table.Column<bool>(type: "bit", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoi_dung", x => x.nguoi_dung_id);
                });

            migrationBuilder.CreateTable(
                name: "NhomNgheNghiep",
                columns: table => new
                {
                    Id_Nhom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaNhom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomNgheNghiep", x => x.Id_Nhom);
                });

            migrationBuilder.CreateTable(
                name: "OtpCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Channel = table.Column<int>(type: "int", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    AttemptCount = table.Column<int>(type: "int", nullable: false),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay = table.Column<DateTime>(type: "date", nullable: false),
                    SoThuTu = table.Column<int>(type: "int", nullable: false),
                    MaBenhNhan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NamSinh = table.Column<int>(type: "int", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DoiTuong = table.Column<int>(type: "int", nullable: false),
                    SoTheBHYT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HanThe_Tu = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HanThe_Den = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaDKBD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhongId = table.Column<int>(type: "int", nullable: true),
                    BacSiId = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    LyDoKham = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ChanDoanNoiGioiThieu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao_Id = table.Column<int>(type: "int", nullable: true),
                    CongTy_Id = table.Column<int>(type: "int", nullable: true),
                    ChiNhanh_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThanhToan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaGiaoDich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ResetPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoanBenhNhan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenhNhan_Id = table.Column<long>(type: "bigint", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoanBenhNhan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoanBenhNhan_BenhNhan_BenhNhan_Id",
                        column: x => x.BenhNhan_Id,
                        principalTable: "BenhNhan",
                        principalColumn: "BenhNhan_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "khoa_phong",
                columns: table => new
                {
                    khoa_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chi_nhanh_id = table.Column<int>(type: "int", nullable: false),
                    ten_khoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    mo_ta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anh_dai_dien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    la_hoat_dong = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoa_phong", x => x.khoa_id);
                    table.ForeignKey(
                        name: "FK_khoa_phong_chi_nhanh_chi_nhanh_id",
                        column: x => x.chi_nhanh_id,
                        principalTable: "chi_nhanh",
                        principalColumn: "chi_nhanh_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhoaPhong",
                columns: table => new
                {
                    Id_KhoaPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoaPhong = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChiNhanhId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaPhong", x => x.Id_KhoaPhong);
                    table.ForeignKey(
                        name: "FK_KhoaPhong_ChiNhanh_ChiNhanhId",
                        column: x => x.ChiNhanhId,
                        principalTable: "ChiNhanh",
                        principalColumn: "Id_ChiNhanh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dm_NhomDichVu",
                columns: table => new
                {
                    NhomDichVuId = table.Column<int>(type: "int", nullable: false),
                    LoaiDichVuId = table.Column<int>(type: "int", nullable: false),
                    MaNhomDichVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenNhomDichVu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenKhongDau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Cap = table.Column<int>(type: "int", nullable: false),
                    CapTren_Id = table.Column<int>(type: "int", nullable: true),
                    TraKetQua = table.Column<int>(type: "int", nullable: false),
                    Idx = table.Column<int>(type: "int", nullable: false),
                    TamNgung = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Login_Id_Tao = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Login_Id_CapNhat = table.Column<int>(type: "int", nullable: true),
                    CongTy_Id = table.Column<int>(type: "int", nullable: true),
                    Id_Old = table.Column<int>(type: "int", nullable: true),
                    STT = table.Column<int>(type: "int", nullable: true),
                    MaSo_SYT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoLoaiGia = table.Column<int>(type: "int", nullable: true),
                    TieuDeKetQua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dm_NhomDichVu", x => x.NhomDichVuId);
                    table.ForeignKey(
                        name: "FK_Dm_NhomDichVu_Dm_LoaiDichVu_LoaiDichVuId",
                        column: x => x.LoaiDichVuId,
                        principalTable: "Dm_LoaiDichVu",
                        principalColumn: "LoaiDichVuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ho_so_benh_nhan",
                columns: table => new
                {
                    ho_so_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nguoi_dung_id = table.Column<int>(type: "int", nullable: false),
                    ma_benh_nhan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    quan_he = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ho_ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ngay_sinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gioi_tinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    so_dien_thoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    dia_chi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    so_bhyt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ho_so_benh_nhan", x => x.ho_so_id);
                    table.ForeignKey(
                        name: "FK_ho_so_benh_nhan_nguoi_dung_nguoi_dung_id",
                        column: x => x.nguoi_dung_id,
                        principalTable: "nguoi_dung",
                        principalColumn: "nguoi_dung_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bac_si",
                columns: table => new
                {
                    bac_si_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    khoa_id = table.Column<int>(type: "int", nullable: false),
                    ho_ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    chuc_danh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    hoc_ham_hoc_vi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    chuyen_khoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    anh_dai_dien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gioi_thieu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bac_si", x => x.bac_si_id);
                    table.ForeignKey(
                        name: "FK_bac_si_khoa_phong_khoa_id",
                        column: x => x.khoa_id,
                        principalTable: "khoa_phong",
                        principalColumn: "khoa_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phong_kham",
                columns: table => new
                {
                    phong_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    khoa_id = table.Column<int>(type: "int", nullable: false),
                    ten_phong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tien_to_stt = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    tang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phong_kham", x => x.phong_id);
                    table.ForeignKey(
                        name: "FK_phong_kham_khoa_phong_khoa_id",
                        column: x => x.khoa_id,
                        principalTable: "khoa_phong",
                        principalColumn: "khoa_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id_NhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayVaoLam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ChiNhanhId = table.Column<int>(type: "int", nullable: false),
                    KhoaPhongId = table.Column<int>(type: "int", nullable: false),
                    NhomNgheNghiepId = table.Column<int>(type: "int", nullable: false),
                    ChucVuId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id_NhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChiNhanh_ChiNhanhId",
                        column: x => x.ChiNhanhId,
                        principalTable: "ChiNhanh",
                        principalColumn: "Id_ChiNhanh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_ChucVuId",
                        column: x => x.ChucVuId,
                        principalTable: "ChucVu",
                        principalColumn: "Id_ChucVu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhanVien_KhoaPhong_KhoaPhongId",
                        column: x => x.KhoaPhongId,
                        principalTable: "KhoaPhong",
                        principalColumn: "Id_KhoaPhong",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhanVien_NhomNgheNghiep_NhomNgheNghiepId",
                        column: x => x.NhomNgheNghiepId,
                        principalTable: "NhomNgheNghiep",
                        principalColumn: "Id_Nhom",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dm_DichVu",
                columns: table => new
                {
                    DichVuId = table.Column<int>(type: "int", nullable: false),
                    NhomDichVuId = table.Column<int>(type: "int", nullable: false),
                    MaDichVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDichVu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TenKhongDau = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Cap = table.Column<int>(type: "int", nullable: false),
                    CapTren_Id = table.Column<int>(type: "int", nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Idx = table.Column<int>(type: "int", nullable: false),
                    BHYT = table.Column<int>(type: "int", nullable: true),
                    TamNgung = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonGiaBHYT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DonGiaNuocNgoai = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CongTy_Id = table.Column<int>(type: "int", nullable: true),
                    TyLeVAT = table.Column<int>(type: "int", nullable: true),
                    SoLanThucHien = table.Column<int>(type: "int", nullable: true),
                    Id_Old = table.Column<int>(type: "int", nullable: true),
                    KhoangCachGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoGia = table.Column<int>(type: "int", nullable: true),
                    TraKetQuaMien = table.Column<int>(type: "int", nullable: true),
                    TenNhom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeSo = table.Column<double>(type: "float", nullable: true),
                    DoanhThu = table.Column<int>(type: "int", nullable: true),
                    DoanhThuBHYT = table.Column<int>(type: "int", nullable: true),
                    ThucHien = table.Column<int>(type: "int", nullable: true),
                    MaGoiTu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login_Id_Tao = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Login_Id_CapNhat = table.Column<int>(type: "int", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLoaiGia = table.Column<int>(type: "int", nullable: true),
                    MapBHYT = table.Column<int>(type: "int", nullable: true),
                    DonGia2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dm_DichVu", x => x.DichVuId);
                    table.ForeignKey(
                        name: "FK_Dm_DichVu_Dm_NhomDichVu_NhomDichVuId",
                        column: x => x.NhomDichVuId,
                        principalTable: "Dm_NhomDichVu",
                        principalColumn: "NhomDichVuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    PhongBanId = table.Column<int>(type: "int", nullable: true),
                    NhomDichVuId = table.Column<int>(type: "int", nullable: true),
                    DichVuId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MaxPatients = table.Column<int>(type: "int", nullable: false),
                    CurrentPatients = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSchedules_Dm_PhongBan_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "Dm_PhongBan",
                        principalColumn: "PhongBanId");
                    table.ForeignKey(
                        name: "FK_DoctorSchedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSchedules_HospitalBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "HospitalBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    AppointmentTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BookingCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_HospitalBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "HospitalBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bs_cn",
                columns: table => new
                {
                    bs_cn_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bac_si_id = table.Column<int>(type: "int", nullable: false),
                    chi_nhanh_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bs_cn", x => x.bs_cn_id);
                    table.ForeignKey(
                        name: "FK_bs_cn_bac_si_bac_si_id",
                        column: x => x.bac_si_id,
                        principalTable: "bac_si",
                        principalColumn: "bac_si_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bs_cn_chi_nhanh_chi_nhanh_id",
                        column: x => x.chi_nhanh_id,
                        principalTable: "chi_nhanh",
                        principalColumn: "chi_nhanh_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ket_qua_cls",
                columns: table => new
                {
                    ket_qua_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ho_so_id = table.Column<int>(type: "int", nullable: false),
                    bac_si_id = table.Column<int>(type: "int", nullable: true),
                    loai_ket_qua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ten_dich_vu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    nhom_dich_vu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngay_thuc_hien = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nam = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ket_luan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duong_dan_pdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mo_ta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hinh_anh_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duong_dan_pacs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    da_ky = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ket_qua_cls", x => x.ket_qua_id);
                    table.ForeignKey(
                        name: "FK_ket_qua_cls_bac_si_bac_si_id",
                        column: x => x.bac_si_id,
                        principalTable: "bac_si",
                        principalColumn: "bac_si_id");
                    table.ForeignKey(
                        name: "FK_ket_qua_cls_ho_so_benh_nhan_ho_so_id",
                        column: x => x.ho_so_id,
                        principalTable: "ho_so_benh_nhan",
                        principalColumn: "ho_so_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lich_lam_viec",
                columns: table => new
                {
                    lich_lv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bac_si_id = table.Column<int>(type: "int", nullable: false),
                    phong_id = table.Column<int>(type: "int", nullable: false),
                    ngay_lam_viec = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ca = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    gio_bat_dau = table.Column<TimeSpan>(type: "time", nullable: false),
                    gio_ket_thuc = table.Column<TimeSpan>(type: "time", nullable: false),
                    so_luong_toi_da = table.Column<int>(type: "int", nullable: false),
                    da_dat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lich_lam_viec", x => x.lich_lv_id);
                    table.ForeignKey(
                        name: "FK_lich_lam_viec_bac_si_bac_si_id",
                        column: x => x.bac_si_id,
                        principalTable: "bac_si",
                        principalColumn: "bac_si_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lich_lam_viec_phong_kham_phong_id",
                        column: x => x.phong_id,
                        principalTable: "phong_kham",
                        principalColumn: "phong_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChungChiDaoTao",
                columns: table => new
                {
                    Id_ChungChiDaoTao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChungChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDaoTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayHoanThanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChungChiDaoTao", x => x.Id_ChungChiDaoTao);
                    table.ForeignKey(
                        name: "FK_ChungChiDaoTao_NhanVien_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVien",
                        principalColumn: "Id_NhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChungChiHanhNghe",
                columns: table => new
                {
                    Id_ChungChi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoChungChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhamViChuyenMon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayCap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiaHan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChungChiHanhNghe", x => x.Id_ChungChi);
                    table.ForeignKey(
                        name: "FK_ChungChiHanhNghe_NhanVien_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVien",
                        principalColumn: "Id_NhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDongLaoDong",
                columns: table => new
                {
                    Id_HopDong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuongDanFileScan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongLaoDong", x => x.Id_HopDong);
                    table.ForeignKey(
                        name: "FK_HopDongLaoDong_NhanVien_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVien",
                        principalColumn: "Id_NhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KyLuat",
                columns: table => new
                {
                    Id_KyLuat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayViPham = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayQuyetDinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nodung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyLuat", x => x.Id_KyLuat);
                    table.ForeignKey(
                        name: "FK_KyLuat_NhanVien_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVien",
                        principalColumn: "Id_NhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KyThuatChuyenMon",
                columns: table => new
                {
                    Id_KyThuat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKyThuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayPheDuyet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyThuatChuyenMon", x => x.Id_KyThuat);
                    table.ForeignKey(
                        name: "FK_KyThuatChuyenMon_NhanVien_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVien",
                        principalColumn: "Id_NhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichSuChinhSua",
                columns: table => new
                {
                    Id_LichSu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThaoTac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiThucHien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuLieuCu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuLieuMoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuChinhSua", x => x.Id_LichSu);
                    table.ForeignKey(
                        name: "FK_LichSuChinhSua_NhanVien_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVien",
                        principalColumn: "Id_NhanVien");
                });

            migrationBuilder.CreateTable(
                name: "khung_gio",
                columns: table => new
                {
                    khung_gio_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lich_lv_id = table.Column<int>(type: "int", nullable: false),
                    thoi_gian = table.Column<TimeSpan>(type: "time", nullable: false),
                    da_dat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khung_gio", x => x.khung_gio_id);
                    table.ForeignKey(
                        name: "FK_khung_gio_lich_lam_viec_lich_lv_id",
                        column: x => x.lich_lv_id,
                        principalTable: "lich_lam_viec",
                        principalColumn: "lich_lv_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lich_hen",
                columns: table => new
                {
                    lich_hen_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ho_so_id = table.Column<int>(type: "int", nullable: false),
                    lich_lv_id = table.Column<int>(type: "int", nullable: false),
                    khung_gio_id = table.Column<int>(type: "int", nullable: true),
                    bac_si_id = table.Column<int>(type: "int", nullable: true),
                    chi_nhanh_id = table.Column<int>(type: "int", nullable: true),
                    ngay_hen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trang_thai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ly_do_kham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loai_kham = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    goi_kham_id = table.Column<int>(type: "int", nullable: true),
                    ma_lich_hen = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lich_hen", x => x.lich_hen_id);
                    table.ForeignKey(
                        name: "FK_lich_hen_bac_si_bac_si_id",
                        column: x => x.bac_si_id,
                        principalTable: "bac_si",
                        principalColumn: "bac_si_id");
                    table.ForeignKey(
                        name: "FK_lich_hen_chi_nhanh_chi_nhanh_id",
                        column: x => x.chi_nhanh_id,
                        principalTable: "chi_nhanh",
                        principalColumn: "chi_nhanh_id");
                    table.ForeignKey(
                        name: "FK_lich_hen_goi_kham_goi_kham_id",
                        column: x => x.goi_kham_id,
                        principalTable: "goi_kham",
                        principalColumn: "goi_kham_id");
                    table.ForeignKey(
                        name: "FK_lich_hen_ho_so_benh_nhan_ho_so_id",
                        column: x => x.ho_so_id,
                        principalTable: "ho_so_benh_nhan",
                        principalColumn: "ho_so_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lich_hen_khung_gio_khung_gio_id",
                        column: x => x.khung_gio_id,
                        principalTable: "khung_gio",
                        principalColumn: "khung_gio_id");
                    table.ForeignKey(
                        name: "FK_lich_hen_lich_lam_viec_lich_lv_id",
                        column: x => x.lich_lv_id,
                        principalTable: "lich_lam_viec",
                        principalColumn: "lich_lv_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ls_trang_thai",
                columns: table => new
                {
                    ls_trang_thai_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lich_hen_id = table.Column<int>(type: "int", nullable: false),
                    trang_thai_cu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    trang_thai_moi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    nguoi_thuc_hien_id = table.Column<int>(type: "int", nullable: true),
                    ghi_chu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ls_trang_thai", x => x.ls_trang_thai_id);
                    table.ForeignKey(
                        name: "FK_ls_trang_thai_lich_hen_lich_hen_id",
                        column: x => x.lich_hen_id,
                        principalTable: "lich_hen",
                        principalColumn: "lich_hen_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ls_trang_thai_nguoi_dung_nguoi_thuc_hien_id",
                        column: x => x.nguoi_thuc_hien_id,
                        principalTable: "nguoi_dung",
                        principalColumn: "nguoi_dung_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BranchId",
                table: "Appointments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_bac_si_khoa_id",
                table: "bac_si",
                column: "khoa_id");

            migrationBuilder.CreateIndex(
                name: "IX_bs_cn_bac_si_id",
                table: "bs_cn",
                column: "bac_si_id");

            migrationBuilder.CreateIndex(
                name: "IX_bs_cn_chi_nhanh_id",
                table: "bs_cn",
                column: "chi_nhanh_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChungChiDaoTao_NhanVienId",
                table: "ChungChiDaoTao",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_ChungChiHanhNghe_NhanVienId",
                table: "ChungChiHanhNghe",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_Dm_DichVu_NhomDichVuId",
                table: "Dm_DichVu",
                column: "NhomDichVuId");

            migrationBuilder.CreateIndex(
                name: "IX_Dm_NhomDichVu_LoaiDichVuId",
                table: "Dm_NhomDichVu",
                column: "LoaiDichVuId");

            migrationBuilder.CreateIndex(
                name: "IX_Dm_PhongBan_CapTren_Id",
                table: "Dm_PhongBan",
                column: "CapTren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_BranchId",
                table: "DoctorSchedules",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_PhongBanId",
                table: "DoctorSchedules",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_ho_so_benh_nhan_nguoi_dung_id",
                table: "ho_so_benh_nhan",
                column: "nguoi_dung_id");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongLaoDong_NhanVienId",
                table: "HopDongLaoDong",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_ket_qua_cls_bac_si_id",
                table: "ket_qua_cls",
                column: "bac_si_id");

            migrationBuilder.CreateIndex(
                name: "IX_ket_qua_cls_ho_so_id",
                table: "ket_qua_cls",
                column: "ho_so_id");

            migrationBuilder.CreateIndex(
                name: "IX_khoa_phong_chi_nhanh_id",
                table: "khoa_phong",
                column: "chi_nhanh_id");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaPhong_ChiNhanhId",
                table: "KhoaPhong",
                column: "ChiNhanhId");

            migrationBuilder.CreateIndex(
                name: "IX_khung_gio_lich_lv_id",
                table: "khung_gio",
                column: "lich_lv_id");

            migrationBuilder.CreateIndex(
                name: "IX_KyLuat_NhanVienId",
                table: "KyLuat",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_KyThuatChuyenMon_NhanVienId",
                table: "KyThuatChuyenMon",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_lich_hen_bac_si_id",
                table: "lich_hen",
                column: "bac_si_id");

            migrationBuilder.CreateIndex(
                name: "IX_lich_hen_chi_nhanh_id",
                table: "lich_hen",
                column: "chi_nhanh_id");

            migrationBuilder.CreateIndex(
                name: "IX_lich_hen_goi_kham_id",
                table: "lich_hen",
                column: "goi_kham_id");

            migrationBuilder.CreateIndex(
                name: "IX_lich_hen_ho_so_id",
                table: "lich_hen",
                column: "ho_so_id");

            migrationBuilder.CreateIndex(
                name: "IX_lich_hen_khung_gio_id",
                table: "lich_hen",
                column: "khung_gio_id");

            migrationBuilder.CreateIndex(
                name: "IX_lich_hen_lich_lv_id",
                table: "lich_hen",
                column: "lich_lv_id");

            migrationBuilder.CreateIndex(
                name: "IX_lich_lam_viec_bac_si_id",
                table: "lich_lam_viec",
                column: "bac_si_id");

            migrationBuilder.CreateIndex(
                name: "IX_lich_lam_viec_phong_id",
                table: "lich_lam_viec",
                column: "phong_id");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuChinhSua_NhanVienId",
                table: "LichSuChinhSua",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_ls_trang_thai_lich_hen_id",
                table: "ls_trang_thai",
                column: "lich_hen_id");

            migrationBuilder.CreateIndex(
                name: "IX_ls_trang_thai_nguoi_thuc_hien_id",
                table: "ls_trang_thai",
                column: "nguoi_thuc_hien_id");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_ChiNhanhId",
                table: "NhanVien",
                column: "ChiNhanhId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_ChucVuId",
                table: "NhanVien",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_KhoaPhongId",
                table: "NhanVien",
                column: "KhoaPhongId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_NhomNgheNghiepId",
                table: "NhanVien",
                column: "NhomNgheNghiepId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_phong_kham_khoa_id",
                table: "phong_kham",
                column: "khoa_id");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoanBenhNhan_BenhNhan_Id",
                table: "TaiKhoanBenhNhan",
                column: "BenhNhan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "bs_cn");

            migrationBuilder.DropTable(
                name: "ChungChiDaoTao");

            migrationBuilder.DropTable(
                name: "ChungChiHanhNghe");

            migrationBuilder.DropTable(
                name: "Dm_DichVu");

            migrationBuilder.DropTable(
                name: "DoctorSchedules");

            migrationBuilder.DropTable(
                name: "HopDongLaoDong");

            migrationBuilder.DropTable(
                name: "ket_qua_cls");

            migrationBuilder.DropTable(
                name: "KyLuat");

            migrationBuilder.DropTable(
                name: "KyThuatChuyenMon");

            migrationBuilder.DropTable(
                name: "LichSuChinhSua");

            migrationBuilder.DropTable(
                name: "Log_OTP");

            migrationBuilder.DropTable(
                name: "ls_trang_thai");

            migrationBuilder.DropTable(
                name: "OtpCodes");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "STT");

            migrationBuilder.DropTable(
                name: "TaiKhoanBenhNhan");

            migrationBuilder.DropTable(
                name: "ThanhToan");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Dm_NhomDichVu");

            migrationBuilder.DropTable(
                name: "Dm_PhongBan");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "HospitalBranches");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "lich_hen");

            migrationBuilder.DropTable(
                name: "BenhNhan");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Dm_LoaiDichVu");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "KhoaPhong");

            migrationBuilder.DropTable(
                name: "NhomNgheNghiep");

            migrationBuilder.DropTable(
                name: "goi_kham");

            migrationBuilder.DropTable(
                name: "ho_so_benh_nhan");

            migrationBuilder.DropTable(
                name: "khung_gio");

            migrationBuilder.DropTable(
                name: "ChiNhanh");

            migrationBuilder.DropTable(
                name: "nguoi_dung");

            migrationBuilder.DropTable(
                name: "lich_lam_viec");

            migrationBuilder.DropTable(
                name: "bac_si");

            migrationBuilder.DropTable(
                name: "phong_kham");

            migrationBuilder.DropTable(
                name: "khoa_phong");

            migrationBuilder.DropTable(
                name: "chi_nhanh");
        }
    }
}
