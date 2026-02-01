using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItoApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMissingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DichVuId",
                table: "DoctorSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhomDichVuId",
                table: "DoctorSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DichVuId",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "NhomDichVuId",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Doctors");
        }
    }
}
