using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeriastatic.Migrations
{
    /// <inheritdoc />
    public partial class Ingredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzaingredient",
                columns: table => new
                {
                    PizzasId = table.Column<int>(type: "int", nullable: false),
                    ingredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzaingredient", x => new { x.PizzasId, x.ingredientsId });
                    table.ForeignKey(
                        name: "FK_Pizzaingredient_ingredientes_ingredientsId",
                        column: x => x.ingredientsId,
                        principalTable: "ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzaingredient_pizze_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "pizze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzaingredient_ingredientsId",
                table: "Pizzaingredient",
                column: "ingredientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzaingredient");

            migrationBuilder.DropTable(
                name: "ingredientes");
        }
    }
}
