using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CreatingTrailerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trailer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    MovieId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trailer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trailer_Movie_MovieId1",
                        column: x => x.MovieId1,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trailer_MovieId1",
                table: "trailer",
                column: "MovieId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trailer");
        }
    }
}
