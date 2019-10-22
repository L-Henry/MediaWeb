using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Migrations
{
    public partial class combofixes5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSerieGezienStatus",
                table: "UserSerieGezienStatus");

            migrationBuilder.RenameColumn(
                name: "SerieGezienStatus",
                table: "UserSerieGezienStatus",
                newName: "SerieGezienStatusId");

            migrationBuilder.RenameColumn(
                name: "Beschijving",
                table: "SeriesEpisodes",
                newName: "Beschrijving");

            migrationBuilder.AddColumn<int>(
                name: "SerieGezienStatusId",
                table: "UserSeriesEpisodesGezienStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Zichtbaar",
                table: "SerieRatingReview",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSerieGezienStatus",
                table: "UserSerieGezienStatus",
                columns: new[] { "SerieId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSerieGezienStatus",
                table: "UserSerieGezienStatus");

            migrationBuilder.DropColumn(
                name: "SerieGezienStatusId",
                table: "UserSeriesEpisodesGezienStatus");

            migrationBuilder.DropColumn(
                name: "Zichtbaar",
                table: "SerieRatingReview");

            migrationBuilder.RenameColumn(
                name: "SerieGezienStatusId",
                table: "UserSerieGezienStatus",
                newName: "SerieGezienStatus");

            migrationBuilder.RenameColumn(
                name: "Beschrijving",
                table: "SeriesEpisodes",
                newName: "Beschijving");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSerieGezienStatus",
                table: "UserSerieGezienStatus",
                columns: new[] { "SerieGezienStatus", "UserId" });
        }
    }
}
