using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class attmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractCourse_Course_CourseId",
                table: "ContractCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractCourse",
                table: "ContractCourse");

            migrationBuilder.DropIndex(
                name: "IX_ContractCourse_CourseId",
                table: "ContractCourse");

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "ContractCourse",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContractId",
                table: "ContractCourse",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContractCourseId",
                table: "ContractCourse",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractCourse",
                table: "ContractCourse",
                columns: new[] { "CourseId", "ContractId" });

            migrationBuilder.CreateTable(
                name: "GraduateCeremonial",
                columns: table => new
                {
                    GraduateId = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: false),
                    GraduateCeremonialId = table.Column<string>(nullable: true),
                    Committee = table.Column<bool>(nullable: false),
                    ContractId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduateCeremonial", x => new { x.GraduateId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_GraduateCeremonial_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GraduateCeremonial_Graduate_GraduateId",
                        column: x => x.GraduateId,
                        principalTable: "Graduate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GraduateCeremonial_CourseId",
                table: "GraduateCeremonial",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractCourse_Course_CourseId",
                table: "ContractCourse",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractCourse_Course_CourseId",
                table: "ContractCourse");

            migrationBuilder.DropTable(
                name: "GraduateCeremonial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractCourse",
                table: "ContractCourse");

            migrationBuilder.AlterColumn<string>(
                name: "ContractCourseId",
                table: "ContractCourse",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContractId",
                table: "ContractCourse",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "ContractCourse",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractCourse",
                table: "ContractCourse",
                column: "ContractCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCourse_CourseId",
                table: "ContractCourse",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractCourse_Course_CourseId",
                table: "ContractCourse",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
