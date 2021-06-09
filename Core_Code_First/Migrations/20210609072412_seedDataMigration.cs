using Microsoft.EntityFrameworkCore.Migrations;

namespace Core_Code_First.Migrations
{
    public partial class seedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryRowId", "BasePrice", "CategoryId", "CategoryName", "SubCategoryName" },
                values: new object[] { 4, 20, "Cat-003", "Electrical", "Light Bulb" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryRowId", "BasePrice", "CategoryId", "CategoryName", "SubCategoryName" },
                values: new object[] { 5, 2000, "Cat-004", "Electrical", "Kitchen Appliances" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryRowId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryRowId",
                keyValue: 5);
        }
    }
}
