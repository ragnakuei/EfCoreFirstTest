using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationConsole1.Migrations
{
    public partial class AddFax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Customers");
        }
    }
}
