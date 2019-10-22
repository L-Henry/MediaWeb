using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Migrations
{
    public partial class playlistcombos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSeriesEpisodesPlaylist",
                table: "UserSeriesEpisodesPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPodcastPlaylist",
                table: "UserPodcastPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMusicPlaylist",
                table: "UserMusicPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMoviePlaylist",
                table: "UserMoviePlaylist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserSeriesEpisodesPlaylist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserPodcastPlaylist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserMusicPlaylist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserMoviePlaylist");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SeriesEpisodesPlaylist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PodcastPlaylist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MusicPlaylist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MoviePlaylist",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSeriesEpisodesPlaylist",
                table: "UserSeriesEpisodesPlaylist",
                columns: new[] { "SeriesEpisodeId", "SeriesEpisodesPlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPodcastPlaylist",
                table: "UserPodcastPlaylist",
                columns: new[] { "PodcastPlaylistId", "PodcastId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMusicPlaylist",
                table: "UserMusicPlaylist",
                columns: new[] { "MusicPlaylistId", "MusicId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMoviePlaylist",
                table: "UserMoviePlaylist",
                columns: new[] { "MoviePlaylistId", "MovieId" });

            migrationBuilder.CreateTable(
                name: "PodcastSerieCombo",
                columns: table => new
                {
                    PodcastId = table.Column<int>(nullable: false),
                    PodcastSerieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastSerieCombo", x => new { x.PodcastId, x.PodcastSerieId });
                    table.ForeignKey(
                        name: "FK_PodcastSerieCombo_PodcastSerie_PodcastSerieId",
                        column: x => x.PodcastSerieId,
                        principalTable: "PodcastSerie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeriesEpisodesPlaylist_UserId",
                table: "SeriesEpisodesPlaylist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastPlaylist_UserId",
                table: "PodcastPlaylist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylist_UserId",
                table: "MusicPlaylist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlaylist_UserId",
                table: "MoviePlaylist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastSerieCombo_PodcastSerieId",
                table: "PodcastSerieCombo",
                column: "PodcastSerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePlaylist_AspNetUsers_UserId",
                table: "MoviePlaylist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicPlaylist_AspNetUsers_UserId",
                table: "MusicPlaylist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PodcastPlaylist_AspNetUsers_UserId",
                table: "PodcastPlaylist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesEpisodesPlaylist_AspNetUsers_UserId",
                table: "SeriesEpisodesPlaylist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePlaylist_AspNetUsers_UserId",
                table: "MoviePlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicPlaylist_AspNetUsers_UserId",
                table: "MusicPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_PodcastPlaylist_AspNetUsers_UserId",
                table: "PodcastPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesEpisodesPlaylist_AspNetUsers_UserId",
                table: "SeriesEpisodesPlaylist");

            migrationBuilder.DropTable(
                name: "PodcastSerieCombo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSeriesEpisodesPlaylist",
                table: "UserSeriesEpisodesPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPodcastPlaylist",
                table: "UserPodcastPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMusicPlaylist",
                table: "UserMusicPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMoviePlaylist",
                table: "UserMoviePlaylist");

            migrationBuilder.DropIndex(
                name: "IX_SeriesEpisodesPlaylist_UserId",
                table: "SeriesEpisodesPlaylist");

            migrationBuilder.DropIndex(
                name: "IX_PodcastPlaylist_UserId",
                table: "PodcastPlaylist");

            migrationBuilder.DropIndex(
                name: "IX_MusicPlaylist_UserId",
                table: "MusicPlaylist");

            migrationBuilder.DropIndex(
                name: "IX_MoviePlaylist_UserId",
                table: "MoviePlaylist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SeriesEpisodesPlaylist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PodcastPlaylist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MusicPlaylist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MoviePlaylist");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserSeriesEpisodesPlaylist",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserPodcastPlaylist",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserMusicPlaylist",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserMoviePlaylist",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSeriesEpisodesPlaylist",
                table: "UserSeriesEpisodesPlaylist",
                columns: new[] { "UserId", "SeriesEpisodesPlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPodcastPlaylist",
                table: "UserPodcastPlaylist",
                columns: new[] { "PodcastPlaylistId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMusicPlaylist",
                table: "UserMusicPlaylist",
                columns: new[] { "MusicPlaylistId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMoviePlaylist",
                table: "UserMoviePlaylist",
                columns: new[] { "MoviePlaylistId", "UserId" });
        }
    }
}
