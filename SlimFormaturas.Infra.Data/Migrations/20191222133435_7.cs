using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Graduate",
                type: "varchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sex",
                table: "Graduate",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldMaxLength: 1);
        }
    }
}
