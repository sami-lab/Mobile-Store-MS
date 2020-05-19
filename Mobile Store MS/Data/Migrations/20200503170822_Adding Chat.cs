using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobile_Store_MS.Data.Migrations
{
    public partial class AddingChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_AspNetUsers_UserId",
                table: "message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_message",
                table: "message");

            migrationBuilder.RenameTable(
                name: "message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_message_UserId",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "message");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "message",
                newName: "IX_message_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_message",
                table: "message",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_message_AspNetUsers_UserId",
                table: "message",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
