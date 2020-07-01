using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class att : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.AlterColumn<string>(
                name: "CollegeId",
                table: "Phone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CollegeId",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CorporateName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FantasyName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Bank = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Agency = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CheckingAccount = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Site = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    DateRegister = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_College", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractCourse",
                columns: table => new
                {
                    ContractCourseId = table.Column<string>(nullable: false),
                    ContractId = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCourse", x => x.ContractCourseId);
                    table.ForeignKey(
                        name: "FK_ContractCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phone_CollegeId",
                table: "Phone",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CollegeId",
                table: "Address",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCourse_CourseId",
                table: "ContractCourse",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_College_CollegeId",
                table: "Address",
                column: "CollegeId",
                principalTable: "College",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_College_CollegeId",
                table: "Phone",
                column: "CollegeId",
                principalTable: "College",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_College_CollegeId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_College_CollegeId",
                table: "Phone");

            migrationBuilder.DropTable(
                name: "College");

            migrationBuilder.DropTable(
                name: "ContractCourse");

            migrationBuilder.DropIndex(
                name: "IX_Phone_CollegeId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Address_CollegeId",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "CollegeId",
                table: "Phone",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CollegeId",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.Id);
                });
        }
    }
}
