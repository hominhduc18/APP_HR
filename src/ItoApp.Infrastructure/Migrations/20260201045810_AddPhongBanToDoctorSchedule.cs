using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItoApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPhongBanToDoctorSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhongBanId",
                table: "DoctorSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_PhongBanId",
                table: "DoctorSchedules",
                column: "PhongBanId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSchedules_Dm_PhongBan_PhongBanId",
                table: "DoctorSchedules",
                column: "PhongBanId",
                principalTable: "Dm_PhongBan",
                principalColumn: "PhongBanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSchedules_Dm_PhongBan_PhongBanId",
                table: "DoctorSchedules");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSchedules_PhongBanId",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "PhongBanId",
                table: "DoctorSchedules");
        }
    }
}
