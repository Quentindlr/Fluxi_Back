using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_Fluxi.Migrations
{
    public partial class testvideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "url_video",
                table: "Image",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url_video",
                table: "Image");
        }
    }
}
