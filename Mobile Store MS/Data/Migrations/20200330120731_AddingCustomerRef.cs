
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobile_Store_MS.Data.Migrations
{
    public partial class AddingCustomerRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_username",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "CustRef",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustRef",
                table: "Customer",
                column: "CustRef",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_CustRef",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustRef",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Customer",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_username",
                table: "Customer",
                column: "username",
                unique: true);
        }
    }
}
