using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class Contract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GraduateCeremonial_Contract_ContractId",
                table: "GraduateCeremonial");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduateCeremonial_Course_CourseId",
                table: "GraduateCeremonial");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduateCeremonial_Graduate_GraduateId",
                table: "GraduateCeremonial");

            migrationBuilder.DropTable(
                name: "ContractCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GraduateCeremonial",
                table: "GraduateCeremonial");

            migrationBuilder.DropIndex(
                name: "IX_GraduateCeremonial_ContractId",
                table: "GraduateCeremonial");

            migrationBuilder.DropIndex(
                name: "IX_GraduateCeremonial_CourseId",
                table: "GraduateCeremonial");

            migrationBuilder.RenameColumn(
                name: "GraduateCeremonialId",
                table: "GraduateCeremonial",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "ContractId",
                table: "GraduateCeremonial",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "GraduateCeremonial",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GraduateId",
                table: "GraduateCeremonial",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "GraduateCeremonial",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GraduateCeremonial",
                table: "GraduateCeremonial",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GraduateAlbum",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AlbumCode = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AmountPhotosAvailable = table.Column<int>(nullable: false),
                    AmountPhotosScraps = table.Column<int>(nullable: false),
                    AmountPhotosSold = table.Column<int>(nullable: false),
                    GraduateId = table.Column<string>(nullable: true),
                    ContractId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduateAlbum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraduateAlbum_Contract_Id",
                        column: x => x.Id,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GraduateAlbum_Graduate_Id",
                        column: x => x.Id,
                        principalTable: "Graduate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GraduateCeremonial_Contract_Id",
                table: "GraduateCeremonial",
                column: "Id",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GraduateCeremonial_Course_Id",
                table: "GraduateCeremonial",
                column: "Id",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GraduateCeremonial_Graduate_Id",
                table: "GraduateCeremonial",
                column: "Id",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GraduateCeremonial_Contract_Id",
                table: "GraduateCeremonial");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduateCeremonial_Course_Id",
                table: "GraduateCeremonial");

            migrationBuilder.DropForeignKey(
                name: "FK_GraduateCeremonial_Graduate_Id",
                table: "GraduateCeremonial");

            migrationBuilder.DropTable(
                name: "GraduateAlbum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GraduateCeremonial",
                table: "GraduateCeremonial");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GraduateCeremonial",
                newName: "GraduateCeremonialId");

            migrationBuilder.AlterColumn<string>(
                name: "GraduateId",
                table: "GraduateCeremonial",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "GraduateCeremonial",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContractId",
                table: "GraduateCeremonial",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GraduateCeremonialId",
                table: "GraduateCeremonial",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GraduateCeremonial",
                table: "GraduateCeremonial",
                columns: new[] { "GraduateId", "CourseId" });

            migrationBuilder.CreateTable(
                name: "ContractCourse",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractCourseId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCourse", x => new { x.CourseId, x.ContractId });
                    table.ForeignKey(
                        name: "FK_ContractCourse_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GraduateCeremonial_ContractId",
                table: "GraduateCeremonial",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduateCeremonial_CourseId",
                table: "GraduateCeremonial",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCourse_ContractId",
                table: "ContractCourse",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_GraduateCeremonial_Contract_ContractId",
                table: "GraduateCeremonial",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GraduateCeremonial_Course_CourseId",
                table: "GraduateCeremonial",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GraduateCeremonial_Graduate_GraduateId",
                table: "GraduateCeremonial",
                column: "GraduateId",
                principalTable: "Graduate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
