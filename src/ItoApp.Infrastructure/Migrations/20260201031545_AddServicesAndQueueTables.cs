using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItoApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddServicesAndQueueTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Dm_DichVu_NhomDichVuId",
                table: "Dm_DichVu",
                column: "NhomDichVuId");

            migrationBuilder.CreateIndex(
                name: "IX_Dm_NhomDichVu_LoaiDichVuId",
                table: "Dm_NhomDichVu",
                column: "LoaiDichVuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dm_DichVu");

            migrationBuilder.DropTable(
                name: "STT");

            migrationBuilder.DropTable(
                name: "Dm_NhomDichVu");

            migrationBuilder.DropTable(
                name: "Dm_LoaiDichVu");
        }
    }
}


