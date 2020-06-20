using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobile_Store_MS.Data.Migrations
{
    public partial class RemovingPriorityIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderCharges_priority",
                table: "OrderCharges");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCharges_priority_order_id",
                table: "OrderCharges",
                columns: new[] { "priority", "order_id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderCharges_priority_order_id",
                table: "OrderCharges");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCharges_priority",
                table: "OrderCharges",
                column: "priority",
                unique: true);
        }
    }
}
