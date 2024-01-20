using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class StockCardTable_AddedFielts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CabinetInformation",
                table: "StockCards",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "StockCards",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShelfInformation",
                table: "StockCards",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockUnitId",
                table: "StockCards",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CabinetInformation",
                table: "StockCards");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "StockCards");

            migrationBuilder.DropColumn(
                name: "ShelfInformation",
                table: "StockCards");

            migrationBuilder.DropColumn(
                name: "StockUnitId",
                table: "StockCards");
        }
    }
}
