using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Migrations
{
    public partial class combofixes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreSerieCombo_SeriesEpisodes_SeriesEpisodesId",
                table: "GenreSerieCombo");

            migrationBuilder.DropIndex(
                name: "IX_GenreSerieCombo_SeriesEpisodesId",
                table: "GenreSerieCombo");

            migrationBuilder.DropColumn(
                name: "SeriesEpisodesId",
                table: "GenreSerieCombo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeriesEpisodesId",
                table: "GenreSerieCombo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenreSerieCombo_SeriesEpisodesId",
                table: "GenreSerieCombo",
                column: "SeriesEpisodesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreSerieCombo_SeriesEpisodes_SeriesEpisodesId",
                table: "GenreSerieCombo",
                column: "SeriesEpisodesId",
                principalTable: "SeriesEpisodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
