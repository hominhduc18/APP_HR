using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItoApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientAndDeptTables : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Dm_PhongBan_CapTren_Id",
                table: "Dm_PhongBan",
                column: "CapTren_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenhNhan");

            migrationBuilder.DropTable(
                name: "Dm_PhongBan");
        }
    }
}
