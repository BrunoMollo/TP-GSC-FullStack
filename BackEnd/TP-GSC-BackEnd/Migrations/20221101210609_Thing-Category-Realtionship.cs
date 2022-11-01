using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_GSC_BackEnd.Migrations
{
    public partial class ThingCategoryRealtionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Things",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Things_CategoryId",
                table: "Things",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Things_Categories_CategoryId",
                table: "Things",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Things_Categories_CategoryId",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Things_CategoryId",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Things");
        }
    }
}
