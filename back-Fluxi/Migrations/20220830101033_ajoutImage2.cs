using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_Fluxi.Migrations
{
    public partial class ajoutImage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_film_filmId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_video_film_film_id",
                table: "video");

            migrationBuilder.DropTable(
                name: "film");

            migrationBuilder.DropTable(
                name: "serie");

            migrationBuilder.DropIndex(
                name: "IX_video_film_id",
                table: "video");

            migrationBuilder.DropColumn(
                name: "film_id",
                table: "video");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_video_filmId",
                table: "Image",
                column: "filmId",
                principalTable: "video",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_video_filmId",
                table: "Image");

            migrationBuilder.AddColumn<int>(
                name: "film_id",
                table: "video",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "film",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    video_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "serie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    video_id = table.Column<int>(type: "int", nullable: false),
                    episode = table.Column<int>(type: "int", nullable: false),
                    saison = table.Column<int>(type: "int", nullable: false),
                    url_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url_image_back = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url_video = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serie", x => x.id);
                    table.ForeignKey(
                        name: "FK_serie_video_video_id",
                        column: x => x.video_id,
                        principalTable: "video",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_video_film_id",
                table: "video",
                column: "film_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_serie_video_id",
                table: "serie",
                column: "video_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_film_filmId",
                table: "Image",
                column: "filmId",
                principalTable: "film",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_video_film_film_id",
                table: "video",
                column: "film_id",
                principalTable: "film",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
