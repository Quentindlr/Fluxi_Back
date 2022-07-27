using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_Fluxi.Migrations
{
    public partial class fluxi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_video_video_id",
                table: "film");

            migrationBuilder.DropIndex(
                name: "IX_film_video_id",
                table: "film");

            migrationBuilder.CreateIndex(
                name: "IX_video_film_id",
                table: "video",
                column: "film_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_video_film_film_id",
                table: "video",
                column: "film_id",
                principalTable: "film",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_video_film_film_id",
                table: "video");

            migrationBuilder.DropIndex(
                name: "IX_video_film_id",
                table: "video");

            migrationBuilder.CreateIndex(
                name: "IX_film_video_id",
                table: "film",
                column: "video_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_film_video_video_id",
                table: "film",
                column: "video_id",
                principalTable: "video",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
