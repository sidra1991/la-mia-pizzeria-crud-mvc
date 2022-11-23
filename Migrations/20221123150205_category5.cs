using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeriastatic.Migrations
{
    /// <inheritdoc />
    public partial class category5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "pizze",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pizze_CategoryId",
                table: "pizze",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_pizze_categoryes_CategoryId",
                table: "pizze",
                column: "CategoryId",
                principalTable: "categoryes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizze_categoryes_CategoryId",
                table: "pizze");

            migrationBuilder.DropIndex(
                name: "IX_pizze_CategoryId",
                table: "pizze");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "pizze");
        }
    }
}
