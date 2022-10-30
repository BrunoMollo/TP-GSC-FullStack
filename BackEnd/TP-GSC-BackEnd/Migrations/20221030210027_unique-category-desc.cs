using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_GSC_BackEnd.Migrations
{
    public partial class uniquecategorydesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categories_Description",
                table: "Categories",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_Description",
                table: "Categories");
        }
    }
}
