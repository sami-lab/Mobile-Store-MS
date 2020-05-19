using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobile_Store_MS.Data.Migrations
{
    public partial class addingModelField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Com_name",
                table: "CompanyModel",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Android",
                table: "BrandModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyModel_Com_name",
                table: "CompanyModel",
                column: "Com_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompanyModel_Com_name",
                table: "CompanyModel");

            migrationBuilder.DropColumn(
                name: "Android",
                table: "BrandModel");

            migrationBuilder.AlterColumn<string>(
                name: "Com_name",
                table: "CompanyModel",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
