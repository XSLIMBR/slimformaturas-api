using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Graduate_GraduateId1",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Graduate_GraduateId1",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Phone_GraduateId1",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Address_GraduateId1",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "GraduateId1",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "GraduateId1",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "GraduateId",
                table: "Phone",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "GraduateId",
                table: "Address",
                nullable: true,
                oldClrType: typeof(int));

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "GraduateId",
                table: "Phone",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraduateId1",
                table: "Phone",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GraduateId",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraduateId1",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phone_GraduateId1",
                table: "Phone",
                column: "GraduateId1");

            migrationBuilder.CreateIndex(
                name: "IX_Address_GraduateId1",
                table: "Address",
                column: "GraduateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Graduate_GraduateId1",
                table: "Address",
                column: "GraduateId1",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Graduate_GraduateId1",
                table: "Phone",
                column: "GraduateId1",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
