using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArtPizzaTask.Infrastructure.Migrations
{
    public partial class Upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "29fc871e-cd3e-4fda-850d-4857adc1cfe9");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "e7341267-4c4d-499a-b5a7-186ab2c50dc8");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "Admin", "aea0f7ed-65f8-4762-ad6e-0a53dbe31a67", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "User", "560a1457-f849-4fe7-8270-a5d5f7c4cd05", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "Admin");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "User");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29fc871e-cd3e-4fda-850d-4857adc1cfe9", "244f703f-ff1b-4118-ae9c-8241b30a20d2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7341267-4c4d-499a-b5a7-186ab2c50dc8", "2cd2d383-9310-4d2d-b7a3-28768cdb4999", "User", "USER" });
        }
    }
}
