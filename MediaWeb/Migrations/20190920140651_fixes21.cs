using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Migrations
{
    public partial class fixes21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRegisseur_Movies_MovieId",
                table: "MovieRegisseur");

            migrationBuilder.DropIndex(
                name: "IX_MovieRegisseur_MovieId",
                table: "MovieRegisseur");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MovieRegisseur");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRegisseurCombo_Movies_MovieId",
                table: "MovieRegisseurCombo",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRegisseurCombo_Movies_MovieId",
                table: "MovieRegisseurCombo");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "MovieRegisseur",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieRegisseur_MovieId",
                table: "MovieRegisseur",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRegisseur_Movies_MovieId",
                table: "MovieRegisseur",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
