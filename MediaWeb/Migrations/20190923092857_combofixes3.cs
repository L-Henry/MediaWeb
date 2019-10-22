using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Migrations
{
    public partial class combofixes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSeriesEpisodesPlaylist",
                table: "UserSeriesEpisodesPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPodcastPlaylist",
                table: "UserPodcastPlaylist");

            migrationBuilder.RenameTable(
                name: "UserSeriesEpisodesPlaylist",
                newName: "SeriesEpisodesPlaylistCombo");

            migrationBuilder.RenameTable(
                name: "UserPodcastPlaylist",
                newName: "PodcastPlaylistCombo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesEpisodesPlaylistCombo",
                table: "SeriesEpisodesPlaylistCombo",
                columns: new[] { "SeriesEpisodeId", "SeriesEpisodesPlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PodcastPlaylistCombo",
                table: "PodcastPlaylistCombo",
                columns: new[] { "PodcastPlaylistId", "PodcastId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesEpisodesPlaylistCombo",
                table: "SeriesEpisodesPlaylistCombo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PodcastPlaylistCombo",
                table: "PodcastPlaylistCombo");

            migrationBuilder.RenameTable(
                name: "SeriesEpisodesPlaylistCombo",
                newName: "UserSeriesEpisodesPlaylist");

            migrationBuilder.RenameTable(
                name: "PodcastPlaylistCombo",
                newName: "UserPodcastPlaylist");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSeriesEpisodesPlaylist",
                table: "UserSeriesEpisodesPlaylist",
                columns: new[] { "SeriesEpisodeId", "SeriesEpisodesPlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPodcastPlaylist",
                table: "UserPodcastPlaylist",
                columns: new[] { "PodcastPlaylistId", "PodcastId" });
        }
    }
}
