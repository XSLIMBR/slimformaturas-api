using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeGeneric",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Localization = table.Column<int>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGeneric", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Graduate",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Rg = table.Column<string>(nullable: false),
                    Sex = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    DadName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    MotherName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Photo = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    Bank = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Agency = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CheckingAccount = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graduate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Graduate_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Rg = table.Column<string>(nullable: false),
                    Sex = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Photo = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    Bank = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Agency = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CheckingAccount = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seller_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Default = table.Column<bool>(nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Street = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Complement = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    TypeGenericId = table.Column<string>(nullable: false),
                    GraduateId = table.Column<string>(nullable: true),
                    CollegeId = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    SellerId = table.Column<string>(nullable: true),
                    ShippingCompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Seller_Id",
                        column: x => x.Id,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Graduate_GraduateId",
                        column: x => x.GraduateId,
                        principalTable: "Graduate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_TypeGeneric_TypeGenericId",
                        column: x => x.TypeGenericId,
                        principalTable: "TypeGeneric",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Default = table.Column<bool>(nullable: false),
                    DDD = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    TypeGenericId = table.Column<string>(nullable: false),
                    GraduateId = table.Column<string>(nullable: true),
                    CollegeId = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    SellerId = table.Column<string>(nullable: true),
                    ShippingCompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Graduate_GraduateId",
                        column: x => x.GraduateId,
                        principalTable: "Graduate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phone_Seller_Id",
                        column: x => x.Id,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phone_TypeGeneric_TypeGenericId",
                        column: x => x.TypeGenericId,
                        principalTable: "TypeGeneric",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_GraduateId",
                table: "Address",
                column: "GraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_TypeGenericId",
                table: "Address",
                column: "TypeGenericId");

            migrationBuilder.CreateIndex(
                name: "IX_Graduate_UserId",
                table: "Graduate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_GraduateId",
                table: "Phone",
                column: "GraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_TypeGenericId",
                table: "Phone",
                column: "TypeGenericId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_UserId",
                table: "Seller",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropTable(
                name: "Graduate");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropTable(
                name: "TypeGeneric");


        }
    }
}
