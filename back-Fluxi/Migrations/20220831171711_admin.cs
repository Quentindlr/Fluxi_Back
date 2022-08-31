using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_Fluxi.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.AddColumn<string>(
                name: "url_image",
                table: "video",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url_image_back",
                table: "video",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url_video",
                table: "video",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url_image",
                table: "video");

            migrationBuilder.DropColumn(
                name: "url_image_back",
                table: "video");

            migrationBuilder.DropColumn(
                name: "url_video",
                table: "video");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filmId = table.Column<int>(type: "int", nullable: false),
                    url_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url_image_back = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url_video = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.id);
                    table.ForeignKey(
                        name: "FK_Image_video_filmId",
                        column: x => x.filmId,
                        principalTable: "video",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_filmId",
                table: "Image",
                column: "filmId",
                unique: true);
        }
    }
}
