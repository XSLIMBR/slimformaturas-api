using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Agency",
                table: "Graduate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "Graduate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Graduate",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CheckingAccount",
                table: "Graduate",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Committee",
                table: "Graduate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Graduate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DadName",
                table: "Graduate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegister",
                table: "Graduate",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Graduate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "Graduate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Graduate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Graduate",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sex",
                table: "Graduate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<string>(nullable: false),
                    Cep = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Uf = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    GraduateId = table.Column<int>(nullable: false),
                    GraduateId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Graduate_GraduateId1",
                        column: x => x.GraduateId1,
                        principalTable: "Graduate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    PhoneId = table.Column<string>(nullable: false),
                    Ddd = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    GraduateId = table.Column<int>(nullable: false),
                    GraduateId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_Phone_Graduate_GraduateId1",
                        column: x => x.GraduateId1,
                        principalTable: "Graduate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_GraduateId1",
                table: "Address",
                column: "GraduateId1");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_GraduateId1",
                table: "Phone",
                column: "GraduateId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropColumn(
                name: "Agency",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "Bank",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "CheckingAccount",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "Committee",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "DadName",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "DateRegister",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Graduate");
        }
    }
}
