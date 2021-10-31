using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTodoList.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "Do it now", "Become a rock star developer" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, "Do it now", "Take fucking action" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
