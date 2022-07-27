using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_Fluxi.Migrations
{
    public partial class fluxi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "categorie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "video",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categorie_id = table.Column<int>(type: "int", nullable: false),
                    film_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video", x => x.id);
                    table.ForeignKey(
                        name: "FK_video_categorie_categorie_id",
                        column: x => x.categorie_id,
                        principalTable: "categorie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateur", x => x.id);
                    table.ForeignKey(
                        name: "FK_utilisateur_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "film",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    video_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film", x => x.id);
                    table.ForeignKey(
                        name: "FK_film_video_video_id",
                        column: x => x.video_id,
                        principalTable: "video",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "serie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    saison = table.Column<int>(type: "int", nullable: false),
                    episode = table.Column<int>(type: "int", nullable: false),
                    video_id = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_film_video_id",
                table: "film",
                column: "video_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_serie_video_id",
                table: "serie",
                column: "video_id");

            migrationBuilder.CreateIndex(
                name: "IX_utilisateur_client_id",
                table: "utilisateur",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_video_categorie_id",
                table: "video",
                column: "categorie_id");

            migrationBuilder.CreateIndex(
                name: "IX_VideoActeur_ActeurId",
                table: "VideoActeur",
                column: "ActeurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "film");

            migrationBuilder.DropTable(
                name: "serie");

            migrationBuilder.DropTable(
                name: "utilisateur");

            migrationBuilder.DropTable(
                name: "VideoActeur");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "acteur");

            migrationBuilder.DropTable(
                name: "video");

            migrationBuilder.DropTable(
                name: "categorie");
        }
    }
}
