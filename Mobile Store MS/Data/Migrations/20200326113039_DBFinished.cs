using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobile_Store_MS.Data.Migrations
{
    public partial class DBFinished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "BrandModel",
                columns: table => new
                {
                    modelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    model_name = table.Column<string>(nullable: false),
                    mob_type = table.Column<int>(nullable: false),
                    RAM = table.Column<string>(nullable: false),
                    internal_storage = table.Column<string>(nullable: false),
                    Display = table.Column<string>(nullable: false),
                    Front_Cam = table.Column<string>(nullable: true),
                    back_cam = table.Column<string>(nullable: true),
                    front_flash = table.Column<bool>(nullable: false),
                    FingerPrint = table.Column<bool>(nullable: false),
                    SimType = table.Column<string>(nullable: false),
                    Networktype = table.Column<string>(nullable: true),
                    Battery = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PhoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandModel", x => x.modelId);
                    table.ForeignKey(
                        name: "FK_BrandModel_CompanyModel_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "CompanyModel",
                        principalColumn: "Phoneid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    cus_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cus_name = table.Column<string>(nullable: false),
                    cus_phone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.cus_id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    ven_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ven_name = table.Column<string>(nullable: false),
                    ven_phone = table.Column<long>(nullable: false),
                    PhoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.ven_id);
                    table.ForeignKey(
                        name: "FK_Vendor_CompanyModel_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "CompanyModel",
                        principalColumn: "Phoneid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    imageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image_Path = table.Column<string>(nullable: true),
                    modelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.imageId);
                    table.ForeignKey(
                        name: "FK_Images_BrandModel_modelId",
                        column: x => x.modelId,
                        principalTable: "BrandModel",
                        principalColumn: "modelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    modelId = table.Column<int>(nullable: false),
                    cus_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_cus_id",
                        column: x => x.cus_id,
                        principalTable: "Customer",
                        principalColumn: "cus_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_BrandModel_modelId",
                        column: x => x.modelId,
                        principalTable: "BrandModel",
                        principalColumn: "modelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchasings",
                columns: table => new
                {
                    purchase_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    modelId = table.Column<int>(nullable: false),
                    vendor_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchasings", x => x.purchase_id);
                    table.ForeignKey(
                        name: "FK_Purchasings_BrandModel_modelId",
                        column: x => x.modelId,
                        principalTable: "BrandModel",
                        principalColumn: "modelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchasings_Vendor_vendor_id",
                        column: x => x.vendor_id,
                        principalTable: "Vendor",
                        principalColumn: "ven_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandModel_PhoneId",
                table: "BrandModel",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_modelId",
                table: "Images",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_cus_id",
                table: "Order",
                column: "cus_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_modelId",
                table: "Order",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasings_modelId",
                table: "Purchasings",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasings_vendor_id",
                table: "Purchasings",
                column: "vendor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_PhoneId",
                table: "Vendor",
                column: "PhoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Purchasings");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "BrandModel");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
