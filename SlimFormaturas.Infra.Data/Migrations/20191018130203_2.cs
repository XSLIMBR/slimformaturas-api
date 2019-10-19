using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeGenericId",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeGeneric",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    localization = table.Column<int>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGeneric", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_TypeGenericId",
                table: "Address",
                column: "TypeGenericId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_TypeGeneric_TypeGenericId",
                table: "Address",
                column: "TypeGenericId",
                principalTable: "TypeGeneric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_TypeGeneric_TypeGenericId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "TypeGeneric");

            migrationBuilder.DropIndex(
                name: "IX_Address_TypeGenericId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "TypeGenericId",
                table: "Address");
        }
    }
}
