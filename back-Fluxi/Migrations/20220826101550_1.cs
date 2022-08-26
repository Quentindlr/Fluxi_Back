using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_Fluxi.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "utilisateur");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "client");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "utilisateur",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
