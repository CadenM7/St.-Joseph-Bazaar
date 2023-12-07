using System;
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
                name: "Deposit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Checks = table.Column<decimal>(type: "TEXT", nullable: false),
                    Twentys = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tens = table.Column<decimal>(type: "TEXT", nullable: false),
                    Fives = table.Column<decimal>(type: "TEXT", nullable: false),
                    Ones = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quarters = table.Column<decimal>(type: "TEXT", nullable: false),
                    Dimes = table.Column<decimal>(type: "TEXT", nullable: false),
                    Nickels = table.Column<decimal>(type: "TEXT", nullable: false),
                    Pennies = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.ID);
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

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YearVal = table.Column<string>(type: "TEXT", nullable: false),
                    Friday = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Saturday = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Booth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YearID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Friday = table.Column<decimal>(type: "TEXT", nullable: false),
                    Saturday = table.Column<decimal>(type: "TEXT", nullable: false),
                    Auction = table.Column<decimal>(type: "TEXT", nullable: false),
                    Purchases = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booth_Year_YearID",
                        column: x => x.YearID,
                        principalTable: "Year",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BoothID = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Total = table.Column<double>(type: "REAL", nullable: false),
                    InvoiceNum = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckNum = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Expense_Booth_BoothID",
                        column: x => x.BoothID,
                        principalTable: "Booth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BoothID = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    HourCollected = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false),
                    RecieptNum = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Income_Booth_BoothID",
                        column: x => x.BoothID,
                        principalTable: "Booth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booth_YearID",
                table: "Booth",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_BoothID",
                table: "Expense",
                column: "BoothID");

            migrationBuilder.CreateIndex(
                name: "IX_Income_BoothID",
                table: "Income",
                column: "BoothID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "Startup");

            migrationBuilder.DropTable(
                name: "Booth");

            migrationBuilder.DropTable(
                name: "Year");
        }
    }
}
