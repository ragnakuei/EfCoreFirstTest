using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationConsole1.Migrations
{
    public partial class AddTel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Customers");
        }
    }
}
