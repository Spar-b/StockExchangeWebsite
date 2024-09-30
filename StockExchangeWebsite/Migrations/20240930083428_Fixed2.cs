using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockExchangeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class Fixed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Tickers_TickerId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_TickerId",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Tickers_CompanyId",
                table: "Tickers",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickers_Companies_CompanyId",
                table: "Tickers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickers_Companies_CompanyId",
                table: "Tickers");

            migrationBuilder.DropIndex(
                name: "IX_Tickers_CompanyId",
                table: "Tickers");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TickerId",
                table: "Companies",
                column: "TickerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Tickers_TickerId",
                table: "Companies",
                column: "TickerId",
                principalTable: "Tickers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
