using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobile_Store_MS.Data.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_Approvedby",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Purchasings_takenBy",
                table: "Purchasings");

            migrationBuilder.DropIndex(
                name: "IX_Order_Approvedby",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Approvedby",
                table: "Order",
                newName: "TakenBy");

            migrationBuilder.AddColumn<bool>(
                name: "isactive",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Purchasings_takenBy",
                table: "Purchasings",
                column: "takenBy");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TakenBy",
                table: "Order",
                column: "TakenBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_TakenBy",
                table: "Order",
                column: "TakenBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_TakenBy",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Purchasings_takenBy",
                table: "Purchasings");

            migrationBuilder.DropIndex(
                name: "IX_Order_TakenBy",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "isactive",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TakenBy",
                table: "Order",
                newName: "Approvedby");

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
        }
    }
}
