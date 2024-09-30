using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockExchangeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockMarkets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClosingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TradingDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Liquidity = table.Column<double>(type: "float", nullable: false),
                    TransactionFee = table.Column<double>(type: "float", nullable: false),
                    TickSize = table.Column<double>(type: "float", nullable: false),
                    MarketCapitalization = table.Column<double>(type: "float", nullable: false),
                    SupportedOrderTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SettlementPeriod = table.Column<int>(type: "int", nullable: false),
                    Volatility = table.Column<float>(type: "real", nullable: false),
                    MarketIndex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumOrderSize = table.Column<int>(type: "int", nullable: false),
                    RegulatoryAuthority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketDepth = table.Column<int>(type: "int", nullable: false),
                    AllowsShortSelling = table.Column<bool>(type: "bit", nullable: false),
                    HasCircuitBreakers = table.Column<bool>(type: "bit", nullable: false),
                    CircuitBreakerThreshold = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMarkets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentValue = table.Column<double>(type: "float", nullable: false),
                    OpenValue = table.Column<double>(type: "float", nullable: false),
                    CloseValue = table.Column<double>(type: "float", nullable: false),
                    TradingVolume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumWorkers = table.Column<int>(type: "int", nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RegistrationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sector = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TickerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Tickers_TickerId",
                        column: x => x.TickerId,
                        principalTable: "Tickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockMarketTickers",
                columns: table => new
                {
                    StockMarketId = table.Column<int>(type: "int", nullable: false),
                    TickerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMarketTickers", x => new { x.StockMarketId, x.TickerId });
                    table.ForeignKey(
                        name: "FK_StockMarketTickers_StockMarkets_StockMarketId",
                        column: x => x.StockMarketId,
                        principalTable: "StockMarkets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockMarketTickers_Tickers_TickerId",
                        column: x => x.TickerId,
                        principalTable: "Tickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TickerId",
                table: "Companies",
                column: "TickerId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMarketTickers_TickerId",
                table: "StockMarketTickers",
                column: "TickerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "StockMarketTickers");

            migrationBuilder.DropTable(
                name: "StockMarkets");

            migrationBuilder.DropTable(
                name: "Tickers");
        }
    }
}
