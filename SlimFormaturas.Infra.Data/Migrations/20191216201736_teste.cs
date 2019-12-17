using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Graduate_GraduateId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Graduate_GraduateId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Phone_GraduateId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Address_GraduateId",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "GraduateId",
                table: "Phone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GraduateId",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Graduate_Id",
                table: "Address",
                column: "Id",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Graduate_Id",
                table: "Phone",
                column: "Id",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Graduate_Id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Graduate_Id",
                table: "Phone");

            migrationBuilder.AlterColumn<string>(
                name: "GraduateId",
                table: "Phone",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "GraduateId",
                table: "Address",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phone_GraduateId",
                table: "Phone",
                column: "GraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_GraduateId",
                table: "Address",
                column: "GraduateId");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
