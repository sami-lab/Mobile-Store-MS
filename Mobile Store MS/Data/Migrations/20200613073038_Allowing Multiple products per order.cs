using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobile_Store_MS.Data.Migrations
{
    public partial class AllowingMultipleproductsperorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_BrandModel_modelId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_modelId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "modelId",
                table: "Order");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    modelId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    order_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_BrandModel_modelId",
                        column: x => x.modelId,
                        principalTable: "BrandModel",
                        principalColumn: "modelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Order_order_id",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_modelId",
                table: "Products",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_order_id",
                table: "Products",
                column: "order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "modelId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_modelId",
                table: "Order",
                column: "modelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_BrandModel_modelId",
                table: "Order",
                column: "modelId",
                principalTable: "BrandModel",
                principalColumn: "modelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
