using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Graduate_UserId",
                table: "Graduate");

            migrationBuilder.CreateIndex(
                name: "IX_Graduate_UserId",
                table: "Graduate",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Graduate_UserId",
                table: "Graduate");

            migrationBuilder.CreateIndex(
                name: "IX_Graduate_UserId",
                table: "Graduate",
                column: "UserId");
        }
    }
}
