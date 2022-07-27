using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_Fluxi.Migrations
{
    public partial class fluxi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "serie",
                newName: "url_video");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "film",
                newName: "url_video");

            migrationBuilder.AddColumn<string>(
                name: "url_image",
                table: "serie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url_image_back",
                table: "serie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url_image",
                table: "film",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url_image_back",
                table: "film",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url_image",
                table: "serie");

            migrationBuilder.DropColumn(
                name: "url_image_back",
                table: "serie");

            migrationBuilder.DropColumn(
                name: "url_image",
                table: "film");

            migrationBuilder.DropColumn(
                name: "url_image_back",
                table: "film");

            migrationBuilder.RenameColumn(
                name: "url_video",
                table: "serie",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "url_video",
                table: "film",
                newName: "url");
        }
    }
}
