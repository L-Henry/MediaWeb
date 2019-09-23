using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Migrations
{
    public partial class combofixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeriesEpisodes_Serie_SerieId",
                table: "SeriesEpisodes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMoviePlaylist_Movies_MovieId",
                table: "UserMoviePlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMusicPlaylist_Music_MusicId",
                table: "UserMusicPlaylist");

            migrationBuilder.DropIndex(
                name: "IX_SeriesEpisodes_SerieId",
                table: "SeriesEpisodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMusicPlaylist",
                table: "UserMusicPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMoviePlaylist",
                table: "UserMoviePlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesEpisodesInSeries",
                table: "SeriesEpisodesInSeries");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "SeriesEpisodes");

            migrationBuilder.RenameTable(
                name: "UserMusicPlaylist",
                newName: "MusicPlaylistCombo");

            migrationBuilder.RenameTable(
                name: "UserMoviePlaylist",
                newName: "MoviePlaylistCombo");

            migrationBuilder.RenameTable(
                name: "SeriesEpisodesInSeries",
                newName: "SeriesEpisodesCombo");

            migrationBuilder.RenameIndex(
                name: "IX_UserMusicPlaylist_MusicId",
                table: "MusicPlaylistCombo",
                newName: "IX_MusicPlaylistCombo_MusicId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMoviePlaylist_MovieId",
                table: "MoviePlaylistCombo",
                newName: "IX_MoviePlaylistCombo_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicPlaylistCombo",
                table: "MusicPlaylistCombo",
                columns: new[] { "MusicPlaylistId", "MusicId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviePlaylistCombo",
                table: "MoviePlaylistCombo",
                columns: new[] { "MoviePlaylistId", "MovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesEpisodesCombo",
                table: "SeriesEpisodesCombo",
                columns: new[] { "SerieId", "SeriesEpisodeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePlaylistCombo_Movies_MovieId",
                table: "MoviePlaylistCombo",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicPlaylistCombo_Music_MusicId",
                table: "MusicPlaylistCombo",
                column: "MusicId",
                principalTable: "Music",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesEpisodesCombo_Serie_SerieId",
                table: "SeriesEpisodesCombo",
                column: "SerieId",
                principalTable: "Serie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePlaylistCombo_Movies_MovieId",
                table: "MoviePlaylistCombo");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicPlaylistCombo_Music_MusicId",
                table: "MusicPlaylistCombo");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesEpisodesCombo_Serie_SerieId",
                table: "SeriesEpisodesCombo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesEpisodesCombo",
                table: "SeriesEpisodesCombo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicPlaylistCombo",
                table: "MusicPlaylistCombo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviePlaylistCombo",
                table: "MoviePlaylistCombo");

            migrationBuilder.RenameTable(
                name: "SeriesEpisodesCombo",
                newName: "SeriesEpisodesInSeries");

            migrationBuilder.RenameTable(
                name: "MusicPlaylistCombo",
                newName: "UserMusicPlaylist");

            migrationBuilder.RenameTable(
                name: "MoviePlaylistCombo",
                newName: "UserMoviePlaylist");

            migrationBuilder.RenameIndex(
                name: "IX_MusicPlaylistCombo_MusicId",
                table: "UserMusicPlaylist",
                newName: "IX_UserMusicPlaylist_MusicId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviePlaylistCombo_MovieId",
                table: "UserMoviePlaylist",
                newName: "IX_UserMoviePlaylist_MovieId");

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "SeriesEpisodes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesEpisodesInSeries",
                table: "SeriesEpisodesInSeries",
                columns: new[] { "SerieId", "SeriesEpisodeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMusicPlaylist",
                table: "UserMusicPlaylist",
                columns: new[] { "MusicPlaylistId", "MusicId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMoviePlaylist",
                table: "UserMoviePlaylist",
                columns: new[] { "MoviePlaylistId", "MovieId" });

            migrationBuilder.CreateIndex(
                name: "IX_SeriesEpisodes_SerieId",
                table: "SeriesEpisodes",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesEpisodes_Serie_SerieId",
                table: "SeriesEpisodes",
                column: "SerieId",
                principalTable: "Serie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMoviePlaylist_Movies_MovieId",
                table: "UserMoviePlaylist",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMusicPlaylist_Music_MusicId",
                table: "UserMusicPlaylist",
                column: "MusicId",
                principalTable: "Music",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
