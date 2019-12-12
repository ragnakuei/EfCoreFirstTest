using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationConsole2.Migrations
{
    public partial class AddTelFax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Customers");
        }
    }
}
