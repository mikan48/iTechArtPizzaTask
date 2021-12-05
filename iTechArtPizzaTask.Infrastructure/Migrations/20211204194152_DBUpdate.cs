using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArtPizzaTask.Infrastructure.Migrations
{
    public partial class DBUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngridientPizza");

            migrationBuilder.DropTable(
                name: "OrderPizza");

            migrationBuilder.AddColumn<Guid>(
                name: "PizzasIngridientId",
                table: "Ingridients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderedPizzas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedPizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedPizzas_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderedPizzas_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Ingridients_PizzasIngridientId",
                table: "Ingridients",
                column: "PizzasIngridientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedPizzas_OrderId",
                table: "OrderedPizzas",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedPizzas_PizzaId",
                table: "OrderedPizzas",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzasIngridients_PizzaId",
                table: "PizzasIngridients",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingridients_PizzasIngridients_PizzasIngridientId",
                table: "Ingridients",
                column: "PizzasIngridientId",
                principalTable: "PizzasIngridients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingridients_PizzasIngridients_PizzasIngridientId",
                table: "Ingridients");

            migrationBuilder.DropTable(
                name: "OrderedPizzas");

            migrationBuilder.DropTable(
                name: "PizzasIngridients");

            migrationBuilder.DropIndex(
                name: "IX_Ingridients_PizzasIngridientId",
                table: "Ingridients");

            migrationBuilder.DropColumn(
                name: "PizzasIngridientId",
                table: "Ingridients");

            migrationBuilder.CreateTable(
                name: "IngridientPizza",
                columns: table => new
                {
                    IngridientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngridientPizza", x => new { x.IngridientId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK_IngridientPizza_Ingridients_IngridientId",
                        column: x => x.IngridientId,
                        principalTable: "Ingridients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngridientPizza_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Pizzas_Id",
                        column: x => x.Id,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngridientPizza_PizzaId",
                table: "IngridientPizza",
                column: "PizzaId");
        }
    }
}
