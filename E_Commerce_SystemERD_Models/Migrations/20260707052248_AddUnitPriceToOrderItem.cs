using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_SystemERD_Models.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitPriceToOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "unitPrice",
                table: "OrderItems",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unitPrice",
                table: "OrderItems");
        }
    }
}
