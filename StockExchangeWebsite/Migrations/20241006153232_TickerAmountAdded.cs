﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockExchangeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class TickerAmountAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "UserTickers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "UserTickers");
        }
    }
}
