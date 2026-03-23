using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItoApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientAccountAndOtpTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoanBenhNhan_BenhNhan_Id",
                table: "TaiKhoanBenhNhan",
                column: "BenhNhan_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log_OTP");

            migrationBuilder.DropTable(
                name: "TaiKhoanBenhNhan");
        }
    }
}


