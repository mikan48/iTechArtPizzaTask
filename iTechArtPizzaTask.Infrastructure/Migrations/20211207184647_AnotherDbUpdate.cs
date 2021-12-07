using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArtPizzaTask.Infrastructure.Migrations
{
    public partial class AnotherDbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedPizzas_Orders_OrderId",
                table: "OrderedPizzas");

            migrationBuilder.DropTable(
                name: "Ingridients");

            migrationBuilder.DropTable(
                name: "PizzasIngridients");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PromoCodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderedPizzas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngredientCost = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzasIngredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ingredientCost = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzasIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzasIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzasIngredients_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzasIngredients_IngredientId",
                table: "PizzasIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzasIngredients_PizzaId",
                table: "PizzasIngredients",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedPizzas_Orders_OrderId",
                table: "OrderedPizzas",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedPizzas_Orders_OrderId",
                table: "OrderedPizzas");

            migrationBuilder.DropTable(
                name: "PizzasIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PromoCodes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderedPizzas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "PizzasIngridients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngridientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzasIngridients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzasIngridients_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingridients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngridientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzasIngridientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingridients_PizzasIngridients_PizzasIngridientId",
                        column: x => x.PizzasIngridientId,
                        principalTable: "PizzasIngridients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingridients_PizzasIngridientId",
                table: "Ingridients",
                column: "PizzasIngridientId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzasIngridients_PizzaId",
                table: "PizzasIngridients",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedPizzas_Orders_OrderId",
                table: "OrderedPizzas",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
