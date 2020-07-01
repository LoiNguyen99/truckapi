using Microsoft.EntityFrameworkCore.Migrations;

namespace truckapi.Migrations
{
    public partial class _8thCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Status_StatusId1",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_StatusId1",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "StatusId1",
                table: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Request",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_StatusId",
                table: "Request",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Status_StatusId",
                table: "Request",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Status_StatusId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_StatusId",
                table: "Request");

            migrationBuilder.AlterColumn<string>(
                name: "StatusId",
                table: "Request",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatusId1",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_StatusId1",
                table: "Request",
                column: "StatusId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Status_StatusId1",
                table: "Request",
                column: "StatusId1",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
