using Microsoft.EntityFrameworkCore.Migrations;

namespace SlimFormaturas.Infra.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Seller_Id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Seller_Id",
                table: "Phone");

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Phone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phone_SellerId",
                table: "Phone",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_SellerId",
                table: "Address",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Seller_SellerId",
                table: "Address",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Seller_SellerId",
                table: "Phone",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Seller_SellerId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Seller_SellerId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Phone_SellerId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Address_SellerId",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Phone",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Seller_Id",
                table: "Address",
                column: "Id",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Seller_Id",
                table: "Phone",
                column: "Id",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
