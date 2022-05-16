using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatingTrailerTableNameToUpperCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trailer_Movie_MovieId1",
                table: "trailer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trailer",
                table: "trailer");

            migrationBuilder.RenameTable(
                name: "trailer",
                newName: "Trailer");

            migrationBuilder.RenameIndex(
                name: "IX_trailer_MovieId1",
                table: "Trailer",
                newName: "IX_Trailer_MovieId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trailer",
                table: "Trailer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trailer_Movie_MovieId1",
                table: "Trailer",
                column: "MovieId1",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trailer_Movie_MovieId1",
                table: "Trailer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trailer",
                table: "Trailer");

            migrationBuilder.RenameTable(
                name: "Trailer",
                newName: "trailer");

            migrationBuilder.RenameIndex(
                name: "IX_Trailer_MovieId1",
                table: "trailer",
                newName: "IX_trailer_MovieId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trailer",
                table: "trailer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_trailer_Movie_MovieId1",
                table: "trailer",
                column: "MovieId1",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
