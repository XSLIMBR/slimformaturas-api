using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Graduate_GraduateId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Graduate_GraduateId",
                table: "Phone");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Graduate_GraduateId",
                table: "Address",
                column: "GraduateId",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Graduate_GraduateId",
                table: "Phone",
                column: "GraduateId",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Graduate_GraduateId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Graduate_GraduateId",
                table: "Phone");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Graduate_GraduateId",
                table: "Address",
                column: "GraduateId",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Graduate_GraduateId",
                table: "Phone",
                column: "GraduateId",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
