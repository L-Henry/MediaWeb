using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Migrations
{
    public partial class playlists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publiek",
                table: "SeriesEpisodesPlaylistCombo");

            migrationBuilder.DropColumn(
                name: "Zichtbaar",
                table: "SeriesEpisodesPlaylistCombo");

            migrationBuilder.DropColumn(
                name: "Publiek",
                table: "MusicPlaylistCombo");

            migrationBuilder.DropColumn(
                name: "Zichtbaar",
                table: "MusicPlaylistCombo");

            migrationBuilder.DropColumn(
                name: "Publiek",
                table: "MoviePlaylistCombo");

            migrationBuilder.DropColumn(
                name: "Zichtbaar",
                table: "MoviePlaylistCombo");

            migrationBuilder.AddColumn<bool>(
                name: "Publiek",
                table: "SeriesEpisodesPlaylist",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Zichtbaar",
                table: "SeriesEpisodesPlaylist",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Publiek",
                table: "MusicPlaylist",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Zichtbaar",
                table: "MusicPlaylist",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Publiek",
                table: "MoviePlaylist",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Zichtbaar",
                table: "MoviePlaylist",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieGezienStatus_MovieGezienStatusId",
                table: "UserMovieGezienStatus",
                column: "MovieGezienStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieGezienStatus_UserId",
                table: "UserMovieGezienStatus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieFav_UserId",
                table: "UserMovieFav",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRatingReview_UserId",
                table: "MovieRatingReview",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRatingReview_AspNetUsers_UserId",
                table: "MovieRatingReview",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieFav_AspNetUsers_UserId",
                table: "UserMovieFav",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieGezienStatus_MovieGezienStatus_MovieGezienStatusId",
                table: "UserMovieGezienStatus",
                column: "MovieGezienStatusId",
                principalTable: "MovieGezienStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieGezienStatus_AspNetUsers_UserId",
                table: "UserMovieGezienStatus",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRatingReview_AspNetUsers_UserId",
                table: "MovieRatingReview");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieFav_AspNetUsers_UserId",
                table: "UserMovieFav");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieGezienStatus_MovieGezienStatus_MovieGezienStatusId",
                table: "UserMovieGezienStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieGezienStatus_AspNetUsers_UserId",
                table: "UserMovieGezienStatus");

            migrationBuilder.DropIndex(
                name: "IX_UserMovieGezienStatus_MovieGezienStatusId",
                table: "UserMovieGezienStatus");

            migrationBuilder.DropIndex(
                name: "IX_UserMovieGezienStatus_UserId",
                table: "UserMovieGezienStatus");

            migrationBuilder.DropIndex(
                name: "IX_UserMovieFav_UserId",
                table: "UserMovieFav");

            migrationBuilder.DropIndex(
                name: "IX_MovieRatingReview_UserId",
                table: "MovieRatingReview");

            migrationBuilder.DropColumn(
                name: "Publiek",
                table: "SeriesEpisodesPlaylist");

            migrationBuilder.DropColumn(
                name: "Zichtbaar",
                table: "SeriesEpisodesPlaylist");

            migrationBuilder.DropColumn(
                name: "Publiek",
                table: "MusicPlaylist");

            migrationBuilder.DropColumn(
                name: "Zichtbaar",
                table: "MusicPlaylist");

            migrationBuilder.DropColumn(
                name: "Publiek",
                table: "MoviePlaylist");

            migrationBuilder.DropColumn(
                name: "Zichtbaar",
                table: "MoviePlaylist");

            migrationBuilder.AddColumn<bool>(
                name: "Publiek",
                table: "SeriesEpisodesPlaylistCombo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Zichtbaar",
                table: "SeriesEpisodesPlaylistCombo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Publiek",
                table: "MusicPlaylistCombo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Zichtbaar",
                table: "MusicPlaylistCombo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Publiek",
                table: "MoviePlaylistCombo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Zichtbaar",
                table: "MoviePlaylistCombo",
                nullable: false,
                defaultValue: false);
        }
    }
}
