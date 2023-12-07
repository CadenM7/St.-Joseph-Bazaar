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
                    YearID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YearVal = table.Column<int>(type: "INTEGER", nullable: false),
                    Friday = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Saturday = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.YearID);
                });

            migrationBuilder.CreateTable(
                name: "Booth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Friday = table.Column<decimal>(type: "TEXT", nullable: false),
                    YearID = table.Column<int>(type: "INTEGER", nullable: false),
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
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comparison",
                columns: table => new
                {
                    ComparisonID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YearInitYearID = table.Column<int>(type: "INTEGER", nullable: false),
                    YearCompYearID = table.Column<int>(type: "INTEGER", nullable: false),
                    InitID = table.Column<int>(type: "INTEGER", nullable: false),
                    CompID = table.Column<int>(type: "INTEGER", nullable: false),
                    YIAdvance = table.Column<decimal>(type: "TEXT", nullable: false),
                    YCAdvance = table.Column<decimal>(type: "TEXT", nullable: false),
                    AdvanceVariance = table.Column<decimal>(type: "TEXT", nullable: false),
                    YIFriday = table.Column<decimal>(type: "TEXT", nullable: false),
                    YCFriday = table.Column<decimal>(type: "TEXT", nullable: false),
                    FridayVariance = table.Column<decimal>(type: "TEXT", nullable: false),
                    YISaturday = table.Column<decimal>(type: "TEXT", nullable: false),
                    YCSaturday = table.Column<decimal>(type: "TEXT", nullable: false),
                    SaturdayVariance = table.Column<decimal>(type: "TEXT", nullable: false),
                    YIAuct = table.Column<decimal>(type: "TEXT", nullable: false),
                    YCAuct = table.Column<decimal>(type: "TEXT", nullable: false),
                    AuctionVariance = table.Column<decimal>(type: "TEXT", nullable: false),
                    YINetIncome = table.Column<decimal>(type: "TEXT", nullable: false),
                    YCNetIncome = table.Column<decimal>(type: "TEXT", nullable: false),
                    NetVariance = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comparison", x => x.ComparisonID);
                    table.ForeignKey(
                        name: "FK_Comparison_Year_YearCompYearID",
                        column: x => x.YearCompYearID,
                        principalTable: "Year",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comparison_Year_YearInitYearID",
                        column: x => x.YearInitYearID,
                        principalTable: "Year",
                        principalColumn: "YearID",
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
                name: "IX_Comparison_YearCompYearID",
                table: "Comparison",
                column: "YearCompYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Comparison_YearInitYearID",
                table: "Comparison",
                column: "YearInitYearID");

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
                name: "Comparison");

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
