using Microsoft.EntityFrameworkCore.Migrations;

namespace truckapi.Migrations
{
    public partial class _2stCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ward",
                table: "Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Ward",
                table: "Address");
        }
    }
}
