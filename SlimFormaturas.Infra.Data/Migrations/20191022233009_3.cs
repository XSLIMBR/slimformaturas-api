using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_TypeGeneric_TypeGenericId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "localization",
                table: "TypeGeneric",
                newName: "Localization");

            migrationBuilder.AlterColumn<string>(
                name: "TypeGenericId",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_TypeGeneric_TypeGenericId",
                table: "Address",
                column: "TypeGenericId",
                principalTable: "TypeGeneric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_TypeGeneric_TypeGenericId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Localization",
                table: "TypeGeneric",
                newName: "localization");

            migrationBuilder.AlterColumn<string>(
                name: "TypeGenericId",
                table: "Address",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Address_TypeGeneric_TypeGenericId",
                table: "Address",
                column: "TypeGenericId",
                principalTable: "TypeGeneric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
