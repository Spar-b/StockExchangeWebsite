using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockExchangeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_TickerId",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Tickers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TickerId",
                table: "Companies",
                column: "TickerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_TickerId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Tickers");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TickerId",
                table: "Companies",
                column: "TickerId");
        }
    }
}
