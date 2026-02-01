using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItoApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingHREntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChungChiDaoTaos_NhanVien_NhanVienId",
                table: "ChungChiDaoTaos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChungChiDaoTaos",
                table: "ChungChiDaoTaos");

            migrationBuilder.RenameTable(
                name: "ChungChiDaoTaos",
                newName: "ChungChiDaoTao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ChungChiDaoTao",
                newName: "Id_ChungChiDaoTao");

            migrationBuilder.RenameIndex(
                name: "IX_ChungChiDaoTaos_NhanVienId",
                table: "ChungChiDaoTao",
                newName: "IX_ChungChiDaoTao_NhanVienId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChungChiDaoTao",
                table: "ChungChiDaoTao",
                column: "Id_ChungChiDaoTao");

            migrationBuilder.CreateTable(
                name: "KyLuat",
                columns: table => new
                {
                    Id_KyLuat = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayViPham = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayQuyetDinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nodung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id_KyThuat = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKyThuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayPheDuyet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id_LichSu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThaoTac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiThucHien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuLieuCu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuLieuMoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_KyLuat_NhanVienId",
                table: "KyLuat",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_KyThuatChuyenMon_NhanVienId",
                table: "KyThuatChuyenMon",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuChinhSua_NhanVienId",
                table: "LichSuChinhSua",
                column: "NhanVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChungChiDaoTao_NhanVien_NhanVienId",
                table: "ChungChiDaoTao",
                column: "NhanVienId",
                principalTable: "NhanVien",
                principalColumn: "Id_NhanVien",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChungChiDaoTao_NhanVien_NhanVienId",
                table: "ChungChiDaoTao");

            migrationBuilder.DropTable(
                name: "KyLuat");

            migrationBuilder.DropTable(
                name: "KyThuatChuyenMon");

            migrationBuilder.DropTable(
                name: "LichSuChinhSua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChungChiDaoTao",
                table: "ChungChiDaoTao");

            migrationBuilder.RenameTable(
                name: "ChungChiDaoTao",
                newName: "ChungChiDaoTaos");

            migrationBuilder.RenameColumn(
                name: "Id_ChungChiDaoTao",
                table: "ChungChiDaoTaos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ChungChiDaoTao_NhanVienId",
                table: "ChungChiDaoTaos",
                newName: "IX_ChungChiDaoTaos_NhanVienId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChungChiDaoTaos",
                table: "ChungChiDaoTaos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChungChiDaoTaos_NhanVien_NhanVienId",
                table: "ChungChiDaoTaos",
                column: "NhanVienId",
                principalTable: "NhanVien",
                principalColumn: "Id_NhanVien",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
