using Microsoft.EntityFrameworkCore.Migrations;

namespace truckapi.Migrations
{
    public partial class _7thCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Request");

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "Request",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId1",
                table: "Request",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "Color", "Value" },
                values: new object[,]
                {
                    { 1, "0xffffeb3b", "Chờ báo giá" },
                    { 2, "0xff2196f3", "Đang vận chuyển" },
                    { 3, "0xff66bb6a", "Hoàn thành" },
                    { 4, "0xfff44336", "Đã hủy" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Status_StatusId1",
                table: "Request");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Request_StatusId1",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "StatusId1",
                table: "Request");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Request",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
