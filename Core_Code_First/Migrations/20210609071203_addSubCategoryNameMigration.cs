using Microsoft.EntityFrameworkCore.Migrations;

namespace Core_Code_First.Migrations
{
    public partial class addSubCategoryNameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubCategoryName",
                table: "Categories",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategoryName",
                table: "Categories");
        }
    }
}
