using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class teste3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Graduate_GraduateId",
                table: "Phone");

            migrationBuilder.AlterColumn<string>(
                name: "GraduateId",
                table: "Phone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Graduate_GraduateId",
                table: "Phone",
                column: "GraduateId",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Graduate_GraduateId",
                table: "Phone");

            migrationBuilder.AlterColumn<string>(
                name: "GraduateId",
                table: "Phone",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Graduate_GraduateId",
                table: "Phone",
                column: "GraduateId",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
