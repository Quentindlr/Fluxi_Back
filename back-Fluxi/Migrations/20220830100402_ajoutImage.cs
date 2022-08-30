using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_Fluxi.Migrations
{
    public partial class ajoutImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url_image",
                table: "film");

            migrationBuilder.DropColumn(
                name: "url_image_back",
                table: "film");

            migrationBuilder.DropColumn(
                name: "url_video",
                table: "film");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url_video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url_image_back = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    filmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.id);
                    table.ForeignKey(
                        name: "FK_Image_film_filmId",
                        column: x => x.filmId,
                        principalTable: "film",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_filmId",
                table: "Image",
                column: "filmId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

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

            migrationBuilder.AddColumn<string>(
                name: "url_video",
                table: "film",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
