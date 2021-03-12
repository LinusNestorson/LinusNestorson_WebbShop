using Microsoft.EntityFrameworkCore.Migrations;

namespace LinusNestorson_WebbShop.Migrations
{
    public partial class testingTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastLogin",
                table: "Users",
                newName: "LastRefresh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastRefresh",
                table: "Users",
                newName: "LastLogin");
        }
    }
}
