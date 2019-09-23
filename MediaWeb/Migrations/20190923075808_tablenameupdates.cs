using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Migrations
{
    public partial class tablenameupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMusicGenre");

            migrationBuilder.DropTable(
                name: "GenreSerieGenre");

            migrationBuilder.DropTable(
                name: "PodcastOnderwerpPodcast");

            migrationBuilder.CreateTable(
                name: "GenreMusicCombo",
                columns: table => new
                {
                    MusicId = table.Column<int>(nullable: false),
                    MusicGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMusicCombo", x => new { x.MusicId, x.MusicGenreId });
                    table.ForeignKey(
                        name: "FK_GenreMusicCombo_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreSerieCombo",
                columns: table => new
                {
                    SerieId = table.Column<int>(nullable: false),
                    SerieGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSerieCombo", x => new { x.SerieId, x.SerieGenreId });
                    table.ForeignKey(
                        name: "FK_GenreSerieCombo_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastOnderwerpCombo",
                columns: table => new
                {
                    PodcastId = table.Column<int>(nullable: false),
                    PodcastOnderwerpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastOnderwerpCombo", x => new { x.PodcastId, x.PodcastOnderwerpId });
                    table.ForeignKey(
                        name: "FK_PodcastOnderwerpCombo_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMusicCombo");

            migrationBuilder.DropTable(
                name: "GenreSerieCombo");

            migrationBuilder.DropTable(
                name: "PodcastOnderwerpCombo");

            migrationBuilder.CreateTable(
                name: "GenreMusicGenre",
                columns: table => new
                {
                    MusicId = table.Column<int>(nullable: false),
                    MusicGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMusicGenre", x => new { x.MusicId, x.MusicGenreId });
                    table.ForeignKey(
                        name: "FK_GenreMusicGenre_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreSerieGenre",
                columns: table => new
                {
                    SerieId = table.Column<int>(nullable: false),
                    SerieGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSerieGenre", x => new { x.SerieId, x.SerieGenreId });
                    table.ForeignKey(
                        name: "FK_GenreSerieGenre_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastOnderwerpPodcast",
                columns: table => new
                {
                    PodcastId = table.Column<int>(nullable: false),
                    PodcastOnderwerpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastOnderwerpPodcast", x => new { x.PodcastId, x.PodcastOnderwerpId });
                    table.ForeignKey(
                        name: "FK_PodcastOnderwerpPodcast_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
