using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobile_Store_MS.Data.Migrations
{
    public partial class AddingApprovedByField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "takenBy",
                table: "Purchasings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Approvedby",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchasings_takenBy",
                table: "Purchasings",
                column: "takenBy",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Approvedby",
                table: "Order",
                column: "Approvedby",
                unique: true,
                filter: "[Approvedby] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_Approvedby",
                table: "Order",
                column: "Approvedby",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasings_AspNetUsers_takenBy",
                table: "Purchasings",
                column: "takenBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_Approvedby",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchasings_AspNetUsers_takenBy",
                table: "Purchasings");

            migrationBuilder.DropIndex(
                name: "IX_Purchasings_takenBy",
                table: "Purchasings");

            migrationBuilder.DropIndex(
                name: "IX_Order_Approvedby",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "takenBy",
                table: "Purchasings");

            migrationBuilder.DropColumn(
                name: "Approvedby",
                table: "Order");
        }
    }
}
