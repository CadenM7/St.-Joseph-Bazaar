using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StJosephBazaar.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StartupTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Startup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BoothName = table.Column<string>(type: "TEXT", nullable: true),
                    Twenties = table.Column<int>(type: "INTEGER", nullable: false),
                    Tens = table.Column<int>(type: "INTEGER", nullable: false),
                    Fives = table.Column<int>(type: "INTEGER", nullable: false),
                    Ones = table.Column<int>(type: "INTEGER", nullable: false),
                    Quarters = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Startup", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booth");

            migrationBuilder.DropTable(
                name: "Startup");
        }
    }
}
