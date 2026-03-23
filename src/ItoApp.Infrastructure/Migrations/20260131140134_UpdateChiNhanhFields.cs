using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItoApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChiNhanhFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaChiNhanh",
                table: "ChiNhanh",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaSoThue",
                table: "ChiNhanh",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaChiNhanh",
                table: "ChiNhanh");

            migrationBuilder.DropColumn(
                name: "MaSoThue",
                table: "ChiNhanh");
        }
    }
}


