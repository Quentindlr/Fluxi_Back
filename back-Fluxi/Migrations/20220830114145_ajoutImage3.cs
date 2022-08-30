using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_Fluxi.Migrations
{
    public partial class ajoutImage3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoActeur");

            migrationBuilder.DropTable(
                name: "acteur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acteur",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acteur", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VideoActeur",
                columns: table => new
                {
                    VideoID = table.Column<int>(type: "int", nullable: false),
                    ActeurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoActeur", x => new { x.VideoID, x.ActeurId });
                    table.ForeignKey(
                        name: "FK_VideoActeur_acteur_ActeurId",
                        column: x => x.ActeurId,
                        principalTable: "acteur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoActeur_video_VideoID",
                        column: x => x.VideoID,
                        principalTable: "video",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoActeur_ActeurId",
                table: "VideoActeur",
                column: "ActeurId");
        }
    }
}
