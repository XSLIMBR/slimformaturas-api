using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class migrationContnnract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContractId",
                table: "GraduateCeremonial",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    CollegeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GraduateCeremonial_ContractId",
                table: "GraduateCeremonial",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCourse_ContractId",
                table: "ContractCourse",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_CollegeId",
                table: "Contract",
                column: "CollegeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractCourse_Contract_ContractId",
                table: "ContractCourse",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GraduateCeremonial_Contract_ContractId",
                table: "GraduateCeremonial",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractCourse_Contract_ContractId",
                table: "ContractCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduateCeremonial_Contract_ContractId",
                table: "GraduateCeremonial");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_GraduateCeremonial_ContractId",
                table: "GraduateCeremonial");

            migrationBuilder.DropIndex(
                name: "IX_ContractCourse_ContractId",
                table: "ContractCourse");

            migrationBuilder.AlterColumn<string>(
                name: "ContractId",
                table: "GraduateCeremonial",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
