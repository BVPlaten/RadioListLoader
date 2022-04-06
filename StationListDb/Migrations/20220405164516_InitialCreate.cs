using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationListDb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryName = table.Column<string>(type: "TEXT", nullable: true),
                    MainUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RawHtmlData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawHtmlData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StreamUrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StreamUrl_RawHtmlData_StationId",
                        column: x => x.StationId,
                        principalTable: "RawHtmlData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StreamUrl_StationId",
                table: "StreamUrl",
                column: "StationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryStations");

            migrationBuilder.DropTable(
                name: "StreamUrl");

            migrationBuilder.DropTable(
                name: "RawHtmlData");
        }
    }
}
