using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItoApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddThanhToanTableFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Specialties",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RefreshTokens",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RefreshTokens",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "OtpCodes",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OtpCodes",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Nhom",
                table: "NhomNgheNghiep",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "NhomNgheNghiepId",
                table: "NhanVien",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "KhoaPhongId",
                table: "NhanVien",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "ChucVuId",
                table: "NhanVien",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "ChiNhanhId",
                table: "NhanVien",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id_NhanVien",
                table: "NhanVien",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienId",
                table: "LichSuChinhSua",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_LichSu",
                table: "LichSuChinhSua",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienId",
                table: "KyThuatChuyenMon",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id_KyThuat",
                table: "KyThuatChuyenMon",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienId",
                table: "KyLuat",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id_KyLuat",
                table: "KyLuat",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ChiNhanhId",
                table: "KhoaPhong",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id_KhoaPhong",
                table: "KhoaPhong",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HospitalBranches",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienId",
                table: "HopDongLaoDong",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id_HopDong",
                table: "HopDongLaoDong",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "DoctorSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "DoctorSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DoctorSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialtyId",
                table: "Doctors",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Doctors",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienId",
                table: "ChungChiHanhNghe",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id_ChungChi",
                table: "ChungChiHanhNghe",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienId",
                table: "ChungChiDaoTao",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id_ChungChiDaoTao",
                table: "ChungChiDaoTao",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id_ChucVu",
                table: "ChucVu",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id_ChiNhanh",
                table: "ChiNhanh",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

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
                name: "IX_ho_so_benh_nhan_nguoi_dung_id",
                table: "ho_so_benh_nhan",
                column: "nguoi_dung_id");

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
                name: "IX_khung_gio_lich_lv_id",
                table: "khung_gio",
                column: "lich_lv_id");

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
                name: "IX_ls_trang_thai_lich_hen_id",
                table: "ls_trang_thai",
                column: "lich_hen_id");

            migrationBuilder.CreateIndex(
                name: "IX_ls_trang_thai_nguoi_thuc_hien_id",
                table: "ls_trang_thai",
                column: "nguoi_thuc_hien_id");

            migrationBuilder.CreateIndex(
                name: "IX_phong_kham_khoa_id",
                table: "phong_kham",
                column: "khoa_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bs_cn");

            migrationBuilder.DropTable(
                name: "ket_qua_cls");

            migrationBuilder.DropTable(
                name: "ls_trang_thai");

            migrationBuilder.DropTable(
                name: "ThanhToan");

            migrationBuilder.DropTable(
                name: "lich_hen");

            migrationBuilder.DropTable(
                name: "goi_kham");

            migrationBuilder.DropTable(
                name: "ho_so_benh_nhan");

            migrationBuilder.DropTable(
                name: "khung_gio");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Specialties",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "OtpCodes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OtpCodes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_Nhom",
                table: "NhomNgheNghiep",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "NhomNgheNghiepId",
                table: "NhanVien",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "KhoaPhongId",
                table: "NhanVien",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChucVuId",
                table: "NhanVien",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChiNhanhId",
                table: "NhanVien",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_NhanVien",
                table: "NhanVien",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "NhanVienId",
                table: "LichSuChinhSua",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_LichSu",
                table: "LichSuChinhSua",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "NhanVienId",
                table: "KyThuatChuyenMon",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_KyThuat",
                table: "KyThuatChuyenMon",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "NhanVienId",
                table: "KyLuat",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_KyLuat",
                table: "KyLuat",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChiNhanhId",
                table: "KhoaPhong",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_KhoaPhong",
                table: "KhoaPhong",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "HospitalBranches",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "NhanVienId",
                table: "HopDongLaoDong",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_HopDong",
                table: "HopDongLaoDong",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "DoctorSchedules",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "DoctorSchedules",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "DoctorSchedules",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpecialtyId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "NhanVienId",
                table: "ChungChiHanhNghe",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_ChungChi",
                table: "ChungChiHanhNghe",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "NhanVienId",
                table: "ChungChiDaoTao",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_ChungChiDaoTao",
                table: "ChungChiDaoTao",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_ChucVu",
                table: "ChucVu",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_ChiNhanh",
                table: "ChiNhanh",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
