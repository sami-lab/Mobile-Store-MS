using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobile_Store_MS.Data.Migrations
{
    public partial class AddingMultipleStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BrandModel");

            migrationBuilder.AddColumn<int>(
                name: "store_id",
                table: "Purchasings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "store_id",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "store_id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StoreName = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    City = table.Column<int>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Ref_No = table.Column<int>(nullable: false),
                    SupportNo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.store_id);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    modelId = table.Column<int>(nullable: false),
                    store_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.id);
                    table.ForeignKey(
                        name: "FK_Stock_BrandModel_modelId",
                        column: x => x.modelId,
                        principalTable: "BrandModel",
                        principalColumn: "modelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Stores_store_id",
                        column: x => x.store_id,
                        principalTable: "Stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchasings_store_id",
                table: "Purchasings",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_store_id",
                table: "Order",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_store_id",
                table: "AspNetUsers",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_modelId",
                table: "Stock",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_store_id",
                table: "Stock",
                column: "store_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stores_store_id",
                table: "AspNetUsers",
                column: "store_id",
                principalTable: "Stores",
                principalColumn: "store_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Stores_store_id",
                table: "Order",
                column: "store_id",
                principalTable: "Stores",
                principalColumn: "store_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasings_Stores_store_id",
                table: "Purchasings",
                column: "store_id",
                principalTable: "Stores",
                principalColumn: "store_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stores_store_id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Stores_store_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchasings_Stores_store_id",
                table: "Purchasings");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Purchasings_store_id",
                table: "Purchasings");

            migrationBuilder.DropIndex(
                name: "IX_Order_store_id",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_store_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "store_id",
                table: "Purchasings");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "store_id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "store_id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BrandModel",
                nullable: false,
                defaultValue: 0);
        }
    }
}
